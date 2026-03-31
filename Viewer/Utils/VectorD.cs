namespace Viewer.Utils;

internal class VectorD
{
  internal double X;
  internal double Y;

  internal VectorD(double x, double y)
  {
    X = x;
    Y = y;
  }
}

internal static class PointExtensions
{
  internal static PointD Add(this PointD p, VectorD v)
    => new PointD(p.X + v.X, p.Y + v.Y);
}
