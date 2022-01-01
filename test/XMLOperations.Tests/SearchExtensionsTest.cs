using Xunit;
using XMLOperations.Types;
using System.Xml.Linq;
using XMLOperations.Extensions;
using System.Linq;

namespace XMLOperations.Tests
{
    public class SearchExtensionsTest
    {
        [Theory]
        [InlineData(@"assets\XMLFile1.xml", "book", "id", "bk101")]
        public void ShouldFilterNodes_OnlyWithParentInformation(string filePath, string headerName, string attrName, string attrValue)
        {
            // arrenge
            // filter model with only parent information
            XmlNodeSearchModel model = new()
            {
                ParentFilter = new()
                {
                    HeaderName = headerName,
                    AttributeFilters = new()
                    {
                        new(attrName, attrValue)
                    }
                }
            };

            var query = XDocument.Load(filePath).Descendants();

            // act
            query = SearchExtensions.Filter(query, model);

            // assert
            Assert.True(6 == query.Count(), "Expected filter result should contain 6 element which are elements under <book id=\"bk101\">");
        }
    }
}