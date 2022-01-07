using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using XMLEditor.Extensions;
using XMLEditor.Model;

namespace XMLEditor.ViewModel
{
    internal class TreeViewModel
    {
        public TreeNode? RootNode { get; private set; }

        public List<TreeNode?> TreeData => new List<TreeNode?>() { RootNode };

        public TreeViewModel()
        {
#warning Needs to be loaded with Load File button
            var filePath = @"C:\Users\Volkan\Desktop\WorkSpace\Github\XML-Editor\test\XMLOperations.Tests\Assets\XMLFile1.xml";
            LoadTreeFromFile(filePath);
        }

        private void LoadTreeFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var root = XDocument.Load(filePath).Root;

            RootNode = root.ToTreeNode();
        }
    }
}