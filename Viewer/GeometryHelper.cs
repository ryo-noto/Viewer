using Viewer.Utils;

namespace Viewer;

internal class GeometryHelper
{
  /// <summary>
  /// 線分の当たり判定
  /// </summary>
  /// <param name="a">端点A</param>
  /// <param name="b">端点B</param>
  /// <param name="p">クリックした点</param>
  /// <param name="tolerance">ヒットの許容距離</param>
  /// <returns></returns>
  public static bool HitTestLine(PointD a, PointD b, PointD p, double tolerance = 10)
  {
    // 線分の端点をそれぞれA、Bとすると・・AからBへ向かうベクトル　右にどれだけ、上にどれだけ進むか
    double dx = b.X - a.X;
    double dy = b.Y - a.Y;　　// A→Bの向きを求める
    // 三平方の定理からABの長さを求める
    double len2 = dx * dx + dy * dy;

    if (len2 == 0) // 距離が0の時はreturn
    {
      return false;
    }
    // 点Pから見て、A→Bの方向にどれくらい進んだ位置かを0～1の数で表している
    double t = ((p.X - a.X) * dx + (p.Y - a.Y) * dy) / len2;

    if (t < 0 || t > 1)
    {
      return false;
    }
    // そして距離を求める
    double projX = a.X + t * dx;
    double projY = a.Y + t * dy;

    double dx2 = p.X - projX;
    double dy2 = p.Y - projY;

    // distが7px以内ヒット
    double dist = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
    return dist <= tolerance;
  }

  /// <summary>
  /// 円の当たり判定
  /// </summary>
  /// <param name="center">中心点</param>
  /// <param name="radius">半径</param>
  /// <param name="p">クリックした点</param>
  /// <param name="tolerance">ヒットの許容距離</param>
  /// <returns></returns>
  public static bool HitTestCircle(PointD center, double radius, PointD p, double tolerance = 10)
  {
    double dx = p.X - center.X;
    double dy = p.Y - center.Y;
    double dist = Math.Sqrt(dx * dx + dy * dy);
    double diff = Math.Abs(dist - radius);
    return diff <= tolerance;
  }

  /// <summary>
  /// 円弧の当たり判定
  /// </summary>
  /// <param name="center">中心点</param>
  /// <param name="radiusPoint">半径の点</param>
  /// <param name="startPoint">開始角点</param>
  /// <param name="endPoint">終了角点</param>
  /// <param name="p">クリックした点</param>
  /// <param name="tolerance">ヒットの許容距離</param>
  /// <returns></returns>
  public static bool HitTestArc(Canvas canvas, PointD center, PointD radiusPoint, PointD startPoint, PointD endPoint, PointD p, double tolerance = 10)
  {
    var t = new Tools(canvas);
    // ① 半径を求める（PointD → double）
    double radius = t.Distance(center, radiusPoint);

    // ② 点Pの中心からの距離
    double dx = p.X - center.X;
    double dy = p.Y - center.Y;
    double dist = Math.Sqrt(dx * dx + dy * dy);

    // 円周からの距離
    double diff = Math.Abs(dist - radius);

    // 円周に近くなければヒットしない
    if (diff > tolerance)
      return false;

    // ③ CAD角度で角度を求める
    double angleP = Tools.GetAngle(center, p);
    double angleStart = Tools.GetAngle(center, startPoint);
    double angleEnd = Tools.GetAngle(center, endPoint);

    // 0〜360 に正規化
    angleP = (angleP + 360) % 360;
    angleStart = (angleStart + 360) % 360;
    angleEnd = (angleEnd + 360) % 360;

    // ④ 弧の角度範囲に入っているか？
    bool inside;

    if (angleStart <= angleEnd)
    {
      inside = (angleP >= angleStart && angleP <= angleEnd);
    }
    else
    {
      // 360° をまたぐ場合
      inside = (angleP >= angleStart || angleP <= angleEnd);
    }
    return inside;
  }
}
