using System.Globalization;
using System.Windows.Data;

namespace Datenbindung1
{
  class SmileyConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      double wert = (double)value;
      if (wert < 5) return "😊";
      if (wert < 8) return "😋";
      return "😫";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
