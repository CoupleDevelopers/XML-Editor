using System.Collections.Generic;
using System.Threading.Tasks;
using XMLOperations.Helpers;
using XMLOperations.Types;

namespace XMLEditor.ViewModel
{
    internal class TreeComparisonViewModel : ViewModelBase
    {
        private string m_LeftTreeName;
        private string m_RightTreeName;
        private List<TreeNode?> m_LeftRootNode;
        private List<TreeNode?> m_RightRootNode;

        public string LeftTreeName
        {
            get => m_LeftTreeName;
            set => SetField(ref m_LeftTreeName, value, () => LeftTreeName);
        }

        public string RightTreeName
        {
            get => m_RightTreeName;
            set => SetField(ref m_RightTreeName, value, () => RightTreeName);
        }

        public List<TreeNode?> LeftRootNode
        {
            get => m_LeftRootNode;
            set => SetField(ref m_LeftRootNode, value, () => LeftRootNode);
        }

        public List<TreeNode?> RightRootNode
        {
            get => m_RightRootNode;
            set => SetField(ref m_RightRootNode, value, () => RightRootNode);
        }

        public TreeComparisonViewModel()
        {
            Init();
        }

        public void Init()
        {
            m_LeftTreeName = "Tree 1";
            m_RightTreeName = "Tree 2";

#warning Needs to be loaded with Load File button
            //LoadTreeFromFile(filePath);

            var task = Task.Run(async () =>
            {
#warning Implement Config Usage - Take input from UI
                //TreeViewConfig
                m_LeftRootNode = new() { await FileOperations.LoadTreeFromUrlAsync("https://services.odata.org/v3/northwind/northwind.svc/$metadata") };
                m_RightRootNode = m_LeftRootNode;
            });
            task.Wait();
        }
    }
}