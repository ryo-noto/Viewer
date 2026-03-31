using Viewer.Utils;

namespace Viewer.Drawings;
/// <summary>
/// 矩形の描画
/// </summary>
internal class DrawRect : IAction
{
  private LayerManager _layers;
  private PointD _firstP, _secondP, _currentP;
  private Step _step = 0;
  public event Action<double, double> StartP, EndP, WidthHeight;
  public event Action StartDrawing;
  private enum Step
  {
    First,
    Second,
  }

  /// <summary>
  /// 左クリック
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnLeftClick(MouseEventArgs e, Canvas canvas)
  {
    switch (_step)
    {
      case Step.First:
        _firstP = canvas.ToWorld(PointD.GetLocation(e));
        StartDrawing?.Invoke();
        _step++;
        break;
      case Step.Second:
        _secondP = canvas.ToWorld(PointD.GetLocation(e));
        _layers.AddEntity(new Rect(_firstP, _secondP));
        _step--;
        break;
    }
  }

  /// <summary>
  /// 右クリック
  /// </summary>
  /// <param name="e"></param>
  public void OnRightClick(MouseEventArgs e)
  {
    _step--;
  }

  /// <summary>
  /// ペイント
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnPaint(PaintEventArgs e, Canvas canvas)
  {
    var k = new Kakimasu(canvas, e.Graphics);
    if (_step == Step.Second)
    {
      k.AddRect(_firstP, _currentP);
      k.TwoCircles(_firstP, _currentP);
    }
  }

  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  public void OnMouseMove(MouseEventArgs e, Canvas canvas)
  {
    _currentP = canvas.ToWorld(PointD.GetLocation(e));
    DisplayDistance();
  }

  private void DisplayDistance()
  {
    if (_step == Step.Second)
    {
      double startPointX = _firstP.X;
      double startPointY = _firstP.Y;
      double width = Math.Abs(Tools.Xdistance(_firstP, _currentP));
      double height = Math.Abs(Tools.Ydistance(_firstP, _currentP));
      WidthHeight?.Invoke(width, height);
      StartP?.Invoke(startPointX, startPointY);
    }
      double endPointX = _secondP.X;
      double endPointY = _secondP.Y;
  }

  /// <summary>
  /// レイヤー管理
  /// </summary>
  /// <param name="lm"></param>
  public void SetLayerManager(LayerManager lm)
  {
    _layers = lm;
  }
}
