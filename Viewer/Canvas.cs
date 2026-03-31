using System.ComponentModel.Design;
using Viewer.Utils;

namespace Viewer;

public partial class Canvas : UserControl
{
  private IAction _currentAction;
  public event Action LayerChanged, StartDrawingFromAction;
  internal event Action<PointD> MouseMoved;
  public event Action<double, double> InfoXy1, InfoXy2, InfoXy3;
  public event Action<double> InfoDouble1, InfoDouble2, InfoDouble3;
  public event Action<double, double, double, double>? RulerMeasured;
  public event Action<IAction>? ActionChanged;
  public double WorldHeight => Height / Zoom;

  internal LayerManager Layers { get; private set; }

  public float Zoom { get; set; } = 1.0f;

  public float OffsetX { get; set; } = 1.0f;

  public PointF ToScreen(PointD p)
  {
    return new PointF((float)(p.X * Zoom), (float)(p.Y * Zoom));
  }

  public double WorldToScreenLength(double worldLength)
  {
    return worldLength * Zoom;
  }

  /// <summary>
  /// コンストラクタ
  /// </summary>
  public Canvas()
  {
    InitializeComponent();

    this.DoubleBuffered = true;

    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    this.SetStyle(ControlStyles.UserPaint, true);
    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    this.SetStyle(ControlStyles.ResizeRedraw, true);
    this.UpdateStyles();
  }

  /// <summary>
  /// クラス呼び出し
  /// </summary>
  /// <param name="action"></param>
  public void SetAction(IAction action)
  {
    _currentAction = action;
    action.SetLayerManager(Layers);
    ActionChanged?.Invoke(action);

    if (action is DrawLine dl)
    {
      dl.Distance += (dx, dy) => InfoXy3?.Invoke(dx, dy);
      dl.StartP += (startPointX, startPointY) => InfoXy1?.Invoke(startPointX, startPointY);
      dl.EndP += (endPointX, endPointY) => InfoXy2?.Invoke(endPointX, endPointY);
      dl.DistanceFromStart += (distanceFromStart) => InfoDouble1?.Invoke(distanceFromStart);
      dl.StartDrawing += () => StartDrawingFromAction?.Invoke();
      dl.Angle += (angle) => InfoDouble2?.Invoke(angle);
    }
    else if (action is DrawRect dr)
    {
      dr.WidthHeight += (width, height) => InfoXy3?.Invoke(width, height);
      dr.StartP += (startPointX, startPointY) => InfoXy1?.Invoke(startPointX, startPointY);
      dr.EndP += (endPointX, endPointY) => InfoXy2?.Invoke(endPointX, endPointY);
      dr.StartDrawing += () => StartDrawingFromAction?.Invoke();
    }
    else if (action is DrawCircle cl)
    {
      cl.StartP += (startPointX, startPointY) => InfoXy1?.Invoke(startPointX, startPointY);
      cl.Radius += (distanceFromStart) => InfoDouble1?.Invoke(distanceFromStart);
      cl.Diameter += (diameter) => InfoDouble2?.Invoke(diameter);
      cl.StartDrawing += () => StartDrawingFromAction?.Invoke();
    }
    else if (action is DrawTwoPointCircle d2pc)
    {
      d2pc.StartP += (startPointX, startPointY) => InfoXy1?.Invoke(startPointX, startPointY);
      d2pc.Diameter += (diameter) => InfoDouble1?.Invoke(diameter);
      d2pc.Radius += (radius) => InfoDouble2?.Invoke(radius);
      d2pc.StartDrawing += () => StartDrawingFromAction?.Invoke();
    }
    else if (action is DrawArc da)
    {
      da.CenterP += (centerPx, centerPy) => InfoXy1?.Invoke(centerPx, centerPy);
      da.Radius += (radius) => InfoDouble1?.Invoke(radius);
      da.StartA += (startA) => InfoDouble2?.Invoke(startA);
      da.EndA += (endA) => InfoDouble3?.Invoke(endA);
    }
    else if (action is DrawTriangle dt)
    {
      dt.StartP += (startPx, startPy) => InfoXy1?.Invoke(startPx, startPy);
      dt.SecondP += (secondPx, secondPy) => InfoXy2?.Invoke(secondPx, secondPy);
      dt.EndP += (endPx, endPy) => InfoXy3?.Invoke(endPx, endPy);
    }
    else if (action is Ruler r)
    {
      r.Measured = null;
      r.Measured += (dx, dy, distance, angle) =>
      {
        RulerMeasured?.Invoke(dx, dy, distance, angle);
      };
    }
    else if (action is DrawThreePointCircle d3pc)
    {
      d3pc.StartP += (startPx, startPy) => InfoXy1?.Invoke(startPx, startPy);
      d3pc.SecondP += (secondPx, secondPy) => InfoXy2?.Invoke(secondPx, secondPy);
      d3pc.Diameter += (diameter) => InfoDouble1?.Invoke(diameter);
      d3pc.Radius += (radius) => InfoDouble2?.Invoke(radius);
      d3pc.StartDrawing += () => StartDrawingFromAction?.Invoke();
    }
  }

  /// <summary>
  /// マウスクリック時の処理
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void Canvas_MouseDown(object sender, MouseEventArgs e)
  {
    if (_currentAction == null)
    {
      return;
    }

    if (e.Button == MouseButtons.Left)
    {
      _currentAction.OnLeftClick(e, this);
    }
    Invalidate();
  }
  /// <summary>
  /// ペイント
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void Canvas_Paint(object sender, PaintEventArgs e)
  {
    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    foreach (var layer in Layers.GetLayers())
    {
      if (!layer.Visible) // このレイヤーが非表示なら、このレイヤーの処理をスキップいて次のレイヤーへ進む
      {
        continue;
      }

      foreach (var s in layer.Entities)
      {
        s.Draw(e.Graphics, this, layer.Color, layer.Width, Zoom);
        //s.Vertex(e.Graphics);
      }
    }
    
    if (_currentAction != null)
    {
      _currentAction.OnPaint(e, this);
    }

    var rect = this.ClientRectangle;
    rect.Width -= 1;
    rect.Height -= 1;
    using var pen = new Pen(Color.Gray, 1);
    e.Graphics.DrawRectangle(pen, rect);
  }
  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void Canvas_MouseMove(object sender, MouseEventArgs e)
  {
    if (_currentAction != null)
    {
      _currentAction.OnMouseMove(e, this);
    }

    var world = ToWorld(PointD.GetLocation(e));
    MouseMoved?.Invoke(world);

    Invalidate();
  }

  /// <summary>
  /// ワールド座標
  /// </summary>
  /// <param name="p"></param>
  /// <returns></returns>
  internal PointD ToWorld(PointD p)
  {
    return new PointD(p.X / Zoom, p.Y / Zoom);
  }

  internal void SetLayerManager(LayerManager lm) => Layers = lm;
}
