using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 三角柱
/// </summary>
internal class TriangularPrism : Shape
{
  /// <summary>始点</summary>
  public PointD Start { get; set; }
  /// <summary>２点目</summary>
  public PointD Second { get; set; }
  /// <summary>３点目</summary>
  public PointD Third { get; set; }
  /// <summary>終点</summary>
  public PointD End { get; set; }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="start">始点</param>
  /// <param name="second">２点目</param>
  /// <param name="third">３点目</param>
  /// <param name="end">終点</param>
  public TriangularPrism(PointD start, PointD second, PointD third, PointD end)
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
    using Pen pen = new Pen(color, size);

    g.DrawLine(pen, start, second);
    g.DrawLine(pen, second, third);
    g.DrawLine(pen, third, start);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="location">クリック位置</param>
  /// <returns></returns>
  /// <exception cref="NotImplementedException"></exception>
  public override bool HitShape(Canvas canvas,PointD location)
  {
    throw new NotImplementedException();
  }
}
