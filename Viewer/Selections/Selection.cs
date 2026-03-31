using Viewer.Utils;

namespace Viewer.Selections;
/// <summary>
/// 選択
/// </summary>
internal class Selection : IAction
{
  private LayerManager _layers;
  private Shape? _selectedShape;
  private Canvas _canvas;
  public Selection(Canvas canvas)
  {
    _canvas = canvas;
  }

  /// <summary>
  /// 左クリック
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnLeftClick(MouseEventArgs e, Canvas canvas)
  {
    var p = PointD.GetLocation(e);
    SelectShape(p);
  }

  private void SelectShape(PointD location)
  {
    _selectedShape = HitTest(location);

    if (_selectedShape != null)
    {
      // 一つの図形を選択した場合
      _selectedShape.Selected = true;
      _canvas.SetAction(new SelectedShape(_canvas, _selectedShape));
    }
    else
    {
      // 図形を選択しなかった場合は範囲選択
     _canvas.SetAction(new SelectShapes(_selectedShape));
    }
  }

  private Shape? HitTest(PointD location)
  {
    foreach (var layer in _layers.GetLayers().Reverse())
    {
      if (!layer.Visible) continue;

      foreach (var shape in layer.Entities)
      {
        if (shape.HitShape(_canvas, location))
        {
          return shape;
        }
      }
    }
      return null; 
  }

  /// <summary>
  /// レイヤー管理
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
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
  /// 右クリック
  /// </summary>
  /// <param name="e"></param>
  public void OnRightClick(MouseEventArgs e)
  {

  }

  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnMouseMove(MouseEventArgs e, Canvas canvas)
  {

  }
}
