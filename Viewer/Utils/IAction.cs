using System.ComponentModel.Design;

namespace Viewer.Utils;

public interface IAction
{
 /// <summary>
 /// レイヤー管理
 /// </summary>
 /// <param name="lm"></param>
  void SetLayerManager(LayerManager lm);

  /// <summary>
  /// ペイント
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  void OnPaint(PaintEventArgs e, Canvas canvas);

  /// <summary>
  /// 左クリック
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  void OnLeftClick(MouseEventArgs e, Canvas canvas);

  /// <summary>
  /// 右クリック
  /// </summary>
  /// <param name="e"></param>
  void OnRightClick(MouseEventArgs e);

  /// <summary>
  /// マウスムーブ
  /// </summary>
  /// <param name="e"></param>
  /// <param name="canvas">キャンバス</param>
  void OnMouseMove(MouseEventArgs e, Canvas canvas);
}
