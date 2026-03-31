using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 線分
/// </summary>
internal class Line : Shape
{
  /// <summary>始点</summary>
  public PointD Start { get; set; }
  /// <summary>終点</summary>
  public PointD End { get; set; }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="a">始点</param>
  /// <param name="b">終点</param>
  public Line(PointD a, PointD b)
  {
    Start = a;
    End = b;
  }

  /// <summary>
  /// 描画
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
      color = Selected ? Color.Red : Color.Black;
      using Pen pen = new Pen(color, size);
      PointF start = canvas.ToScreen(Start);
      PointF end = canvas.ToScreen(End);

      g.DrawLine(pen, start, end);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public override bool HitShape(Canvas canvas, PointD p)
  {
    return GeometryHelper.HitTestLine(Start, End, p , 10.0);
  }
}
