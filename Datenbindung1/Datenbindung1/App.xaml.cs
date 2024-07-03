using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Datenbindung1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      //CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
      //CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

      FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(
          XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name)
          )
        );
      
    }
  }

}
