namespace Viewer.Layers;
/// <summary>
/// レイヤー
/// </summary>
public class Layer
{
  /// <summary>レイヤーID</summary>
  public int Id { get; set; }
  /// <summary>レイヤーの名前</summary>
  public string Name { get; set; }
  /// <summary>可視化</summary>
  public bool Visible { get; set; } = true;
  /// <summary>ロック</summary>
  public bool Locked { get; set; } = false;
  /// <summary>色</summary>
  public Color Color { get; set; } = Color.Black;
  /// <summary>太さ</summary>
  public float Width { get; set; } = 0.13f;
  /// <summary>図形の種類</summary>
  public List<Shape> Entities { get; set; } = new();
}
