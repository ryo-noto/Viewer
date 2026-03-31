using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 線分
/// </summary>
internal class DrawLine : IAction
{
  private LayerManager _layers;
  private PointD _firstP, _secondP, _currentP;
  public event Action<double, double> StartP, EndP, Distance;
  public event Action<double> DistanceFromStart, Angle;
  public event Action StartDrawing;
  private Step _step = 0;
  private enum Step
  {
    First,
    Second,
  }

  /// <summary>
  /// 左クリック
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnLeftClick(MouseEventArgs e, Canvas canvas)
  {
    switch (_step)
    {
      case Step.First:
        _firstP = canvas.ToWorld(PointD.GetLocation(e));
        _secondP = _firstP;
        StartDrawing?.Invoke();
        _step++;
        break;
      case Step.Second:
        _layers.AddEntity(new Line(_firstP, _secondP));
        _step--;
        break;
    }
  }

  /// <summary>
  /// 右クリック
  /// </summary>
  /// <param name="e"></param>
  public void OnRightClick(MouseEventArgs e)
  {
    if (_step == Step.Second)
    {
      _step--;
    }
  }

  /// <summary>
  /// ペイント
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnPaint(PaintEventArgs e, Canvas canvas)
  {
    var k = new Kakimasu(canvas, e.Graphics);
    var t = new Tools(canvas);

    if (_step == Step.Second)
    {
      k.Line(_firstP, _secondP);
      k.TwoCircles(_firstP, _secondP);
      k.AddString(_firstP, _secondP);
    }
  }

  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnMouseMove(MouseEventArgs e, Canvas canvas)
  {
    _currentP = canvas.ToWorld(PointD.GetLocation(e));
    DisplayDistance(canvas);

    if (_step == Step.Second)
    {
      AddSnap(canvas);
    }
  }

  /// <summary>
  /// 距離表示
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void DisplayDistance(Canvas canvas)
  {
    var t = new Tools(canvas);
    if (_step == Step.Second)
    {
      // x,yの距離
      double dx = Math.Abs(Tools.Xdistance(_firstP, _secondP));
      double dy = Math.Abs(Tools.Ydistance(_firstP, _secondP));
      Distance?.Invoke(dx, dy);
      // 始点
      double startPointX = _firstP.X;
      double startPointY = _firstP.Y;
      StartP?.Invoke(startPointX, startPointY);
      // 終点
      double endPointX = _secondP.X;
      double endPointY = _secondP.Y;
      EndP?.Invoke(endPointX, endPointY);

      // 始点から現在地の距離
      double distanceFromStart = t.Distance(_firstP, _secondP);
      DistanceFromStart?.Invoke(distanceFromStart);

      // ★角度
      double angle = Tools.GetAngle(_firstP, _secondP);
      Angle?.Invoke(angle);
    }
  }

  /// <summary>
  /// レイヤーマネージャー
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
 
  /// <summary>
  /// アドスナップ表示
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void AddSnap(Canvas canvas)
  {
    var t = new Tools(canvas);
    // 現在のマウス位置から始点までの距離をだす
    double dx = _currentP.X - _firstP.X;
    double dy = _currentP.Y - _firstP.Y;
    // 5px以内にあれば水平か垂直
    const double snap = 10;
    double angle = Tools.GetAngle(_firstP, _currentP);
    double length = t.Distance(_firstP, _currentP);
    if (Math.Abs(dy) < snap)
    {
      //　水平スナップ
      _secondP = new PointD(_currentP.X, _firstP.Y);
    }
    else if (Math.Abs(dx) < snap)
    {
      // 垂直スナップ
      _secondP = new PointD(_firstP.X, _currentP.Y);
    }
    // 45°
    else if (Math.Abs(angle - 45) < 5)
    {
      _secondP = Tools.GetPointByAngle(_firstP, 45, length);
    }
    else if (Math.Abs(angle - 135) < 5)
    {
      _secondP = Tools.GetPointByAngle(_firstP, 135, length);
    }
    else if (Math.Abs(angle - 225) < 5)
    {
      _secondP = Tools.GetPointByAngle(_firstP, 225, length);
    }
    else if (Math.Abs(angle - 315) < 5)
    {
      _secondP = Tools.GetPointByAngle(_firstP, 315, length);
    }
    else
    {
      _secondP = _currentP;
    }
  }
}
