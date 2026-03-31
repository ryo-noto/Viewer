using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 三角形
/// </summary>
internal class Triangle : Shape
{
  /// <summary>始点</summary>
  public PointD Start { get; set; }
  /// <summary>２点目</summary>
  public PointD Second { get; set; }
  /// <summary>終点</summary>
  public PointD End { get; set; }

  /// <summary>
  /// 三角形
  /// </summary>
  /// <param name="start">始点</param>
  /// <param name="second">２点目</param>
  /// <param name="end">終点</param>
  public Triangle(PointD start, PointD second, PointD end)
  {
    Start = start;
    Second = second;
    End = end;
  }

  /// <summary>
  /// 描画処理
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
    PointF start = canvas.ToScreen(Start);
    PointF second = canvas.ToScreen(Second);
    PointF end = canvas.ToScreen(End);
    color = Selected ? Color.Red : Color.Black;
    using Pen pen = new Pen(color, size);

    g.DrawLine(pen, start, second);
    g.DrawLine(pen, second, end);
    g.DrawLine(pen, end, start);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public override bool HitShape(Canvas canvas, PointD p)
  {
    // 3本の辺に対して当たり判定
    if (GeometryHelper.HitTestLine(Start, Second, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(Second, End, p, 10.0)) return true;
    if (GeometryHelper.HitTestLine(End, Start, p, 10.0)) return true;
    return false;
  }
}
