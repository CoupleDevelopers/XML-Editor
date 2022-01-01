using System.Xml.Linq; 
using Xunit;
using XMLOperations.Extensions;

namespace XMLOperations.Tests
{
    public class XElementExtensionsTest
    {
        [Fact(DisplayName = nameof(AllowAttributeCheck))]
        public void AllowAttributeCheck()
        {
            string attributeName = "id";

            XElement element = new XElement(nameof(element));
            Assert.False(element.ContainsAttribute(attributeName));
            Assert.False(element.ContainsAttribute(attributeName, null));


            element.Add(new XAttribute("wrongAttribute","test"));
            Assert.False(element.ContainsAttribute(attributeName));
            Assert.False(element.ContainsAttribute(attributeName, null));

            element.Add(new XAttribute(attributeName, 3)); 
            Assert.True(element.ContainsAttribute(attributeName));
            Assert.True(element.ContainsAttribute(attributeName, null));
            Assert.True(element.ContainsAttribute(attributeName, "3"));
            Assert.True(element.ContainsAttribute(x=> x.Name == attributeName && x.Value == "3"));
        }


        [Fact(DisplayName = nameof(AllowLocalNameCheck))]
        public void AllowLocalNameCheck()
        {
            XElement element = new XElement("TestElement"); 

            Assert.True(element.HasLocalName("TestElement"));
            Assert.False(element.HasLocalName(""));
            Assert.False(element.HasLocalName("  "));
        }
    }
}
