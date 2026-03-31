using Viewer.Utils;

namespace Viewer.Shapes;

  public abstract class Shape
{
  /// <summary>選択された図形</summary>
  public bool Selected { get; set; }

  /// <summary>
  /// 描画処理
  /// </summary>
  /// <param name="g">グラフィックス</param>
  /// <param name="color">色</param>
  /// <param name="size">太さ</param>
  public abstract void Draw(Graphics g, Canvas canvas, Color color, float size, float zoom);

  /// <summary>
  /// ヒット判定
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  /// <param name="p">クリック位置</param>
  /// <returns></returns>
  public abstract bool HitShape(Canvas canvas, PointD p);
}
