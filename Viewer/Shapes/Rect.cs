using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 矩形
/// </summary>
internal class Rect : Shape
{
  /// <summary>始点</summary>
  public PointD Start { get; set; }
  /// <summary>終点</summary>
  public PointD End { get; set; }
  /// <summary>画像</summary>
  public Image Image { get; set; }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="start">始点</param>
  /// <param name="end">終点</param>
  public Rect(PointD start, PointD end)
  {
    Start = start;
    End = end;
  }

  /// <summary>
  /// 四角形に変換
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <returns></returns>
  public RectangleF ToRectangle(Canvas canvas)
  {
    PointF start = canvas.ToScreen(Start);
    PointF end = canvas.ToScreen(End);
    float x = (float)Math.Min(start.X, end.X);
    float y = (float)Math.Min(start.Y, end.Y);
    float w = (float)Math.Abs(start.X - end.X);
    float h = (float)Math.Abs(start.Y - end.Y);
    return new RectangleF(x, y, w, h);
  }

  /// <summary>
  /// 描画
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
    if (Image != null)
    {
      g.DrawImage(Image, ToRectangle(canvas));
    }
    else
    {
      color = Selected ? Color.Red : Color.Black;
      using Pen pen = new Pen(color, size);

      g.DrawRectangle(pen, ToRectangle(canvas));
    }
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
    public override bool HitShape(Canvas canvas, PointD p)
  {
    // 四角形の4頂点を求める
    double x1 = Math.Min(Start.X, End.X);
    double y1 = Math.Min(Start.Y, End.Y);
    double x2 = Math.Max(Start.X, End.X);
    double y2 = Math.Max(Start.Y, End.Y);
    PointD a = new PointD(x1, y1); // 左上
    PointD b = new PointD(x2, y1); // 右上
    PointD c = new PointD(x2, y2); // 右下
    PointD d = new PointD(x1, y2); // 左下
    // 4 辺の当たり判定
    if (GeometryHelper.HitTestLine(a, b, p, 10.0)) return true; // 上辺
    if (GeometryHelper.HitTestLine(b, c, p, 10.0)) return true; // 右辺
    if (GeometryHelper.HitTestLine(c, d, p, 10.0)) return true; // 下辺
    if (GeometryHelper.HitTestLine(d, a, p, 10.0)) return true; // 左辺
    return false;
  }
}
