namespace Viewer;

public partial class Form1
{
  /// <summary>
  /// 線分の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindLineEvents(Canvas canvas)
  {
    canvas.InfoXy1 += (startPointX, startPointY) =>
    {
      labelInfo1.Text = $"始点: {startPointX}, {startPointY}";
    };
    canvas.InfoXy2 += (endPointX, endPointY) =>
    {
      labelInfo2.Text = $"終点: {endPointX}, {endPointY}";
    };
    canvas.InfoXy3 += (dx, dy) =>
    {
      labelInfo3.Text = $"Xの距離: " + dx.ToString();
      labelInfo4.Text = $"Yの距離: " + dy.ToString();
    };
    canvas.InfoDouble1 += (distanceFromStart) =>
    {
      labelInfo5.Text = $"始点からの距離: {distanceFromStart}";
    };
    canvas.InfoDouble2 += (angle) =>
    {
      labelInfo6.Text = $"角度: {angle}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = true;
      labelInfo5.Visible = true;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// 矩形の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindRectEvents(Canvas canvas)
  {
    canvas.InfoXy1 += (startPointX, startPointY) =>
    {
      labelInfo1.Text = $"始点: {startPointX}, {startPointY}";
    };
    canvas.InfoXy2 += (endPointX, endPointY) =>
    {
      labelInfo2.Text = $"終点: {endPointX}, {endPointY}";
    };
    canvas.InfoXy3 += (width, height) =>
    {
      labelInfo3.Text = $"幅: {width}　高さ: {height}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      ResetAllLabels();
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = false;
      labelInfo5.Visible = false;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// 円の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindCircleEvents(Canvas canvas)
  {
    canvas.InfoXy1 += (startPointX, startPointY) =>
    {
      labelInfo1.Text = $"中心点: {startPointX}, {startPointY}";
    };
    canvas.InfoDouble1 += (distanceFromStart) =>
    {
      labelInfo2.Text = $"半径: {distanceFromStart}";
    };
    canvas.InfoDouble2 += (diameter) =>
    {
      labelInfo3.Text = $"直径: {diameter}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = false;
      labelInfo5.Visible = false;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// 円弧の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindArcEvents(Canvas canvas)
  {
    canvas.InfoXy1 += (centerPx, centerPy) =>
    {
      labelInfo1.Text = $"中心点: {centerPx}, {centerPy}";
    };
    canvas.InfoDouble1 += (radius) =>
    {
      labelInfo2.Text = $"半径: {radius}";
    };
    canvas.InfoDouble2 += (startA) =>
    {
      labelInfo3.Text = $"開始角 {startA}";
    };
    canvas.InfoDouble3 += (endA) =>
    {
      labelInfo4.Text = $"終了角 {endA}";
    };
  }

  /// <summary>
  /// ２点円の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindTwoPointCircle(Canvas canvas)
  {
    canvas.InfoXy1 += (startPointX, startPointY) =>
    {
      labelInfo1.Text = $"始点: {startPointX}, {startPointY}";
    };
    canvas.InfoDouble1 += (diameter) =>
    {
      labelInfo2.Text = $"直径: {diameter}";
    };
    canvas.InfoDouble2 += (radius) =>
    {
      labelInfo3.Text = $"半径: {radius}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = false;
      labelInfo5.Visible = false;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// ３点円の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindThreePointCircle(Canvas canvas)
  {
    canvas.InfoXy1 += (startPx, startPy) =>
    {
      labelInfo1.Text = $"始点: {startPx}, {startPy}";
    };
    canvas.InfoXy2 += (secondPx, secondPy) =>
    {
      labelInfo2.Text = $"2点目: {secondPx}, {secondPy}";
    };
    canvas.InfoDouble1 += (diameter) =>
    {
      labelInfo3.Text = $"直径: {diameter}";
    };
    canvas.InfoDouble2 += (radius) =>
    {
      labelInfo4.Text = $"半径: {radius}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = false;
      labelInfo5.Visible = false;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// 三角形の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void BindTriangleEvents(Canvas canvas)
  {
    canvas.InfoXy1 += (startPx, startPy) =>
    {
      labelInfo1.Text = $"始点: {startPx}, {startPy}";
    };
    canvas.InfoXy2 += (secondPx, secondPy) =>
    {
      labelInfo2.Text = $"2点目: {secondPx}, {secondPy}";
    };
    canvas.InfoXy3 += (endPx, endPy) =>
    {
      labelInfo3.Text = $"3点目: {endPx}, {endPy}";
    };
    canvas.StartDrawingFromAction += () =>
    {
      labelInfo1.Visible = true;
      labelInfo2.Visible = true;
      labelInfo3.Visible = true;
      labelInfo4.Visible = false;
      labelInfo5.Visible = false;
      labelInfo6.Visible = false;
    };
  }

  /// <summary>
  /// 定規の情報
  /// </summary>
  /// <param name="canvas">キャンバス</param>
  private void RulerEvents(Canvas canvas)
  {
    canvas.RulerMeasured += (dx, dy, distance, angle) =>
    {
      new RulerResult(dx, dy, distance, angle).Show();
    };
  }

  private void ResetAllLabels()
  {
    labelInfo1.Text = "";
    labelInfo2.Text = "";
    labelInfo3.Text = "";
    labelInfo4.Text = "";
    labelInfo5.Text = "";
    labelInfo6.Text = "";
  }
}
