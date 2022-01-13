using System.Collections.Generic;
using System.Threading.Tasks;
using XMLOperations.Helpers;
using XMLOperations.Types;

namespace XMLEditor.ViewModel
{
    internal class TreeViewModel
    {
        private TreeNode? m_RootNode;
        public List<TreeNode?> TreeData => new() { m_RootNode };

        public TreeViewModel()
        {
#warning Needs to be loaded with Load File button
            //LoadTreeFromFile(filePath);

            var task = Task.Run(async () =>
            {
#warning Implement Config Usage - Take input from UI
                //TreeViewConfig
                m_RootNode = await FileOperations.LoadTreeFromUrlAsync("https://services.odata.org/v3/northwind/northwind.svc/$metadata");
            });
            task.Wait();
        }
    }
}