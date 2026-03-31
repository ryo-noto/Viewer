namespace Viewer.Utils;
/// <summary>
/// Double座標
/// </summary>
public struct PointD
{
  /// <summary>X座標</summary>
  public double X { get; set; }
  /// <summary>Y座標</summary>
  public double Y { get; set; }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="x">X座標param>
  /// <param name="y">Y座標</param>
  public PointD(double x, double y)
  {
    X = x;
    Y = y;
  }

  /// <summary>
  /// doubleに変換
  /// </summary>
  /// <param name="e">クリック位置</param>
  /// <returns></returns>
  public static PointD GetLocation(MouseEventArgs e)
  {
    return new PointD(e.Location.X, e.Location.Y);
  }
}
