using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventsBeispiel
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void ButtonClick(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("Button gedrückt");
    }

    private void PreviewMouseDownHandler(object sender, MouseButtonEventArgs e)
    {
      Debug.WriteLine($"Preview Mouse Down on {sender.GetType().Name}");
      if(sender is Ellipse)e.Handled = true;
    }

    private void MouseDownHandler(object sender, MouseButtonEventArgs e)
    {
      Debug.WriteLine($"Mouse Down on {sender.GetType().Name}");
    }
  }
}