using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ValidierungenBeispiel
{
  public class GeradeZahlValidationRule : ValidationRule
  {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      string? text=value as string;
      if(int.TryParse(text,out int zahl))
      {
        if (zahl % 2 == 0)
          return ValidationResult.ValidResult;
        return new ValidationResult(false, $"{zahl} muss gerade sein, ist es aber nicht.");
      }
      return new ValidationResult(false, $"{text} ist keine gültige Zahl");
    }
  }
}
