using Avalonia.Controls;

namespace Hookbord.Views.Controls
{
    public class base_UserControl : UserControl
    {
        public bool IsFocus { get; set; } = false;
        public void InitFocus()
        {
            this.GotFocus += (o, e) =>
            {

            };
        }
    }
}
