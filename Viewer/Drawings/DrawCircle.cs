using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 円の描画
/// </summary>
internal class DrawCircle : IAction
{
  private LayerManager _layers;
  private PointD _firstP, _secondP, _currentP;
  private Step _step = 0;
  public event Action<double, double> StartP;
  public event Action<double> Radius, Diameter;
  public event Action StartDrawing;
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
        StartDrawing?.Invoke();
        _step++;
        break;
      case Step.Second:
        var t = new Tools(canvas);
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        double r = t.Distance(_firstP, _secondP);
        if (r < 0)
        {
          return;
        }
        _layers.AddEntity(new Circle(_firstP, r));
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
    _step--;
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
      double r = t.Distance(_firstP, _currentP);
      k.RadiusCircle(_firstP, r);
      k.TwoCircles(_firstP, _currentP);
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

  /// <summary>
  /// ディスプレイディスタンス
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void DisplayDistance(Canvas canvas)
  {
    var t = new Tools(canvas);
    if (_step == Step.Second)
    {
      double startPointX = _firstP.X;
      double startPointY = _firstP.Y;
      double distanceFromStart = t.Distance(_firstP, _currentP);
      StartP?.Invoke(startPointX, startPointY);
      Radius?.Invoke(distanceFromStart);
      double diameter = distanceFromStart * 2;
      Diameter?.Invoke(diameter);
    }
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
