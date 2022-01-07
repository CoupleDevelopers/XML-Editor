using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using XMLEditor.Model;

namespace XMLEditor.ViewModel
{
    internal class TreeViewModel
    {
        private readonly List<Tree> m_TreeData;
        public List<Tree> TreeData => m_TreeData;

        public TreeViewModel()
        {
            m_TreeData = new List<Tree>();

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
            m_TreeData.Clear();
            if (root == null)
                return;

            var tree = BuildTreeRecursive(root);

            m_TreeData.Add(tree);
        }

        private Tree BuildTreeRecursive(XElement element)
        {
            Tree tree = new()
            {
                Name = element.Name.LocalName
            };

            var firstLevel = element.Elements();
            foreach (var child in firstLevel)
            {
                tree.Children.Add(BuildTreeRecursive(child));
            }

            return tree;
        }
    }
}