using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FrozenSoftware.Controls
{
    /// <summary>
    /// Interaction logic for PathButton.xaml
    /// </summary>
    public partial class PathButton : Button
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(StreamGeometry), typeof(PathButton), new PropertyMetadata(null));

        public PathButton()
        {
            InitializeComponent();
        }

        public StreamGeometry Icon
        {
            get { return (StreamGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
