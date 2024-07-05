using System.Diagnostics;
using System.Windows;

namespace AsyncBeispiel
{
  /// <summary>
  /// Interaction logic for Window2.xaml
  /// </summary>
  public partial class Window2 : Window
  {
    public Window2()
    {
      InitializeComponent();
    }

    private CancellationTokenSource cancellationTokenSource;

    private async void BTN_START_Click(object sender, RoutedEventArgs e)
    {
      BTN_START.IsEnabled = false;
      BTN_STOPP.IsEnabled = true;

      //Inkrementieren().ContinueWith(t => BTN_START.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());

      using (cancellationTokenSource = new CancellationTokenSource())
      {

        var progress = new Progress<int>(x => LBL.Content = x);

        Task t = Inkrementieren(progress, cancellationTokenSource.Token);

        try
        {
          //await t.ConfigureAwait(true);
          await t;
        }
        catch (Exception ex)
        {
        }

        LBL.Content = t.Status;
        BTN_START.IsEnabled = true;
        BTN_STOPP.IsEnabled= false;
      }
    }

    private Task Inkrementieren(IProgress<int> progress, CancellationToken cancellationToken)
    {
      return Task.Run(async () =>
      {
        cancellationToken.Register(() => Debug.WriteLine("Cancelled!!!!"));

        for (int i = 0; i < 5; i++)
        {
          //if (i == 2) throw new ApplicationException("hupps...");

          if (cancellationToken.IsCancellationRequested)
          {
            // bei Bedarf hier aufräumen
            cancellationToken.ThrowIfCancellationRequested();
          }

          //Thread.Sleep(1000);
          await Task.Delay(1000, cancellationToken);
          progress.Report(i);
        }
      });
    }

    private void BTN_STOPP_Click(object sender, RoutedEventArgs e)
    {
      cancellationTokenSource?.Cancel();
    }
  }
}
