namespace Viewer
{
  public partial class RulerResult : Form
  {
    public RulerResult(double dx, double dy, double distance, double angle)
    {
      InitializeComponent();
      string dxString = dx.ToString();
      string dyString = dy.ToString();
      string distanceString = distance.ToString();
      string angleString = angle.ToString();
      label1.Text = $"Xの距離: {dxString}";
      label2.Text = $"Yの距離: {dyString}";
      label3.Text = $"距離: {distanceString}";
      label4.Text = $"角度: {angleString}";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
