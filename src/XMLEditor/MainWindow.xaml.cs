using System;
using System.Windows;
using System.Windows.Controls;
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
            var vm = new MainWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => Close());
        }

        private void DraggableWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupBox box = new GroupBox();
            box.Width = 300;
            box.Height = 100;
            box.Header = "asdasdas";
            DockPanel.SetDock(box, Dock.Left);

            this.dockPanel.Children.Add(box);
        }
    }
}