using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 連続線
/// </summary>
internal class DrawPolyline : IAction
{
  private PointD _firstP, _secondP, _currentP;
  private Polyline? _polyline;
  private LayerManager _layers;
  private Step _step = Step.First;
  private enum Step
  {
    First,
    Second,
    Confirm
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
        _polyline = new Polyline();
        _polyline.Points.Add(_firstP);
        _step++;
        break;
      case Step.Second:
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        _polyline.Points.Add(_secondP);
        _step++;
        break;
      case Step.Confirm:
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        _polyline.Points.Add(_secondP);
        _firstP = _secondP;
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
  }

  /// <summary>
  /// 右クリックの時
  /// </summary>
  /// <param name="e"></param>
  public void OnRightClick(MouseEventArgs e)
  {
    if (_polyline != null)
    {
      _layers.AddEntity(_polyline);
      _polyline = null;
    }
    _step = Step.First;
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
