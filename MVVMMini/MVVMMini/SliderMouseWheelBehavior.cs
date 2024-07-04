using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace MVVMMini
{
  class SliderMouseWheelBehavior : Behavior<Slider>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
    }

    private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
      double newValue = AssociatedObject.Value;
      newValue += e.Delta * AssociatedObject.SmallChange;
      AssociatedObject.Value = Math.Min(AssociatedObject.Maximum, Math.Max(AssociatedObject.Minimum, newValue));
    }

    protected override void OnDetaching()
    {
      this.AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;

      base.OnDetaching();
    }
  }
}
