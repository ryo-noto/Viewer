using Viewer.Utils;

namespace Viewer.Selections;

internal class SelectShapes : IAction
{
  private Shape? _selectedShape;
  internal SelectShapes(Shape selectedShape)
  {
    this._selectedShape = selectedShape;
  }

  public void OnLeftClick(MouseEventArgs e, Canvas canvas)
  {

  }

  public void OnMouseMove(MouseEventArgs e, Canvas canvas)
  {

  }

  public void OnPaint(PaintEventArgs e, Canvas canvas)
  {

  }

  public void OnRightClick(MouseEventArgs e)
  {

  }

  public void SetLayerManager(LayerManager lm)
  {

  }
}
