using System;
using System.Windows;
using System.Windows.Controls;

namespace XMLEditor.View
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        public string SourceLabel
        {
            get { return (string)GetValue(SourceLabelProperty); }
            set { SetValue(SourceLabelProperty, value); }
        }

        public static readonly DependencyProperty SourceLabelProperty =
            DependencyProperty.Register("SourceLabel", typeof(string), typeof(TreeView), new PropertyMetadata(string.Empty));

        public TreeView()
        {
            InitializeComponent();
        }
    }
}