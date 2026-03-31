namespace Viewer;

internal class ActionEvents
{
  public event Action<double, double> StartPoints, EndPoints, DistanceChanged;
  public event Action<double> DistanceFromStart;
  public event Action StartDrawing;
}
