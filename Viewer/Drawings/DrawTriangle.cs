using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 三角形
/// </summary>
internal class DrawTriangle : IAction
{
  private PointD _firstP, _secondP, _thirdP, _currentP;
  private LayerManager _layers;
  public event Action<double, double> StartP, SecondP, EndP;
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
        StartDrawing?.Invoke();
        _step++;
        break;
      case Step.Second:
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        _step++;
        break;
      case Step.Third:
        _thirdP = canvas.ToWorld(PointD.GetLocation(e));
        _layers.AddEntity(new Triangle(_firstP, _secondP, _thirdP));
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
    DisplayDistance();
  }

  private void DisplayDistance()
  {
    if (_step == Step.Second)
    {
      // 始点
      double startPx = _firstP.X, startPy = _firstP.Y;
      StartP?.Invoke(startPx, startPy);
    }
    else if (_step == Step.Third)
    {
      // ２点目
      double secondPx = _secondP.X, secondPy = _secondP.Y;
      SecondP?.Invoke(secondPx, secondPy);
      // ３点目
      double endPx = _thirdP.X, endPy = _thirdP.Y;
      EndP?.Invoke(endPx, endPy);
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
    if (_step == Step.Second)
    {
      k.Line(_firstP, _currentP);
      k.TwoCircles(_firstP, _currentP);
    }
    else if (_step == Step.Third)
    {
      k.Line(_firstP, _secondP);
      k.Line(_secondP, _currentP);
      k.Line(_currentP, _firstP);
      k.ThreeCircles(_firstP, _secondP, _currentP);
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
