using System.ComponentModel;

namespace ValidierungenBeispiel
{
  public class ViewModel : IDataErrorInfo
  {
    private int geradeZahl1;


    public int GeradeZahl1
    {
      get { return geradeZahl1; }
      set
      {
        if (value % 2 != 0) throw new ApplicationException($"{value} ist ungerade");
        geradeZahl1 = value;
      }
    }

    public int GeradeZahl2 { get; set; }

    public string this[string propertyName]
    {
      get
      {
        switch (propertyName)
        {
          case nameof(GeradeZahl2):
            if (GeradeZahl2 % 2 != 0)
              return $"{GeradeZahl2} ist nicht gerade!";
            return "";
        }
        return "";
      }
    }
    public string Error => throw new NotImplementedException();
  }
}
