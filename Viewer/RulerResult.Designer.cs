namespace Viewer
{
  partial class RulerResult
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      label4 = new Label();
      BtnClose = new Button();
      panel1 = new Panel();
      panel1.SuspendLayout();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(21, 12);
      label1.Name = "label1";
      label1.Size = new Size(38, 15);
      label1.TabIndex = 0;
      label1.Text = "label1";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(21, 36);
      label2.Name = "label2";
      label2.Size = new Size(38, 15);
      label2.TabIndex = 1;
      label2.Text = "label2";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(21, 60);
      label3.Name = "label3";
      label3.Size = new Size(38, 15);
      label3.TabIndex = 2;
      label3.Text = "label3";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(21, 84);
      label4.Name = "label4";
      label4.Size = new Size(38, 15);
      label4.TabIndex = 3;
      label4.Text = "label4";
      // 
      // BtnClose
      // 
      BtnClose.Location = new Point(301, 134);
      BtnClose.Name = "BtnClose";
      BtnClose.Size = new Size(75, 23);
      BtnClose.TabIndex = 4;
      BtnClose.Text = "閉じる";
      BtnClose.UseVisualStyleBackColor = true;
      BtnClose.Click += button1_Click;
      // 
      // panel1
      // 
      panel1.BackColor = Color.White;
      panel1.Controls.Add(label1);
      panel1.Controls.Add(label2);
      panel1.Controls.Add(label4);
      panel1.Controls.Add(label3);
      panel1.Location = new Point(12, 12);
      panel1.Name = "panel1";
      panel1.Size = new Size(364, 116);
      panel1.TabIndex = 5;
      // 
      // RulerResult
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(398, 159);
      Controls.Add(panel1);
      Controls.Add(BtnClose);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "RulerResult";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "定規";
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button BtnClose;
    private Panel panel1;
  }
}