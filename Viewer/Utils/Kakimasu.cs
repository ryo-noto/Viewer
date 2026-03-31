namespace Viewer.Utils;
/// <summary>
/// 図形の描画
/// </summary>
internal class Kakimasu
{
  private readonly Canvas _canvas;
  private readonly Graphics _g;

  /// <summary>
  /// コンストラクタ
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="g">グラフィックス</param>
  public Kakimasu(Canvas canvas, Graphics g)
  {
    _canvas = canvas;
    _g = g;
  }

  /// <summary>
  /// 線分
  /// </summary>
  /// <param name="p">１点目</param>
  /// <param name="p2">２点目</param>
  public void Line(PointD p, PointD p2)
  {
    PointF x = _canvas.ToScreen(p);
    PointF y = _canvas.ToScreen(p2);

    _g.DrawLine(Pens.Black, x, y);
  }

  /// <summary>
  /// 円-円周上の２点
  /// </summary>
  /// <param name="p">１点目</param>
  /// <param name="p2">２点目</param>
  public void TwoPointsCircle(PointD p, PointD p2)
  {
    double cx = (p.X + p2.X) / 2.0;
    double cy = (p.Y + p2.Y) / 2.0;
    PointD centerW = new PointD(cx, cy);
    double radius = Tools.PointDistance(p, p2) / 2.0;
    PointF center = _canvas.ToScreen(centerW);

    float r = (float)(_canvas.WorldToScreenLength(radius));

    float x = center.X - r;
    float y = center.Y - r;
    float w = r * 2;
    float h = r * 2;

    _g.DrawEllipse(Pens.Black, x, y, w, h); 
  }

  /// <summary>
  /// 円-中心点と円周上の点
  /// </summary>
  /// <param name="p">中心点</param>
  /// <param name="radius">半径</param>
  public void RadiusCircle(PointD p, double radius)
  {
    PointF center = _canvas.ToScreen(p);

    float r = (float)(radius * _canvas.Zoom);
    float x = center.X - r;
    float y = center.Y - r;
    float w = r * 2;
    float h = r * 2;

    _g.DrawEllipse(Pens.Black, x, y, w, h);
  }

  /// <summary>
  /// 矩形
  /// </summary>
  /// <param name="p">左上始点</param>
  /// <param name="p2">右下終点</param>
  public void Rectangle(PointD p, PointD p2)
  {
    float x = (float)Math.Min(p.X, p2.X);
    float y = (float)Math.Min(p.Y, p2.Y);
    float w = (float)Math.Abs(p.X - p2.X);
    float h = (float)Math.Abs(p.Y - p2.Y);
    RectangleF rect = new RectangleF(x, y, w, h);

    _g.DrawRectangle(Pens.Black, rect);
  }

  /// <summary>
  /// 円弧
  /// </summary>
  /// <param name="p">中心点</param>
  /// <param name="p2">半径</param>
  /// <param name="p3">開始角</param>
  /// <param name="p4">終了角</param>
  public void Arc(PointD p, PointD p2, PointD p3, PointD p4)
  {
    // 中心をスクリーン座標へ
    PointF c = _canvas.ToScreen(p);

    double r = _canvas.WorldToScreenLength(Tools.PointDistance(p, p2));

    float x = (float)(c.X - r);
    float y = (float)(c.Y - r);
    float w = (float)(r * 2);
    float h = (float)(r * 2);

    double startCad = Tools.GetAngle(p, p3);
    double endCad = Tools.GetAngle(p, p4);

    float startWin = (float)((360 - startCad) % 360);
    float endWin = (float)((360 - endCad) % 360);

    float sweepWin = endWin - startWin;
    if (sweepWin < 0) sweepWin += 360;

    _g.DrawArc(Pens.Black, x, y, w, h, startWin, sweepWin);
  }

  /// <summary>
  /// 定規
  /// </summary>
  /// <param name="p">始点</param>
  /// <param name="p2">終点</param>
  public void Ruler(PointD p, PointD p2)
  {
    PointF x = _canvas.ToScreen(p);
    PointF y = _canvas.ToScreen(p2);

    _g.DrawLine(Pens.Purple, x, y);
  }

  /// <summary>
  /// ラバーバンドでの丸表示-１個
  /// </summary>
  /// <param name="p">表示させたい座標</param>
  public void Circle(PointD p)
  {
    const double worldR = 2;
    // 中心をスクリーン座標へ
    PointF c = _canvas.ToScreen(p);
    // 半径をスクリーン距離へ
    float r = (float)_canvas.WorldToScreenLength(worldR);

    float x = c.X - r;
    float y = c.Y - r;
    float w = r * 2;
    float h = r * 2;

    _g.FillEllipse(Brushes.White, x, y, w, h);
    _g.DrawEllipse(Pens.Black, x, y, w, h);
  }

  /// <summary>
  /// ラバーバンドでの丸表示-２個
  /// </summary>
  /// <param name="p">表示させたい座標</param>
  /// <param name="p2">表示させたい座標</param>
  public void TwoCircles(PointD p, PointD p2)
  {
    Circle(p);
    Circle(p2);
  }

  /// <summary>
  /// ラバーバンドでの丸表示ー３個
  /// </summary>
  /// <param name="p">表示させたい座標</param>
  /// <param name="p2">表示させたい座標</param>
  /// <param name="p3">表示させたい座標</param>
  public void ThreeCircles(PointD p, PointD p2, PointD p3)
  {
    Circle(p);
    Circle(p2);
    Circle(p3);
  }

  /// <summary>
  /// ラバーバンドでの丸表示ー４個
  /// </summary>
  /// <param name="p">表示させたい座標</param>
  /// <param name="p2">表示させたい座標</param>
  /// <param name="p3">表示させたい座標</param>
  /// <param name="p4">表示させたい座標</param>
  public void FourCircles(PointD p, PointD p2, PointD p3, PointD p4)
  {
    Circle(p);
    Circle(p2);
    Circle(p3);
    Circle(p4);
  }

  /// <summary>
  /// 矩形
  /// </summary>
  /// <param name="p">左上の座標</param>
  /// <param name="p2">右上の座標</param>
  public void AddRect(PointD p, PointD p2)
  {
    Rect r = new Rect(p, p2);

    _g.DrawRectangle(Pens.Gray, r.ToRectangle(_canvas));
  }

  /// <summary>
  /// 文字の追加
  /// </summary>
  /// <param name="p"></param>
  /// <param name="p2"></param>
  public void AddString(PointD p, PointD p2)
  {
    double angle = Tools.GetAngle(p, p2);
    if (p.X == p2.X)
    {
      DrawLabel(p2, "垂直線");
    }
    else if (p.Y == p2.Y)
    {
      DrawLabel(p2, "水平線");
    }
    else if (Math.Abs(angle - 45) < 5)
    {
      DrawLabel(p2, "45度");
    }
    else if (Math.Abs(angle - 135) < 5)
    {
      DrawLabel(p2, "135度");
    }
    else if (Math.Abs(angle - 225) < 5)
    {
      DrawLabel(p2, "225度");
    }
    else if (Math.Abs(angle - 315) < 5)
    {
      DrawLabel(p2, "315度");
    }
  }

  /// <summary>
  /// ラベルを表示
  /// </summary>
  /// <param name="p"></param>
  /// <param name="a"></param>
  public void DrawLabel(PointD p, string a)
  {
    double x1 = p.X + 20;
    double y1 = p.Y + 20;
    double x2 = p.X + 20;
    double y2 = p.Y + 20;
    double x3 = p.X + 23;
    double y3 = p.Y + 25;
    PointF q = _canvas.ToScreen(new PointD(x1, y1));
    PointF q2 = _canvas.ToScreen(new PointD(x2, y2));
    PointF q3 = _canvas.ToScreen(new PointD(x3, y3));

    _g.DrawRectangle(Pens.Black, q.X, q.Y, 50, 20);
    _g.FillRectangle(Brushes.Pink, q2.X, q2.Y, 50, 20);
    _g.DrawString(a, new Font("MS ゴシック", 8), Brushes.Black, q3.X, q3.Y);
  }
}
