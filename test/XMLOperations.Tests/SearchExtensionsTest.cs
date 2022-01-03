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
        public void ShouldFilterNodes_OnlyUsingParentInformation(string filePath, string headerName, string attrName, string attrValue)
        {
            // arrange
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

        [Theory]
        [InlineData(@"assets\XMLFile1.xml", "Gambardella, Matthew")]
        public void ShouldFilterNodes_HavingInnerText(string filePath, string innerText)
        {
            // arrange
            // filter model with only inner text information
            XmlNodeSearchModel model = new()
            {
                SearchingFilter = new()
                {
                    InnerText = innerText
                }
            };

            var query = XDocument.Load(filePath).Descendants();

            // act
            query = SearchExtensions.Filter(query, model);

            // assert
            Assert.True(query.Single().Name.LocalName == "author", "Expected filter result should contain 1 element which is <author>Gambardella, Matthew</author>");
        }
    }
}