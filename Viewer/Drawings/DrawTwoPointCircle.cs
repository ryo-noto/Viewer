using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// ２点円
/// </summary>
internal class DrawTwoPointCircle : IAction
{
  private PointD _firstP, _secondP, _currentP;
  private LayerManager _layers;
  public event Action<double, double> StartP, EndP;
  public event Action<double> Diameter, Radius;
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
        StartDrawing?.Invoke();
        _step++;
        break;
      case Step.Second:
        var t = new Tools(canvas);
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        double r = t.Distance(_firstP, _secondP) / 2;
        PointD center = t.GetMidPoint(_firstP, _secondP);
        _layers.AddEntity(new Circle(center, r));
        _step--;
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
      double startPointX = _firstP.X;
      double startPointY = _firstP.Y;
      double diameter = t.Distance(_firstP, _currentP);
      StartP?.Invoke(startPointX, startPointY);
      Diameter?.Invoke(diameter);
      double radius = diameter / 2;
      Radius?.Invoke(radius);
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
      PointD center = t.GetMidPoint(_firstP, _currentP); // 直径の中心点を求める
      double r = t.Distance(center, _currentP);
      k.Line(_firstP, _currentP);
      k.RadiusCircle(center, r);
      k.TwoCircles(_firstP, _currentP);
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
