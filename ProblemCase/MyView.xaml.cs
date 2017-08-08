using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProblemCase {
  /// <summary>
  /// Interaction logic for MyView.xaml
  /// </summary>
  public partial class MyView : UserControl {
    public MyView() {
      InitializeComponent();


      var modelGroup = (Model3DGroup)MyModel.Content;
      var cube = new GeometryModel3D { Geometry = new MeshGeometry3D(), Material = new DiffuseMaterial() { Brush = new SolidColorBrush(Colors.Orange) } };
      //AddPlane((MeshGeometry3D)cube.Geometry, new Point3D(-0.5, -0.5, -0.5), new Vector3D(1, 0, 0), new Vector3D(0, 1, 0));
      AddSolidCube((MeshGeometry3D)cube.Geometry, -0.5, -0.5, -0.5, 1, 1, 1);
      modelGroup.Children.Add(cube);

      var text = CreateTextLabel3D("Text", new SolidColorBrush(Colors.Black), new Point3D(.5, -.5, 0), new Vector3D(1, 0, 0), new Vector3D(0, 1, 0));
      modelGroup.Children.Add(text);
    }

    private void AddSolidCube(MeshGeometry3D mesh, double x, double y, double z, double width, double height, double depth) {
      var b = mesh.Positions.Count;
      // back
      mesh.Positions.Add(new Point3D(x, y, z));
      mesh.Positions.Add(new Point3D(x + width, y, z));
      mesh.Positions.Add(new Point3D(x + width, y + height, z));
      mesh.Positions.Add(new Point3D(x, y + height, z));
      // front
      mesh.Positions.Add(new Point3D(x, y, z + depth));
      mesh.Positions.Add(new Point3D(x + width, y, z + depth));
      mesh.Positions.Add(new Point3D(x + width, y + height, z + depth));
      mesh.Positions.Add(new Point3D(x, y + height, z + depth));

      // bottom
      AddPlaneIndices(mesh, b + 0, b + 1, b + 5, b + 4);
      // right side
      AddPlaneIndices(mesh, b + 1, b + 2, b + 6, b + 5);
      // top
      AddPlaneIndices(mesh, b + 3, b + 7, b + 6, b + 2);
      // left side
      AddPlaneIndices(mesh, b + 0, b + 4, b + 7, b + 3);
      // front
      AddPlaneIndices(mesh, b + 4, b + 5, b + 6, b + 7);
      // back
      AddPlaneIndices(mesh, b + 0, b + 3, b + 2, b + 1);
    }

    private GeometryModel3D CreateTextLabel3D(string text, Brush textColor,
        Point3D origin, Vector3D width, Vector3D height, bool backside = true) {

      var mat = new DiffuseMaterial() {
        Brush = new VisualBrush(new TextBlock(new Run(text)) {
          Foreground = textColor,
          FontFamily = new FontFamily("Arial")
        })
      };

      var mesh = new MeshGeometry3D();
      AddPlane(mesh, origin, width, height, backside);

      mesh.TextureCoordinates.Add(new Point(0, 1)); // ll
      mesh.TextureCoordinates.Add(new Point(1, 1)); // lr
      mesh.TextureCoordinates.Add(new Point(1, 0)); // ur
      mesh.TextureCoordinates.Add(new Point(0, 0)); // ul

      if (backside) {
        mesh.TextureCoordinates.Add(new Point(0, 0)); // ll
        mesh.TextureCoordinates.Add(new Point(1, 0)); // lr
        mesh.TextureCoordinates.Add(new Point(1, 1)); // ur
        mesh.TextureCoordinates.Add(new Point(0, 1)); // ul
      }
      return new GeometryModel3D(mesh, mat);
    }

    private void AddPlane(MeshGeometry3D mesh, Point3D origin, Vector3D width, Vector3D height, bool backside = false) {
      var lr = origin + width;
      var ur = origin + width + height;
      var ul = origin + height;

      var b = mesh.Positions.Count;
      mesh.Positions.Add(origin);
      mesh.Positions.Add(lr);
      mesh.Positions.Add(ur);
      mesh.Positions.Add(ul);

      if (backside) {
        mesh.Positions.Add(origin);
        mesh.Positions.Add(lr);
        mesh.Positions.Add(ur);
        mesh.Positions.Add(ul);
      }

      AddPlaneIndices(mesh, b + 0, b + 1, b + 2, b + 3, backside);
    }

    private void AddPlaneIndices(MeshGeometry3D mesh, int a, int b, int c, int d, bool backside = false) {
      mesh.TriangleIndices.Add(a);
      mesh.TriangleIndices.Add(b);
      mesh.TriangleIndices.Add(d);
      mesh.TriangleIndices.Add(c);
      mesh.TriangleIndices.Add(d);
      mesh.TriangleIndices.Add(b);

      if (!backside) return;
      mesh.TriangleIndices.Add(a);
      mesh.TriangleIndices.Add(d);
      mesh.TriangleIndices.Add(b);
      mesh.TriangleIndices.Add(c);
      mesh.TriangleIndices.Add(b);
      mesh.TriangleIndices.Add(d);
    }
  }
}
