using Viewer.Utils;
using Viewer.Globals;

namespace Viewer.Selections;

internal class SelectedShape : IAction
{
  private LayerManager _layers;
  private Shape? _selectedShape;
  private PointD _firstP;
  private Canvas _canvas;

  internal SelectedShape(Canvas canvas, Shape selectedShape)
  {
    this._selectedShape = selectedShape;
    this._canvas = canvas;
  }

  /// <summary>
  /// 左クリック
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnLeftClick(MouseEventArgs e, Canvas canvas)
  {
    _firstP = PointD.GetLocation(e);
    SelectShape(_firstP);
  }

  /// <summary>
  /// 選択
  /// </summary>
  /// <param name="location"></param>
  private void SelectShape(PointD location)
  {
    var hit = HitTest(location);
    System.Diagnostics.Debug.WriteLine(hit);
    if (hit == null) //　２回目のクリックでnullだった時は最初に戻る
    {
      _selectedShape.Selected = false; // 選択されていた図形を黒に戻す
      _canvas.SetAction(new Selection(_canvas));
    }
    else if (hit == _selectedShape)
    {
      _selectedShape = hit;
    }
  }

  /// <summary>
  /// ヒット
  /// </summary>
  /// <param name="location"></param>
  /// <returns></returns>
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
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnMouseMove(MouseEventArgs e, Canvas canvas)
  {
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
  /// レイヤー管理
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
}
