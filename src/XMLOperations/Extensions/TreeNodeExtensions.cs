using XMLOperations.Types;

namespace XMLOperations.Common
{
    public static class TreeNodeExtensions
    {
        /// <summary>
        /// Extension method checks if nodes are same or not
        /// </summary>
        /// <param name="node">Main node</param>
        /// <param name="other">Node for Comparison</param>
        /// <param name="checkAttributes"></param>
        /// <param name="orderAttributes">Orders attributes by name before checking equality</param>
#warning order needs to be implemented after structural checks

        public static bool Equal(
            this TreeNode? node,
            TreeNode? other,
            bool checkAttributes = false,
            bool orderAttributes = false)
        {
            if (node == null && other == null)
                return true;

            if (node == null ^ other == null) // XOR
                return false;

            if (node!.Name != other!.Name)
            {
                return false;
            }

            if (checkAttributes)
            {
                if (node.Attributes.Count != other.Attributes.Count)
                    return false;

                for (int i = 0; i < node.Attributes.Count; i++)
                {
                    if (node.Attributes.ElementAt(i).Key != other.Attributes.ElementAt(i).Key)
                        return false;

                    if (node.Attributes.ElementAt(i).Value != other.Attributes.ElementAt(i).Value)
                        return false;
                }
            }

            return true;
        }
    }
}