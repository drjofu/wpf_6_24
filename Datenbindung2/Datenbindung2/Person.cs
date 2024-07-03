using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbindung2
{
  public class Person : INotifyPropertyChanged
  {
    public string Name { get; set; }
    public string Wohnort { get; set; }
    //public int Alter { get; set; }
    private int alter;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;

        alter = value;
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alter"));
        OnPropertyChanged();
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    public bool IstErfahren => Alter > 50;
  }

  public class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new ObservableCollection<Person>()
    {
      new Person(){ Name="Dagobert", Wohnort="Entenhausen", Alter=78},
      new Person(){ Name="Donald", Wohnort="Entenhausen", Alter=66},
      new Person(){ Name="Frida", Wohnort="Berlin", Alter=33},
      new Person(){ Name="Elke", Wohnort="Köln", Alter=22},
      new Person(){ Name="Ernst", Wohnort="München", Alter=45}
    };
       
  }
}
