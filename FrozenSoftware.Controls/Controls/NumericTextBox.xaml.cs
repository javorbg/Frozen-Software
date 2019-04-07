using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrozenSoftware.Controls
{
    /// <summary>
    /// Interaction logic for NumericTextBox.xaml
    /// </summary>
    public partial class NumericTextBox : TextBox
    {
        private int decimalChar;

        public NumericTextBox()
        {
            InitializeComponent();

            decimalChar = (int)CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key < Key.D0 && e.Key > Key.D9 && e.Key != (Key)decimalChar)
                e.Handled = true;

            base.OnKeyUp(e);
        }
    }
}
