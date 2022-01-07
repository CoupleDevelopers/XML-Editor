using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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
    }
}