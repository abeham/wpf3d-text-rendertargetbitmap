using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ProblemCase {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      var source = PresentationSource.FromVisual(this);
      var dpi = source != null ? source.CompositionTarget.TransformToDevice.M11 * 96 : 96;

      var visualSize = new Size(ActualWidth, ActualHeight);
      var canvas = new Canvas() { Background = new SolidColorBrush(Colors.White) };
      var myView = new MyView();
      canvas.Children.Add(myView);
      canvas.Measure(visualSize);
      canvas.Arrange(new Rect(visualSize));
      canvas.UpdateLayout();
      myView.Measure(visualSize);
      myView.Arrange(new Rect(visualSize));
      myView.UpdateLayout();

      var tgt = new RenderTargetBitmap((int)ActualWidth, (int)ActualHeight, dpi, dpi, PixelFormats.Pbgra32);
      tgt.Render(canvas);
      var enc = new JpegBitmapEncoder();
      enc.QualityLevel = 80;
      enc.Frames.Add(BitmapFrame.Create(tgt));
      var sfd = new SaveFileDialog();
      if (sfd.ShowDialog().GetValueOrDefault()) {
        using (var stream = sfd.OpenFile()) {
          enc.Save(stream);
        }
      }
    }
  }
}
