using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ProblemCase;

namespace ProblemCaseWinForms {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
      var myView = new MyView();
      var source = PresentationSource.FromVisual(myView);
      var dpi = source != null ? source.CompositionTarget.TransformToDevice.M11 * 96 : 96;

      var visualSize = new System.Windows.Size(Width, Height);
      var canvas = new Canvas() { Background = new SolidColorBrush(Colors.White) };
      canvas.Children.Add(myView);
      canvas.Measure(visualSize);
      canvas.Arrange(new Rect(visualSize));
      canvas.UpdateLayout();
      myView.Measure(visualSize);
      myView.Arrange(new Rect(visualSize));
      myView.UpdateLayout();

      var tgt = new RenderTargetBitmap((int)Width, (int)Height, dpi, dpi, PixelFormats.Pbgra32);
      tgt.Render(canvas);
      var enc = new JpegBitmapEncoder();
      enc.QualityLevel = 80;
      enc.Frames.Add(BitmapFrame.Create(tgt));
      var sfd = new SaveFileDialog();
      if (sfd.ShowDialog() == DialogResult.OK) {
        using (var stream = sfd.OpenFile()) {
          enc.Save(stream);
        }
      }
    }
  }
}
