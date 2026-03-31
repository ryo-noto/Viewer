namespace Viewer;

internal class DrawingPage : TabPage
{
  public LayerManager Layaers { get; } = new LayerManager();
  public Canvas Canvas { get; }

  public DrawingPage(string title)
  {
    this.Text = title;
    Canvas = new Canvas();
    Canvas.Dock = DockStyle.Fill;
    this.Controls.Add(Canvas);
  }
}
