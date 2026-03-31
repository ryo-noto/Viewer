using Viewer.Utils;

namespace Viewer;

internal class Ruler : IAction
{
  PointD _firstP, _secondP, _currentP;
  public Action<double, double, double, double>? Measured;
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
    switch(_step)
    {
      case Step.First:
        _firstP = canvas.ToWorld(PointD.GetLocation(e));
        _step++;
        break;
      case Step.Second:
        var t = new Tools(canvas);
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        double dx = Tools.Xdistance(_firstP, _secondP);
        double dy = Tools.Ydistance(_firstP, _secondP);
        double distance = t.Distance(_firstP, _secondP);
        double angle = Tools.GetAngle(_firstP, _secondP);
        Measured?.Invoke(dx, dy, distance, angle);
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
    _currentP = PointD.GetLocation(e);
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
      k.Ruler(_firstP, _currentP);
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
