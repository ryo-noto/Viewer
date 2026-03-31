namespace Viewer;

  partial class Form1
  {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
          if (disposing && (components != null))
          {
              components.Dispose();
          }
          base.Dispose(disposing);
      }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    layerView = new DataGridView();
    colName = new DataGridViewTextBoxColumn();
    colVisible = new DataGridViewCheckBoxColumn();
    colLocked = new DataGridViewCheckBoxColumn();
    colColor = new DataGridViewButtonColumn();
    btnAddLayer = new Button();
    btnDeleteLayer = new Button();
    menuStrip1 = new MenuStrip();
    ファイルToolStripMenuItem = new ToolStripMenuItem();
    新規作成ToolStripMenuItem = new ToolStripMenuItem();
    編集ToolStripMenuItem = new ToolStripMenuItem();
    画像埋め込みToolStripMenuItem = new ToolStripMenuItem();
    設定ToolStripMenuItem = new ToolStripMenuItem();
    定規ToolStripMenuItem = new ToolStripMenuItem();
    定規ToolStripMenuItem1 = new ToolStripMenuItem();
    _panel = new Panel();
    labelInfo4 = new Label();
    labelInfo3 = new Label();
    labelInfo2 = new Label();
    labelInfo6 = new Label();
    label4 = new Label();
    labelInfo5 = new Label();
    labelInfo1 = new Label();
    colorBox = new ComboBox();
    widthBox = new ComboBox();
    panel1 = new Panel();
    label3 = new Label();
    label2 = new Label();
    label1 = new Label();
    tabPage1 = new TabPage();
    _canvas = new Canvas();
    tab = new TabControl();
    menuStrip2 = new MenuStrip();
    DmenuLines = new ToolStripMenuItem();
    DmenuLineSegment = new ToolStripMenuItem();
    DmenuPolyLine = new ToolStripMenuItem();
    DmenuCircles = new ToolStripMenuItem();
    DmenuCircle = new ToolStripMenuItem();
    DmenuTwoPointCircle = new ToolStripMenuItem();
    DmenuThreePointCircle = new ToolStripMenuItem();
    DmenuPolygon = new ToolStripMenuItem();
    DmenuTriangle = new ToolStripMenuItem();
    DmenuRectangle = new ToolStripMenuItem();
    DmenuArcs = new ToolStripMenuItem();
    DmenuArc = new ToolStripMenuItem();
    SolidFigures = new ToolStripMenuItem();
    DmenuTriangularPrism = new ToolStripMenuItem();
    DmenuTriangularPyramid = new ToolStripMenuItem();
    DmenuSelection = new ToolStripMenuItem();
    xAxis = new ToolStripStatusLabel();
    yAxis = new ToolStripStatusLabel();
    statusStrip1 = new StatusStrip();
    ((System.ComponentModel.ISupportInitialize)layerView).BeginInit();
    menuStrip1.SuspendLayout();
    _panel.SuspendLayout();
    panel1.SuspendLayout();
    tabPage1.SuspendLayout();
    tab.SuspendLayout();
    menuStrip2.SuspendLayout();
    statusStrip1.SuspendLayout();
    SuspendLayout();
    // 
    // layerView
    // 
    layerView.AllowUserToAddRows = false;
    layerView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    layerView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    layerView.Columns.AddRange(new DataGridViewColumn[] { colName, colVisible, colLocked, colColor });
    layerView.Location = new Point(0, 83);
    layerView.MultiSelect = false;
    layerView.Name = "layerView";
    layerView.RowHeadersVisible = false;
    layerView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    layerView.Size = new Size(263, 453);
    layerView.TabIndex = 4;
    layerView.CellValueChanged += layerView_CellValueChanged;
    layerView.CurrentCellDirtyStateChanged += layerView_CurrentCellDirtyStateChanged;
    // 
    // colName
    // 
    colName.HeaderText = "Name";
    colName.Name = "colName";
    colName.Width = 120;
    // 
    // colVisible
    // 
    colVisible.HeaderText = "Visible";
    colVisible.Name = "colVisible";
    colVisible.Width = 40;
    // 
    // colLocked
    // 
    colLocked.HeaderText = "Locked";
    colLocked.Name = "colLocked";
    colLocked.Resizable = DataGridViewTriState.True;
    colLocked.Width = 40;
    // 
    // colColor
    // 
    colColor.HeaderText = "Color";
    colColor.Name = "colColor";
    colColor.Width = 60;
    // 
    // btnAddLayer
    // 
    btnAddLayer.Location = new Point(12, 51);
    btnAddLayer.Name = "btnAddLayer";
    btnAddLayer.Size = new Size(41, 26);
    btnAddLayer.TabIndex = 5;
    btnAddLayer.Text = "追加";
    btnAddLayer.UseVisualStyleBackColor = true;
    btnAddLayer.Click += button4_Click;
    // 
    // btnDeleteLayer
    // 
    btnDeleteLayer.Location = new Point(59, 51);
    btnDeleteLayer.Name = "btnDeleteLayer";
    btnDeleteLayer.Size = new Size(39, 26);
    btnDeleteLayer.TabIndex = 6;
    btnDeleteLayer.Text = "削除";
    btnDeleteLayer.UseVisualStyleBackColor = true;
    btnDeleteLayer.Click += button5_Click;
    // 
    // menuStrip1
    // 
    menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, 編集ToolStripMenuItem, 設定ToolStripMenuItem, 定規ToolStripMenuItem });
    menuStrip1.Location = new Point(0, 0);
    menuStrip1.Name = "menuStrip1";
    menuStrip1.Size = new Size(984, 24);
    menuStrip1.TabIndex = 7;
    menuStrip1.Text = "menuStrip1";
    // 
    // ファイルToolStripMenuItem
    // 
    ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 新規作成ToolStripMenuItem });
    ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
    ファイルToolStripMenuItem.Size = new Size(53, 20);
    ファイルToolStripMenuItem.Text = "ファイル";
    // 
    // 新規作成ToolStripMenuItem
    // 
    新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
    新規作成ToolStripMenuItem.Size = new Size(122, 22);
    新規作成ToolStripMenuItem.Text = "新規作成";
    新規作成ToolStripMenuItem.Click += 新規作成ToolStripMenuItem_Click;
    // 
    // 編集ToolStripMenuItem
    // 
    編集ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 画像埋め込みToolStripMenuItem });
    編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
    編集ToolStripMenuItem.Size = new Size(43, 20);
    編集ToolStripMenuItem.Text = "編集";
    // 
    // 画像埋め込みToolStripMenuItem
    // 
    画像埋め込みToolStripMenuItem.Name = "画像埋め込みToolStripMenuItem";
    画像埋め込みToolStripMenuItem.Size = new Size(143, 22);
    画像埋め込みToolStripMenuItem.Text = "画像埋め込み";
    画像埋め込みToolStripMenuItem.Click += 画像埋め込みToolStripMenuItem_Click;
    // 
    // 設定ToolStripMenuItem
    // 
    設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
    設定ToolStripMenuItem.Size = new Size(43, 20);
    設定ToolStripMenuItem.Text = "設定";
    // 
    // 定規ToolStripMenuItem
    // 
    定規ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 定規ToolStripMenuItem1 });
    定規ToolStripMenuItem.Name = "定規ToolStripMenuItem";
    定規ToolStripMenuItem.Size = new Size(46, 20);
    定規ToolStripMenuItem.Text = "ツール";
    // 
    // 定規ToolStripMenuItem1
    // 
    定規ToolStripMenuItem1.Name = "定規ToolStripMenuItem1";
    定規ToolStripMenuItem1.Size = new Size(98, 22);
    定規ToolStripMenuItem1.Text = "定規";
    定規ToolStripMenuItem1.Click += 定規ToolStripMenuItem1_Click;
    // 
    // _panel
    // 
    _panel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    _panel.BackColor = Color.White;
    _panel.BorderStyle = BorderStyle.FixedSingle;
    _panel.Controls.Add(labelInfo4);
    _panel.Controls.Add(labelInfo3);
    _panel.Controls.Add(labelInfo2);
    _panel.Controls.Add(labelInfo6);
    _panel.Controls.Add(label4);
    _panel.Controls.Add(labelInfo5);
    _panel.Controls.Add(labelInfo1);
    _panel.Location = new Point(741, 83);
    _panel.Name = "_panel";
    _panel.Size = new Size(239, 153);
    _panel.TabIndex = 9;
    // 
    // labelInfo4
    // 
    labelInfo4.AutoSize = true;
    labelInfo4.Location = new Point(3, 55);
    labelInfo4.Name = "labelInfo4";
    labelInfo4.Size = new Size(12, 15);
    labelInfo4.TabIndex = 15;
    labelInfo4.Text = "*";
    // 
    // labelInfo3
    // 
    labelInfo3.AutoSize = true;
    labelInfo3.Location = new Point(3, 40);
    labelInfo3.Name = "labelInfo3";
    labelInfo3.Size = new Size(12, 15);
    labelInfo3.TabIndex = 14;
    labelInfo3.Text = "*";
    // 
    // labelInfo2
    // 
    labelInfo2.AutoSize = true;
    labelInfo2.Location = new Point(3, 25);
    labelInfo2.Name = "labelInfo2";
    labelInfo2.Size = new Size(12, 15);
    labelInfo2.TabIndex = 13;
    labelInfo2.Text = "*";
    // 
    // labelInfo6
    // 
    labelInfo6.AutoSize = true;
    labelInfo6.Location = new Point(3, 85);
    labelInfo6.Name = "labelInfo6";
    labelInfo6.Size = new Size(12, 15);
    labelInfo6.TabIndex = 12;
    labelInfo6.Text = "*";
    labelInfo6.Click += labelAngle_Click;
    // 
    // label4
    // 
    label4.AutoSize = true;
    label4.Location = new Point(3, 85);
    label4.Name = "label4";
    label4.Size = new Size(0, 15);
    label4.TabIndex = 11;
    // 
    // labelInfo5
    // 
    labelInfo5.AutoSize = true;
    labelInfo5.Location = new Point(3, 70);
    labelInfo5.Name = "labelInfo5";
    labelInfo5.Size = new Size(12, 15);
    labelInfo5.TabIndex = 10;
    labelInfo5.Text = "*";
    // 
    // labelInfo1
    // 
    labelInfo1.AutoSize = true;
    labelInfo1.Location = new Point(3, 10);
    labelInfo1.Name = "labelInfo1";
    labelInfo1.Size = new Size(12, 15);
    labelInfo1.TabIndex = 8;
    labelInfo1.Text = "*";
    // 
    // colorBox
    // 
    colorBox.FormattingEnabled = true;
    colorBox.Location = new Point(455, 51);
    colorBox.Name = "colorBox";
    colorBox.Size = new Size(121, 23);
    colorBox.TabIndex = 10;
    colorBox.SelectedIndexChanged += colorBox_SelectedIndexChanged;
    // 
    // widthBox
    // 
    widthBox.FormattingEnabled = true;
    widthBox.Location = new Point(582, 51);
    widthBox.Name = "widthBox";
    widthBox.Size = new Size(121, 23);
    widthBox.TabIndex = 11;
    widthBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
    // 
    // panel1
    // 
    panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
    panel1.BackColor = Color.White;
    panel1.BorderStyle = BorderStyle.FixedSingle;
    panel1.Controls.Add(label3);
    panel1.Controls.Add(label2);
    panel1.Controls.Add(label1);
    panel1.Location = new Point(741, 242);
    panel1.Name = "panel1";
    panel1.Size = new Size(239, 294);
    panel1.TabIndex = 12;
    // 
    // label3
    // 
    label3.AutoSize = true;
    label3.Location = new Point(13, 62);
    label3.Name = "label3";
    label3.Size = new Size(38, 15);
    label3.TabIndex = 2;
    label3.Text = "label3";
    // 
    // label2
    // 
    label2.AutoSize = true;
    label2.Location = new Point(13, 37);
    label2.Name = "label2";
    label2.Size = new Size(38, 15);
    label2.TabIndex = 1;
    label2.Text = "label2";
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Location = new Point(14, 11);
    label1.Name = "label1";
    label1.Size = new Size(38, 15);
    label1.TabIndex = 0;
    label1.Text = "label1";
    // 
    // tabPage1
    // 
    tabPage1.Controls.Add(_canvas);
    tabPage1.Location = new Point(4, 24);
    tabPage1.Name = "tabPage1";
    tabPage1.Padding = new Padding(3);
    tabPage1.Size = new Size(458, 426);
    tabPage1.TabIndex = 0;
    tabPage1.Text = "tabPage1";
    tabPage1.UseVisualStyleBackColor = true;
    // 
    // _canvas
    // 
    _canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    _canvas.BackColor = SystemColors.Window;
    _canvas.BorderStyle = BorderStyle.FixedSingle;
    _canvas.Location = new Point(0, 0);
    _canvas.Name = "_canvas";
    _canvas.OffsetX = 1F;
    _canvas.Size = new Size(458, 426);
    _canvas.TabIndex = 0;
    _canvas.Zoom = 1F;
    // 
    // tab
    // 
    tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    tab.Controls.Add(tabPage1);
    tab.Location = new Point(269, 83);
    tab.Name = "tab";
    tab.SelectedIndex = 0;
    tab.Size = new Size(466, 454);
    tab.TabIndex = 14;
    tab.SelectedIndexChanged += tab_SelectedIndexChanged;
    // 
    // menuStrip2
    // 
    menuStrip2.AutoSize = false;
    menuStrip2.Dock = DockStyle.None;
    menuStrip2.Items.AddRange(new ToolStripItem[] { DmenuLines, DmenuCircles, DmenuPolygon, DmenuArcs, SolidFigures, DmenuSelection });
    menuStrip2.Location = new Point(0, 24);
    menuStrip2.Name = "menuStrip2";
    menuStrip2.Size = new Size(342, 24);
    menuStrip2.TabIndex = 20;
    menuStrip2.Text = "menuStrip2";
    // 
    // DmenuLines
    // 
    DmenuLines.DropDownItems.AddRange(new ToolStripItem[] { DmenuLineSegment, DmenuPolyLine });
    DmenuLines.Image = Properties.Resources.icons8_line_29;
    DmenuLines.Name = "DmenuLines";
    DmenuLines.Size = new Size(59, 20);
    DmenuLines.Text = "線分";
    // 
    // DmenuLineSegment
    // 
    DmenuLineSegment.Image = Properties.Resources.icons8_line_29;
    DmenuLineSegment.Name = "DmenuLineSegment";
    DmenuLineSegment.Size = new Size(110, 22);
    DmenuLineSegment.Text = "線分";
    DmenuLineSegment.Click += 線分ToolStripMenuItem1_Click;
    // 
    // DmenuPolyLine
    // 
    DmenuPolyLine.Image = Properties.Resources.icons8_polyline_29;
    DmenuPolyLine.Name = "DmenuPolyLine";
    DmenuPolyLine.Size = new Size(110, 22);
    DmenuPolyLine.Text = "連続線";
    DmenuPolyLine.Click += 連続線ToolStripMenuItem_Click;
    // 
    // DmenuCircles
    // 
    DmenuCircles.DropDownItems.AddRange(new ToolStripItem[] { DmenuCircle, DmenuTwoPointCircle, DmenuThreePointCircle });
    DmenuCircles.Image = Properties.Resources.icons8_circle_29;
    DmenuCircles.Name = "DmenuCircles";
    DmenuCircles.Size = new Size(47, 20);
    DmenuCircles.Text = "円";
    // 
    // DmenuCircle
    // 
    DmenuCircle.Image = Properties.Resources.icons8_circle_29;
    DmenuCircle.Name = "DmenuCircle";
    DmenuCircle.Size = new Size(110, 22);
    DmenuCircle.Text = "円";
    DmenuCircle.Click += 円ToolStripMenuItem1_Click;
    // 
    // DmenuTwoPointCircle
    // 
    DmenuTwoPointCircle.Name = "DmenuTwoPointCircle";
    DmenuTwoPointCircle.Size = new Size(110, 22);
    DmenuTwoPointCircle.Text = "２点円";
    DmenuTwoPointCircle.Click += 点円ToolStripMenuItem_Click;
    // 
    // DmenuThreePointCircle
    // 
    DmenuThreePointCircle.Name = "DmenuThreePointCircle";
    DmenuThreePointCircle.Size = new Size(110, 22);
    DmenuThreePointCircle.Text = "３点円";
    DmenuThreePointCircle.Click += 点円ToolStripMenuItem1_Click;
    // 
    // DmenuPolygon
    // 
    DmenuPolygon.DropDownItems.AddRange(new ToolStripItem[] { DmenuTriangle, DmenuRectangle });
    DmenuPolygon.Image = Properties.Resources.icons8_triangle_29;
    DmenuPolygon.Name = "DmenuPolygon";
    DmenuPolygon.Size = new Size(71, 20);
    DmenuPolygon.Text = "多角形";
    // 
    // DmenuTriangle
    // 
    DmenuTriangle.Image = Properties.Resources.icons8_triangle_29;
    DmenuTriangle.Name = "DmenuTriangle";
    DmenuTriangle.Size = new Size(110, 22);
    DmenuTriangle.Text = "三角形";
    DmenuTriangle.Click += 三角形ToolStripMenuItem_Click;
    // 
    // DmenuRectangle
    // 
    DmenuRectangle.Image = Properties.Resources.icons8_rectangular_29;
    DmenuRectangle.Name = "DmenuRectangle";
    DmenuRectangle.Size = new Size(110, 22);
    DmenuRectangle.Text = "矩形";
    DmenuRectangle.Click += 矩形ToolStripMenuItem2_Click;
    // 
    // DmenuArcs
    // 
    DmenuArcs.DropDownItems.AddRange(new ToolStripItem[] { DmenuArc });
    DmenuArcs.Name = "DmenuArcs";
    DmenuArcs.Size = new Size(43, 20);
    DmenuArcs.Text = "円弧";
    // 
    // DmenuArc
    // 
    DmenuArc.Name = "DmenuArc";
    DmenuArc.Size = new Size(98, 22);
    DmenuArc.Text = "円弧";
    DmenuArc.Click += 円弧ToolStripMenuItem1_Click;
    // 
    // SolidFigures
    // 
    SolidFigures.DropDownItems.AddRange(new ToolStripItem[] { DmenuTriangularPrism, DmenuTriangularPyramid });
    SolidFigures.Name = "SolidFigures";
    SolidFigures.Size = new Size(67, 20);
    SolidFigures.Text = "立体図形";
    // 
    // DmenuTriangularPrism
    // 
    DmenuTriangularPrism.Name = "DmenuTriangularPrism";
    DmenuTriangularPrism.Size = new Size(110, 22);
    DmenuTriangularPrism.Text = "三角柱";
    DmenuTriangularPrism.Click += 三角柱ToolStripMenuItem_Click;
    // 
    // DmenuTriangularPyramid
    // 
    DmenuTriangularPyramid.Name = "DmenuTriangularPyramid";
    DmenuTriangularPyramid.Size = new Size(110, 22);
    DmenuTriangularPyramid.Text = "三角錐";
    DmenuTriangularPyramid.Click += 三角錐ToolStripMenuItem_Click;
    // 
    // DmenuSelection
    // 
    DmenuSelection.Name = "DmenuSelection";
    DmenuSelection.Size = new Size(43, 20);
    DmenuSelection.Text = "選択";
    DmenuSelection.Click += DmenuSelection_Click;
    // 
    // xAxis
    // 
    xAxis.Name = "xAxis";
    xAxis.Size = new Size(17, 17);
    xAxis.Text = "X:";
    // 
    // yAxis
    // 
    yAxis.Name = "yAxis";
    yAxis.Size = new Size(16, 17);
    yAxis.Text = "Y:";
    // 
    // statusStrip1
    // 
    statusStrip1.BackColor = Color.Ivory;
    statusStrip1.Items.AddRange(new ToolStripItem[] { xAxis, yAxis });
    statusStrip1.Location = new Point(0, 539);
    statusStrip1.Name = "statusStrip1";
    statusStrip1.Size = new Size(984, 22);
    statusStrip1.TabIndex = 8;
    statusStrip1.Text = "statusStrip1";
    // 
    // Form1
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    BackColor = SystemColors.InactiveCaption;
    ClientSize = new Size(984, 561);
    Controls.Add(tab);
    Controls.Add(panel1);
    Controls.Add(widthBox);
    Controls.Add(colorBox);
    Controls.Add(_panel);
    Controls.Add(statusStrip1);
    Controls.Add(btnDeleteLayer);
    Controls.Add(btnAddLayer);
    Controls.Add(layerView);
    Controls.Add(menuStrip1);
    Controls.Add(menuStrip2);
    MainMenuStrip = menuStrip1;
    Name = "Form1";
    Text = "Form1";
    Load += Form1_Load;
    ((System.ComponentModel.ISupportInitialize)layerView).EndInit();
    menuStrip1.ResumeLayout(false);
    menuStrip1.PerformLayout();
    _panel.ResumeLayout(false);
    _panel.PerformLayout();
    panel1.ResumeLayout(false);
    panel1.PerformLayout();
    tabPage1.ResumeLayout(false);
    tab.ResumeLayout(false);
    menuStrip2.ResumeLayout(false);
    menuStrip2.PerformLayout();
    statusStrip1.ResumeLayout(false);
    statusStrip1.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion
  private DataGridView layerView;
  private DataGridViewTextBoxColumn colName;
  private DataGridViewCheckBoxColumn colVisible;
  private DataGridViewCheckBoxColumn colLocked;
  private DataGridViewButtonColumn colColor;
  private Button btnAddLayer;
  private Button btnDeleteLayer;
  private MenuStrip menuStrip1;
  private ToolStripMenuItem ファイルToolStripMenuItem;
  private ToolStripMenuItem 編集ToolStripMenuItem;
  private ToolStripMenuItem 設定ToolStripMenuItem;
  private Panel _panel;
  private Label labelYdistance;
  private Label labelXdistance;
  private Label labelEndPoint;
  private Label labelInfo1;
  private Label labelInfo5;
  private ComboBox colorBox;
  private ComboBox widthBox;
  private ToolStripMenuItem 画像埋め込みToolStripMenuItem;
  private Panel panel1;
  private Label label3;
  private Label label2;
  private Label label1;
  private ToolStripMenuItem 新規作成ToolStripMenuItem;
  private TabPage tabPage1;
  private Canvas _canvas;
  private TabControl tab;
  private Label label4;
  private Label labelInfo6;
  private MenuStrip menuStrip2;
  private ToolStripMenuItem DmenuLines;
  private ToolStripMenuItem DmenuLineSegment;
  private ToolStripMenuItem DmenuCircles;
  private ToolStripMenuItem DmenuCircle;
  private ToolStripMenuItem DmenuTwoPointCircle;
  private ToolStripMenuItem DmenuThreePointCircle;
  private ToolStripMenuItem DmenuPolygon;
  private ToolStripMenuItem DmenuTriangle;
  private ToolStripMenuItem DmenuRectangle;
  private ToolStripMenuItem SolidFigures;
  private ToolStripMenuItem DmenuTriangularPrism;
  private ToolStripMenuItem DmenuTriangularPyramid;
  private ToolStripStatusLabel xAxis;
  private ToolStripStatusLabel yAxis;
  private StatusStrip statusStrip1;
  private ToolStripMenuItem DmenuArcs;
  private ToolStripMenuItem DmenuArc;
  private ToolStripMenuItem DmenuPolyLine;
  private ToolStripMenuItem DmenuSelection;
  private Label labelInfo3;
  private Label labelInfo2;
  private Label labelInfo4;
  private ToolStripMenuItem 定規ToolStripMenuItem;
  private ToolStripMenuItem 定規ToolStripMenuItem1;
  private ToolStripButton toolStripButton1;
  private ToolStripButton toolZoomOut;
  private ToolStripButton toolStripButton3;
  private ToolStripButton toolStripButton4;
}
