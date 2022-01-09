using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            //var filePath = @"C:\Users\Volkan\Desktop\WorkSpace\Github\XML-Editor\test\XMLOperations.Tests\Assets\XMLFile1.xml";
            //LoadTreeFromFile(filePath);

            var task = Task.Run(async () => { await LoadTreeFromUrl("https://services.odata.org/v3/northwind/northwind.svc/$metadata"); });
            task.Wait();
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

        private async Task LoadTreeFromUrl(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            using (StreamReader streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                string resultString = await streamReader.ReadToEndAsync();
                var root = XDocument.Parse(resultString).Root;
                RootNode = root.ToTreeNode();
            }
        }
    }
}