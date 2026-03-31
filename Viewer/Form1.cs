using Microsoft.Win32;
using Viewer.Utils;

namespace Viewer;

public partial class Form1 : Form
{
  private Dictionary<TabPage, LayerManager> _layerManagers = new();
  private Canvas _activeCanvas;
  public Form1()
  {
    InitializeComponent();
    layerView.AutoGenerateColumns = false;
    InitialValue();
    // ★最初のタブ用Layermanagerを作る
    var lm = new LayerManager();
    var layer = lm.CreateLayer("Layer1");
    lm.SetCurrentLayer(layer.Id);
    _canvas.SetLayerManager(lm);
    _activeCanvas = _canvas;
    BindCanvasEvents(_canvas);
    RulerEvents(_canvas);
    RefreshLayerGrid();
    _canvas.Cursor = Cursors.Cross;
  }

  /// <summary>
  /// ボタン-円
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 円ToolStripMenuItem1_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawCircle());
  }

  /// <summary>
  /// ボタン-２点円
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 点円ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawTwoPointCircle());
  }
  /// <summary>
  /// ボタン-点
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 点円ToolStripMenuItem1_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawThreePointCircle());
  }

  /// <summary>
  /// ボタン-線分
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 線分ToolStripMenuItem1_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawLine());
  }

  /// <summary>
  /// ボタン-矩形
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 矩形ToolStripMenuItem2_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawRect());
  }
  /// <summary>
  /// ボタン-三角形
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 三角形ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawTriangle());
  }

  /// <summary>
  /// ボタン-三角柱
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 三角柱ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawTriangularPyramid());
  }

  /// <summary>
  /// ボタン-三角錐
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 三角錐ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawTriangularPrism());
  }

  /// <summary>
  /// ボタン-円弧
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 円弧ToolStripMenuItem1_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawArc());
  }

  /// <summary>
  /// ボタン-連続線
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 連続線ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    ResetAllLabels();
    _activeCanvas.SetAction(new DrawPolyline());
  }

  /// <summary>
  /// ボタン-選択
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void DmenuSelection_Click(object sender, EventArgs e)
  {
    _activeCanvas.SetAction(new Selection(_activeCanvas));
  }

  /// <summary>
  /// ボタン-定規
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 定規ToolStripMenuItem1_Click(object sender, EventArgs e)
  {
    _activeCanvas.SetAction(new Ruler());
  }

  /// <summary>
  /// ボタン-拡大
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void toolStripButton1_Click(object sender, EventArgs e)
  {
    _activeCanvas.Zoom *= 1.25f;
    _activeCanvas.Invalidate();
  }

  /// <summary>
  /// ボタン-縮小
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void toolStripButton2_Click(object sender, EventArgs e)
  {
    _activeCanvas.Zoom /= 1.25f;
    _activeCanvas.Invalidate();
  }

  private void RefreshLayerGrid()
  {
    layerView.Rows.Clear();
    foreach (var layer in _activeCanvas.Layers.GetLayers())
    {
      layerView.Rows.Add(layer.Name, layer.Visible, layer.Locked, layer.Color);
    }
  }

  /// <summary>
  /// ロード
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void Form1_Load(object sender, EventArgs e)
  {
    RefreshLayerGrid();
  }

  /// <summary>
  /// レイヤー選択
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void layerView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
  {
    // ヘッダー行だったら無視してねという意味（列名のところ）は-1だから
    if (e.RowIndex < 0)
    {
      return;
    }
    // ユーザーが触った行をrowに代入
    var row = layerView.Rows[e.RowIndex];
    // その行に対応するレイヤーを取り出す
    var layer = _activeCanvas.Layers.GetLayers().ElementAt(e.RowIndex);
    // 表のチェックボックスの状態を、レイヤーのVisibleにコピーする
    layer.Visible = Convert.ToBoolean(row.Cells["colVisible"].Value);
    // 表のLockedのチェック状態をレイヤーに反映している。
    layer.Locked = Convert.ToBoolean(row.Cells["colLocked"].Value);
    // キャンバスを書き直して
    _activeCanvas.Invalidate();
  }
  private void layerView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
  {
    if (layerView.IsCurrentCellDirty)
    {
      layerView.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
  }

  /// <summary>
  /// ボタン-レイヤー追加
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void button4_Click(object sender, EventArgs e)
  {
    // 新しいレイヤー名を自動生成
    string name = "Layer" + (_activeCanvas.Layers.GetLayers().Count() + 1);
    var newLayer = _activeCanvas.Layers.CreateLayer(name);
    // 新しいレイヤーを現在のレイヤーにする
    _activeCanvas.Layers.SetCurrentLayer(newLayer.Id);
    // UI を更新
    RefreshLayerGrid();
    layerView.CurrentCell = layerView.Rows[layerView.Rows.Count - 1].Cells[0];
    // Canvasを再描画
    _activeCanvas.Invalidate();
  }

  /// <summary>
  /// ボタン-削除
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void button5_Click(object sender, EventArgs e)
  {
    if (layerView.CurrentRow == null)
    {
      return;
    }
    int rowIndex = layerView.CurrentRow.Index;
    int layerId = rowIndex + 1;
    _activeCanvas.Layers.DeleteLayer(layerId);
    RefreshLayerGrid();
    _activeCanvas.Invalidate();
  }
  private void InitialValue()
  {
    labelInfo1.Text = "";
    labelInfo2.Text = "";
    labelInfo3.Text = "";
    labelInfo4.Text = "";
    labelInfo5.Text = "";
    labelInfo6.Text = "";
    // 色の設定
    Color[] colors = new Color[]
  {
        Color.Black,
        Color.Red,
        Color.Green,
        Color.Blue,
        Color.Yellow,
        Color.Orange,
  };
    foreach (var c in colors)
    {
      colorBox.Items.Add(c);
    }
    // 起動した時はBlack
    colorBox.SelectedItem = Color.Black;
    // 太さの設定
    float[] width = new float[]
    {
      0.13f,
      0.18f,
      0.25f,
      0.35f,
      0.50f,
      0.70f,
      1.00f,
      1.40f,
      2.00f,
      0.40f,
      0.60f,
      0.80f,
      0.90f,
      1.58f,
      2.11f,
    };
    foreach (var w in width)
    {
      widthBox.Items.Add(w);
    }
    widthBox.SelectedItem = 0.13f;
  }

  /// <summary>
  /// ボックス-色変更
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (_activeCanvas == null)
    {
      return;
    }
    if (colorBox.SelectedItem is Color selectedColor)
    {
      _activeCanvas.Layers.CurrentLayer.Color = selectedColor;
      _activeCanvas.Invalidate();
    }
  }

  /// <summary>
  /// ボックス-線の太さ
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (widthBox.SelectedItem is float width)
    {
      if (_activeCanvas == null)
      {
        return;
      }
      _activeCanvas.Layers.CurrentLayer.Width = width;
      _activeCanvas.Invalidate();
    }
  }

  /// <summary>
  /// ボタン-画像埋め込み
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 画像埋め込みToolStripMenuItem_Click(object sender, EventArgs e)
  {
    using var dlg = new OpenFileDialog();
    dlg.Filter = "画像ファイル|*.png;*.jpg;*.jpeg;*.bmp";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
      var img = Image.FromFile(dlg.FileName);
      // 最後に書いた矩形に画像をセットする例
      var rect = _activeCanvas.Layers.CurrentLayer.Entities.Last() as Rect;
      if (rect != null)
      {
        rect.Image = img;
        _activeCanvas.Invalidate();
      }
    }
  }

  /// <summary>
  /// ボタン-新規作成
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
  {
    // LayerManagerのインスタンスを作成
    var lm = new LayerManager();
    // レイヤー1を作成
    var layer = lm.CreateLayer("Layer1");
    // 現在のレイヤーを切り替える
    lm.SetCurrentLayer(layer.Id);
    // Canvasのインスタンスを作成
    var newCanvas = new Canvas();
    var panel = new Panel();
    //　今後新しく描く図形がこのレイヤーに入れる
    newCanvas.SetLayerManager(lm);
    // ★まず newCanvas にイベントを紐づける
    BindCanvasEvents(newCanvas);
    //タブページを追加する（ユーザーコントロールではない）
    var page = new TabPage("図面" + (tab.TabPages.Count + 1));
    // 作ったタブページにnewCanvasを追加
    page.Controls.Add(newCanvas);
    newCanvas.Dock = DockStyle.Fill;
    newCanvas.BackColor = Color.White;
    _layerManagers[page] = lm;
    // _activeCanvasにnewCanvasを追加
    _activeCanvas = newCanvas;
    // タブに追加
    tab.TabPages.Add(page);
    tab.SelectedTab = page;
    page.Controls.Add(panel);
    RefreshLayerGrid();
  }

  private void BindCanvasEvents(Canvas canvas)
  {
    canvas.ActionChanged += action =>
    {
      if (action is DrawLine)
        BindLineEvents(canvas);
      else if (action is DrawCircle)
        BindCircleEvents(canvas);
      else if (action is DrawTwoPointCircle)
        BindTwoPointCircle(canvas);
      else if (action is DrawArc)
        BindArcEvents(canvas);
      else if (action is DrawRect)
        BindRectEvents(canvas);
      else if (action is DrawTriangle)
        BindTriangleEvents(canvas);
      else if (action is DrawThreePointCircle)
        BindThreePointCircle(canvas);
    };
    canvas.MouseMoved += p =>
    {
      xAxis.Text = $"X:{p.X}";
      yAxis.Text = $"Y:{p.Y}";
    };
  }

  /// <summary>
  /// タブのインデックスチェンジ
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void tab_SelectedIndexChanged(object sender, EventArgs e)
  {
    _activeCanvas = tab.SelectedTab?.Controls[0] as Canvas;
  }

  private void labelAngle_Click(object sender, EventArgs e)
  {
  }

  private void toolStripButton4_Click(object sender, EventArgs e)
  {

  }

  private Canvas ActiveCanvas
  {
    get
    {
      return tab.SelectedTab?.Controls[0] as Canvas;
    }
  }
}
