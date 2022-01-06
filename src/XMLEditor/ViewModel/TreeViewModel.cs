using System.Xml.Linq;
using XMLEditor.Model;
using System.Linq;
using System.Collections.Generic;
using System;

namespace XMLEditor.ViewModel
{
    internal class TreeViewModel
    {
        private readonly List<Tree> m_TreeData;
        public List<Tree> TreeData => m_TreeData;

        public TreeViewModel()
        {
            m_TreeData = new List<Tree>();
            CreateTree();
        }

        private void CreateTree()
        {
            var root = XDocument.Load(@"C:\Users\t-mac\Desktop\XML-Editor\test\XMLOperations.Tests\assets\XMLFile1.xml").Root;
            m_TreeData.Clear();
            if (root == null)
                return;

            var tree = new Tree();
            BuildTreeRecursive(tree, root);
            m_TreeData.Add(tree);
        }

        private void BuildTreeRecursive(Tree tree, XElement root)
        {
            var firstLevel = root.Elements();
            tree.Name = root.Name.LocalName;
            tree.ChildrenCount = firstLevel.Count();
            tree.Children = new List<Tree>();
            foreach (var child in firstLevel)
            {
                tree.Children.Add(new Tree() { Name = child.Name.LocalName, ChildrenCount = child.Elements().Count(), Children = new List<Tree>() });
                BuildTreeRecursive(tree.Children.Last(), child);
            }
        }
    }
}