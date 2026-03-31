using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 円弧
/// </summary>

internal class DrawArc : IAction
{
  private PointD _firstP, _secondP, _thirdP, _endP, _currentP;
  public event Action<double, double> CenterP;
  public event Action<double> Radius, StartA, EndA;
  private LayerManager _layers;
  private Step _step = 0;
  private enum Step
  {
    First,
    Second,
    Third,
    Fourth,
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
        _step++;
        break;
      case Step.Second:
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        _step++;
        break;
      case Step.Third:
        _thirdP = canvas.ToWorld(PointD.GetLocation(e));
        _step++;
        break;
      case Step.Fourth:
        _endP = canvas.ToWorld(PointD.GetLocation(e));
        _layers.AddEntity(new Arc(_firstP, _secondP, _thirdP, _endP));
        _step = Step.First;
        break;
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
  }

  private void DisplayDistance(Canvas canvas)
  {
    var t = new Tools(canvas);
    if (_step == Step.Second)
    {
      // 中心点
      double centerPx = _firstP.X, centerPy = _firstP.Y;
      CenterP?.Invoke(centerPx, centerPy);
    }
    else if (_step == Step.Third)
    {
      // 半径
      double r = t.Distance(_firstP, _secondP);
      Radius?.Invoke(r);
    }
    else if (_step == Step.Fourth)
    {
      // 開始角度
      double startA = Tools.GetAngle(_firstP, _thirdP);
      StartA?.Invoke(startA);
      // 終了角度
      double endA = Tools.GetAngle(_firstP, _endP);
      EndA?.Invoke(endA);
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
      // 半径
      double r = t.Distance(_firstP, _currentP);
      // 最初の円
      k.RadiusCircle(_firstP, r);
      // ２つの点
      k.TwoCircles(_firstP, _currentP);
    }
    else if (_step == Step.Third)
    {
      // 半径
      double r = t.Distance(_firstP, _secondP);
      // 円
      k.RadiusCircle(_firstP, r);
      // 線
      k.Line(_firstP, _currentP);
      // 中心点と現在点の〇
      k.TwoCircles(_firstP, _currentP);
    }
    else if (_step == Step.Fourth)
    {
      // ラバーバンド線
      k.Line(_firstP, _currentP);
      // 円弧（中心・開始点・通過点・終了点）
      k.Arc(_firstP, _secondP, _thirdP, _currentP);
      // 開始角
      double startAngle = Tools.GetAngle(_firstP, _thirdP);
      // 終了角
      double r = t.Distance(_firstP, _secondP);
      // 中心点から開始角の円周上の点
      PointD startAnglePoint = Tools.GetPointByAngle(_firstP, startAngle, r);
      // ラバーバンドの丸（中心・開始点・現在点）
      k.ThreeCircles(_firstP, startAnglePoint, _currentP);
    }
  }

  /// <summary>
  /// 右クリック
  /// </summary>
  /// <param name="e"></param>
  public void OnRightClick(MouseEventArgs e)
  {
  }

  /// <summary>
  /// レイヤー管理セット
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
}
