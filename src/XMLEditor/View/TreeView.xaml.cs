using System.Windows.Controls;
using XMLEditor.ViewModel;

namespace XMLEditor.View
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        public TreeView()
        {
            InitializeComponent();
            DataContext = new TreeViewModel();
        }
    }
}