using System.Runtime.InteropServices;
using System.Security.Policy;
using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 円
/// </summary>
internal class Circle : Shape
{
  /// <summary>中心点</summary>
  public PointD Center { get; set; }
  /// <summary>半径</summary>
  public double Radius { get; set; }

  /// <summary>
  /// 円
  /// </summary>
  /// <param name="a">中心点</param>
  /// <param name="b">半径</param>
  public Circle(PointD a, double b)
  {
    Center = a;
    Radius = b;
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
    Pen pen = new Pen (color, size);
    // 中心をスクリーン座標に変換
    PointF center = canvas.ToScreen(Center);
    // 半径をスクリーン距離に変換
    float r = (float)(Radius * zoom);
    float x = center.X - r;
    float y = center.Y - r;
    float w = r * 2;
    float h = r * 2;

    g.DrawEllipse(pen, x, y, w, h);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public override bool HitShape(Canvas canvas,PointD p)
  {
    return GeometryHelper.HitTestCircle(Center, Radius, p, 10.0);
  }
}
