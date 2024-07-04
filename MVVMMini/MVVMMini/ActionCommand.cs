using System.Windows.Input;

namespace MVVMMini
{
  public class ActionCommand : ICommand
  {
    public string DisplayText { get; set; }
    public string ToolTipText { get; set; }

    private readonly Action? action;
    private readonly Action<object?>? action2;

    public ActionCommand(Action action)
    {
      this.action = action;
    }

    public ActionCommand(Action<object?> action2)
    {
      this.action2 = action2;
    }

    private bool isEnabled = true;

    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        if (isEnabled == value) return;
        isEnabled = value;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
      }
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
      return isEnabled;
    }

    public void Execute(object? parameter)
    {
      action?.Invoke();
      action2?.Invoke(parameter);
    }
  }
}
