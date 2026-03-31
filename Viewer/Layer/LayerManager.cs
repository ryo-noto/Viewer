namespace Viewer.Layers;
/// <summary>
/// レイヤー管理
/// </summary>
   public class LayerManager
  {
  // 全レイヤーを保持するリスト
  private readonly List<Layer> _layers = new();
  // 現在選択中のレイヤー新しく描く図形はここに入る。
  public Layer CurrentLayer { get; private set; } // 今どの紙に描くか決める

  public Layer CreateLayer(string name) // 新しい紙を配る
  {
    // 既存レイヤー数+1をIDにして、新しいLayerインスタンスを作成。
    var layer = new Layer
    {
      Id = _layers.Count + 1, // 既存レイヤー数+1をIDにして、新しいLayerインスタンスを作成
      Name = name
    };
    // レイヤー一覧に追加
    _layers.Add(layer);
    // 最初のレイヤーが作られた時、それを「現在のレイヤー」にする
    if (CurrentLayer == null)
      CurrentLayer = layer;

    return layer;
  }
  // IDを指定して、現在のレイヤーを切り替える。
  public void SetCurrentLayer(int id) // 紙を切り替える
  {
    CurrentLayer = _layers.First(l => l.Id == id);
  }
  // レイヤー一覧を外部に渡すためのメソッド。UI表示などに使う。
  public IEnumerable<Layer> GetLayers() => _layers;

  /// <summary>
  /// 図形の追加
  /// </summary>
  /// <param name="shape"></param>
  public void AddEntity(Shape shape) // 紙に絵を追加する
  {
    if (CurrentLayer.Locked)
    {
      return;
    }
    CurrentLayer.Entities.Add(shape);
  }
  /// <summary>
  /// レイヤーの削除
  /// </summary>
  /// <param name="id"></param>
  public void DeleteLayer(int id) // 紙を片づける
  {
    var layer = _layers.FirstOrDefault(l => l.Id == id);
    if (layer == null)
    {
      return;
    }

    // 削除
    _layers.Remove(layer);

    // CurrentLayerが削除された場合の処理
    if (CurrentLayer == layer)
    {
      // まだレイヤーが残っていれば先頭を選ぶ
      CurrentLayer = _layers.FirstOrDefault();
    }

    // IDをふり直す(任意)
    int index = 1;
    foreach (var l in _layers)
    {
      l.Id = index++;
    }
  }

  public void Clear() // 紙を全部捨てる
  {
    _layers.Clear();
    CurrentLayer = null;
  }
  }

