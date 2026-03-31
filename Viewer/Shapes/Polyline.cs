using Viewer.Utils;

namespace Viewer.Shapes;

internal class Polyline : Shape
{
  /// <summary>
  /// 座標リスト
  /// </summary>
  public List<PointD> Points { get; } = new();

  public Polyline() { }

  public Polyline (PointD points)
  {
    Points.Add(points);
  }

  /// <summary>
  /// 描画
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
    using Pen pen = new Pen(color, size);
    if (Points.Count < 2) return;
    for (int i = 0; i < Points.Count - 1; i++)
    {
      PointF p = new PointF((float)Points[i].X, (float)Points[i].Y);
      PointF p2 = new PointF((float)Points[i + 1].X, (float)Points[i + 1].Y);
      //g.DrawLine(pen, p * zoom, p2 * zoom);
    }
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
