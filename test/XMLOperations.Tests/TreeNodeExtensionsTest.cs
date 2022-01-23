using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLOperations.Common;
using XMLOperations.Types;
using Xunit;

namespace XMLOperations.Tests
{
    public class TreeNodeExtensionsTest
    {
        [Fact(DisplayName = nameof(ShouldReturnTrue_WithBothNull))]
        public void ShouldReturnTrue_WithBothNull()
        {
            TreeNode? node = null;
            TreeNode? other = null;

            bool equality = node.Equal(other);

            Assert.True(equality);
        }

        [Fact(DisplayName = nameof(ShouldReturnFalse_WhenOneOfThemIsNull))]
        public void ShouldReturnFalse_WhenOneOfThemIsNull()
        {
            TreeNode? nullNode = null;
            TreeNode? other = new("");
            TreeNode? node = new("");
            TreeNode? nullOther = null;

            bool equalityCheck1 = nullNode.Equal(other);
            bool equalitiCheck2 = node.Equal(nullOther);
            Assert.False(equalityCheck1);
            Assert.False(equalitiCheck2);
        }

        [Fact(DisplayName = nameof(ShouldReturnTrue_WhenBothOfThemHaveSameName))]
        public void ShouldReturnTrue_WhenBothOfThemHaveSameName()
        {
            TreeNode? node = new("test");
            TreeNode? other = new("test");

            bool equality = node.Equal(other);

            Assert.True(equality);
        }

        [Fact(DisplayName = nameof(ShouldReturnFalse_WhenOneOfThemHaveDifferentName))]
        public void ShouldReturnFalse_WhenOneOfThemHaveDifferentName()
        {
            TreeNode? node = new("test1");
            TreeNode? other = new("test2");

            bool equality = node.Equal(other);

            Assert.False(equality);
        }

        [Fact(DisplayName = nameof(ShouldReturnFalse_WhenAttributesAreDifferent))]
        public void ShouldReturnFalse_WhenAttributesAreDifferent()
        {
            TreeNode? node = new("test");
            TreeNode? other = new("test");
            node.Attributes.Add("key1", "value1");
            node.Attributes.Add("key2", "value2");
            other.Attributes.Add("key2", "value2");
            other.Attributes.Add("key1", "value1");

            bool equality = node.Equal(other, checkAttributes: true);

            Assert.False(equality);
        }

        [Fact(DisplayName = nameof(ShouldReturnTrue_WhenAttributesAreSame))]
        public void ShouldReturnTrue_WhenAttributesAreSame()
        {
            TreeNode? node = new("test");
            TreeNode? other = new("test");

            node.Attributes.Add("key1", "value1");
            node.Attributes.Add("key2", "value2");
            other.Attributes.Add("key1", "value1");
            other.Attributes.Add("key2", "value2");

            bool equality = node.Equal(other, checkAttributes: true);

            Assert.True(equality);
        }
    }
}