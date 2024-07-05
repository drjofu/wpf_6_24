using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace AsyncBeispiel
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void BTN_Click(object sender, RoutedEventArgs e)
    {
      Task.Run(Inkrementieren);
    }

    private void Inkrementieren()
    {
      for (int i = 0; i < 5; i++)
      {
        //Thread.Sleep(1000); // DO NOT USE!!!
        //LBL.Content = i;
        //Dispatcher.BeginInvoke(new Action<int>(x => LBL.Content = x), i);
        // Dispatcher.BeginInvoke(new Action(() => LBL.Content = i));  // i ist jetzt ein Closure

        int k = i;
        Dispatcher.BeginInvoke(new Action(() => Debug.WriteLine(k)));  // i ist jetzt ein Closure

      }
    }
  }
}
