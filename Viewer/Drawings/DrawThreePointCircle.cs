using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 三点円
/// </summary>
internal class DrawThreePointCircle : IAction
{
  private PointD _firstP, _secondP, _thirdP, _centerP, _currentP;
  private LayerManager _layers;
  public event Action<double, double> StartP, SecondP, EndP;
  public event Action<double> Diameter, Radius;
  public event Action StartDrawing;
  private Step _step = 0;
  private enum Step
  {
    First,
    Second,
    Third,
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
        var t = new Tools(canvas);
        _thirdP = canvas.ToWorld(PointD.GetLocation(e));
        _centerP = Tools.Circumcenter(_firstP, _secondP, _thirdP);
        double r = t.Distance(_centerP, _firstP);
        _layers.AddEntity(new Circle(_centerP, r));
        _step = Step.First;
        break;
    }
  }

  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas"></param>
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
      // 始点
      double startPx = _firstP.X, startPy = _firstP.Y;
      StartP?.Invoke(startPx, startPy);
      // 直径
      double diameter = t.Distance(_firstP, _currentP);
      Diameter?.Invoke(diameter);
      // 半径
      double radius = diameter / 2;
      Radius?.Invoke(radius);  
    }
    else if (_step == Step.Third)
    {
      // ２点目
      double secondPx = _secondP.X, secondPy = _secondP.Y;
      SecondP?.Invoke(secondPx, secondPy);

      // 直径と半径
      PointD centerP = Tools.Circumcenter(_firstP, _secondP, _currentP);
      double radius = t.Distance(centerP, _currentP);
      double diameter = radius * 2;
      Diameter?.Invoke(diameter);
      Radius?.Invoke(radius);
    }
      double endPx = _thirdP.X, endPy = _thirdP.Y;
      EndP?.Invoke(endPx, endPy);
  }

  /// <summary>
  /// ペイント
  /// </summary>
  /// <param name="e">ペイント</param>
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
    else if (_step == Step.Third)
    {
      if (t.Distance(_secondP, _currentP) > 0)
      {
        PointD centerP = Tools.Circumcenter(_firstP, _secondP, _currentP);
        double radius = t.Distance(centerP, _currentP);
        k.RadiusCircle(centerP, radius);
        k.Line(_firstP, _secondP);
        k.Line(_secondP, _currentP);
        k.Line(_firstP, _currentP);
        k.ThreeCircles(_firstP, _secondP, _currentP);
      }
      else
      {
        PointD center = t.GetMidPoint(_firstP, _currentP); // 直径の中心点を求める
        double r = t.Distance(center, _currentP);
        k.Line(_firstP, _currentP);
        k.RadiusCircle(center, r);
        k.TwoCircles(_firstP, _currentP);
      }
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
  /// レイヤー管理
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
}
