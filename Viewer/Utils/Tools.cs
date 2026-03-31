using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.Xml;

namespace Viewer.Utils;
/// <summary>
/// ツール
/// </summary>
internal class Tools
{
  private readonly Canvas _canvas;

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  public Tools(Canvas canvas)
  {
    _canvas = canvas;
  }

  /// <summary>
  /// 距離を求める
  /// </summary>
  /// <param name="a">始点</param>
  /// <param name="b">終点</param>
  /// <returns></returns>
  public double Distance(PointD a, PointD b)
  {
    double dx = b.X - a.X;
    double dy = b.Y - a.Y;
    return Math.Sqrt(dx * dx + dy * dy);
  }

  /// <summary>
  /// Xの座標距離
  /// </summary>
  /// <param name="a">始点</param>
  /// <param name="b">終点</param>
  /// <returns></returns>
  public static double Xdistance(PointD a, PointD b)
  {
    double p;
    return p = Math.Abs(b.X - a.X);
  }

  /// <summary>
  /// Yの座標距離
  /// </summary>
  /// <param name="a">始点</param>
  /// <param name="b">終点</param>
  /// <returns></returns>
  public static double Ydistance(PointD a, PointD b)
  {
    double p;
    return p = Math.Abs(b.Y - a.Y);
  }

  /// <summary>
  /// 角度を求める
  /// </summary>
  /// <param name="p">始点</param>
  /// <param name="p2">終点</param>
  /// <returns></returns>
  public static double GetAngle(PointD p, PointD p2)
  {
    double dx = p2.X - p.X;
    double dy = p.Y - p2.Y; // ←ここが重要(数学座標に変換)

    double angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;

    if (angle < 0) angle += 360;

    return angle;
  }

  /// <summary>
  /// 角度から点を求める
  /// </summary>
  /// <param name="start">１点目</param>
  /// <param name="angleDeg">１点目と２点目の角度</param>
  /// <param name="length">１点目と２点目の長さ</param>
  /// <returns></returns>
  public static PointD GetPointByAngle(PointD start, double angleDeg, double length)
  {
    double winAngle = (360 - angleDeg) % 360;

    double angleRad = winAngle * Math.PI / 180.0;
    double x = start.X + Math.Cos(angleRad) * length;
    double y = start.Y + Math.Sin(angleRad) * length;
    return new PointD(x, y);
  }

  /// <summary>
  /// ２点の中点を求める
  /// </summary>
  /// <param name="p">始点</param>
  /// <param name="p2">終点</param>
  /// <returns></returns>
  public PointD GetMidPoint(PointD p, PointD p2)
  {
    double x = (p.X + p2.X) / 2;
    double y = (p.Y + p2.Y) / 2;
    return new PointD(x, y);
  }

  /// <summary>
  /// 重心点
  /// </summary>
  /// <param name="p">１点目</param>
  /// <param name="p2">２点目</param>
  /// <param name="p3">３点目</param>
  /// <returns></returns>
  public static PointD Centroid(PointD p, PointD p2, PointD p3)
  {
    double x = (p.X + p2.X + p3.X) / 3;
    double y = (p.Y + p2.Y + p3.Y) / 3; 
    return new PointD(x, y);
  }

  /// <summary>
  /// ３点から外心を求める
  /// </summary>
  /// <param name="a">外周点a</param>
  /// <param name="b">外周点b</param>
  /// <param name="c">外周点c</param>
  /// <returns></returns>
  public static PointD Circumcenter(PointD a, PointD b, PointD c)
  {
    double x1 = a.X, y1 = a.Y;
    double x2 = b.X, y2 = b.Y;
    double x3 = c.X, y3 = c.Y;

    double D = 2f * (x1 * (y2 - y3) +
                     x2 * (y3 - y1) +
                     x3 * (y1 - y2));
    if (Math.Abs(D) < 1e-6)
      return a;

    double x = ((x1 * x1 + y1 * y1) * (y2 - y3) +
                (x2 * x2 + y2 * y2) * (y3 - y1) +
                (x3 * x3 + y3 * y3) * (y1 - y2)) / D;

    double y = ((x1 * x1 + y1 * y1) * (x3 - x2) +
                (x2 * x2 + y2 * y2) * (x1 - x3) +
                (x3 * x3 + y3 * y3) * (x2 - x1)) / D;

    return new PointD(x, y);
  }

  /// <summary>
  /// 座標距離
  /// </summary>
  /// <param name="p">１点目</param>
  /// <param name="p2">２点目</param>
  /// <returns></returns>
  public static double PointDistance(PointD p, PointD p2)
  {
    double dx = p2.X - p.X;
    double dy = p2.Y - p.Y;
    return Math.Sqrt(dx * dx + dy * dy);
  }

  /// <summary>
  /// 円周上の点
  /// </summary>
  /// <param name="center">中心点</param>
  /// <param name="radius">半径</param>
  /// <param name="cadAngle">中心点から終点までの角度</param>
  /// <returns></returns>
  public static PointD GetPointOnCircle(PointD center, double radius, double cadAngle)
  {
    // CAD角度 => WinForms角度
    double winAngle = (360 - cadAngle) % 360;
    // ラジアンに変換
    double rad = winAngle * Math.PI / 180.0;
    // 座標計算
    double x = center.X + Math.Cos(rad) * radius;
    double y = center.Y + Math.Sin(rad) * radius;
    return new PointD(x, y);
  }
}