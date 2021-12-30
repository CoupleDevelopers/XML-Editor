using System.Windows;
using System.Windows.Input;

namespace XMLEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DraggableWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
