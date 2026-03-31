using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 三角錐
/// </summary>
internal class TriangularPyramid : Shape
{
  /// <summary>始点</summary>
  public PointD Start { get; set; }
  /// <summary>２点目</summary>
  public PointD Second { get; set; }
  /// <summary>３点目</summary>
  public PointD Third { get; set; }
  /// <summary>４点目</summary>
  public PointD End { get; set; }

  /// <summary>
  /// 三角錐
  /// </summary>
  /// <param name="start">始点</param>
  /// <param name="second">２点目</param>
  /// <param name="third">３点目</param>
  /// <param name="end">終点</param>
  public TriangularPyramid(PointD start, PointD second, PointD third, PointD end)
  {
    Start = start;
    Second = second;
    Third = third;
    End = end;
  }

  /// <summary>
  /// 描画
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
    PointF start = canvas.ToScreen(Start);
    PointF second = canvas.ToScreen(Second);
    PointF third = canvas.ToScreen(Third);
    PointF end = canvas.ToScreen(End);
    color = Selected ? Color.Red : Color.Black;
    using Pen pen = new Pen(color, size);

    g.DrawLine(pen, start, second);
    g.DrawLine(pen, second, third);
    g.DrawLine(pen, third, end);
    g.DrawLine(pen, third, start);
    g.DrawLine(pen, end, start);
    g.DrawLine(pen, start, end);
    g.DrawLine(pen, second, end);
    g.DrawLine(pen, third, end);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
    public override bool HitShape(Canvas canvas, PointD p)
  {
    if (GeometryHelper.HitTestLine(Start, Second, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Second, Third, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Third, End, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Third, Start, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(End, Start, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Start, End, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Second, End, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Third, End, p, 10.0)) return true;
    return false;
  }
}

