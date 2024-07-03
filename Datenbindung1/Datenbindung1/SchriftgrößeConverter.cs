using System.Globalization;
using System.Windows.Data;

namespace Datenbindung1
{
  class SchriftgrößeConverter : IValueConverter
  {
    public double Offset { get; set; } = 20;
    public double Faktor { get; set; } = 2;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      double wert = (double)value;
      return Offset + Faktor * wert;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
