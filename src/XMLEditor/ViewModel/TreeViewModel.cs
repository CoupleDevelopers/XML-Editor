using System.Collections.Generic;
using System.Threading.Tasks;
using XMLOperations.Helpers;
using XMLOperations.Types;

namespace XMLEditor.ViewModel
{
    internal class TreeViewModel
    {
        public TreeNode? RootNode { get; private set; }

        public List<TreeNode?> TreeData => new List<TreeNode?>() { RootNode };

        public TreeViewModel()
        {
#warning Needs to be loaded with Load File button
            //LoadTreeFromFile(filePath);

            var task = Task.Run(async () =>
            {
                RootNode = await FileOperations.LoadTreeFromUrlAsync("https://services.odata.org/v3/northwind/northwind.svc/$metadata");
            });
            task.Wait();
        }
    }
}