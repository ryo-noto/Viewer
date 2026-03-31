using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 三角柱
/// </summary>
internal class DrawTriangularPrism : IAction
{
  private PointD _firstP, _secondP, _thirdP, _endP, _currentP;
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
        _layers.AddEntity(new TriangularPyramid(_firstP, _secondP, _thirdP, _endP));
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
    else if (_step == Step.Fourth)
    {
      PointD centerP = Tools.Centroid(_firstP, _secondP, _thirdP);
      k.AddString(centerP, _currentP);
      k.Line(centerP, _currentP);
      k.Line(_firstP, _secondP);
      k.Line(_secondP, _thirdP);
      k.Line(_thirdP, _firstP);
      k.Line(_firstP, _currentP);
      k.Line(_secondP, _currentP);
      k.Line(_thirdP, _currentP);
      k.FourCircles(_firstP, _secondP, _thirdP, _currentP);
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
