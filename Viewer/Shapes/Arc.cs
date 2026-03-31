using Viewer.Utils;

namespace Viewer.Shapes;
/// <summary>
/// 円弧
/// </summary>
internal class Arc : Shape
{
  /// <summary>始点</summary>
  public PointD Center { get; set; }
  /// <summary>半径</summary>
  public PointD Radius { get; set; }
  /// <summary>開始角</summary>
  public PointD StartAngle { get; set; }
  /// <summary>描く角度</summary>
  public PointD SweepAngle { get; set; }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="center">始点</param>
  /// <param name="radius">半径</param>
  /// <param name="startAngle">開始角</param>
  /// <param name="sweepAngle">描く角度</param>
  internal Arc(PointD center, PointD radius, PointD startAngle, PointD sweepAngle)
  {
    Center = center;
    Radius = radius;
    StartAngle = startAngle;
    SweepAngle = sweepAngle;
  }

  /// <summary>
  /// 描画
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public override void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom)
  {
    PointF c = canvas.ToScreen(Center);
    double r = canvas.WorldToScreenLength(Tools.PointDistance(Center, Radius));

    float x = (float)(c.X - r);
    float y = (float)(c.Y - r);
    float w = (float)(r * 2);
    float h = (float)(r * 2);

    double startCad = Tools.GetAngle(Center, StartAngle);
    double endCad = Tools.GetAngle(Center, SweepAngle);

    float startWin = (float)((360 - startCad) % 360);
    float endWin = (float)((360 - endCad) % 360);

    float sweepWin = endWin - startWin;
    if (sweepWin < 0) sweepWin += 360;

    using Pen pen = new Pen(Selected ? Color.Red : color, size);

    g.DrawArc(pen, x, y, w, h, startWin, sweepWin);
  }

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public override bool HitShape(Canvas canvas, PointD p)
  {
    return GeometryHelper.HitTestArc(canvas, Center, Radius, StartAngle, SweepAngle, p, 10.0);
  }
}
