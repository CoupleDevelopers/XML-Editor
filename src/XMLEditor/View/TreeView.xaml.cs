using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using XMLOperations.Types;

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

        public List<TreeNode?> SourceTree
        {
            get { return (List<TreeNode?>)GetValue(SourceTreeProperty); }
            set { SetValue(SourceTreeProperty, value); }
        }

        public static readonly DependencyProperty SourceTreeProperty =
            DependencyProperty.Register("SourceTree", typeof(List<TreeNode?>), typeof(TreeView), new PropertyMetadata());

        public TreeView()
        {
            InitializeComponent();
        }
    }
}