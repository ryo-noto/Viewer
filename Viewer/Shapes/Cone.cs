using Viewer.Utils;

namespace Viewer.Shapes;
internal class Cone : Shape
{
  /// <summary>中心点</summary>
  public PointD Center { get; set; }
  /// <summary>終点</summary>
  public PointD End { get; set; }

  /// <summary>
  /// 三角錐
  /// </summary>
  /// <param name="center">中心点</param>
  /// <param name="end">終点</param>
  public Cone(PointD center, PointD end)
  {
    Center = center;
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
    var t = new Tools(canvas);
    double radius = t.Distance(Center, End);
    float x = (float)(Center.X - radius) * zoom;
    float y = (float)(Center.Y - radius) * zoom;
    float width = (float)(radius * 2) * zoom;
    float height = (float)(radius * 2) * zoom;

    g.DrawEllipse(Pens.Black, x, y, width, height);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public override bool HitShape(Canvas canvas, PointD p)
  {
    throw new NotImplementedException();
  }
}

