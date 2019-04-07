using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrozenSoftware.Controls
{
    /// <summary>
    /// Interaction logic for NumerikTextBox.xaml
    /// </summary>
    public partial class NumerikTextBox : TextBox
    {
        private int decimalChar;

        public NumerikTextBox()
        {
            InitializeComponent();

            decimalChar = (int)CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key != (Key)decimalChar)
                e.Handled = true;

            base.OnKeyUp(e);
        }
    }
}
