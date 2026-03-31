using Viewer.Utils;

namespace Viewer.Drawings;
internal class DrawCone : IAction
{
  private PointD _firstP, _secondP, _currentP;
  private LayerManager _layers;
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
      k.Line(_firstP, _currentP);
      k.TwoPointsCircle(t.GetMidPoint(_firstP, _currentP), _currentP);
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
  /// レイヤー管理
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
}
