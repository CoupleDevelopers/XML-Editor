using System.Xml.Linq;
using XMLOperations.Extensions;
using XMLOperations.Types;

namespace XMLOperations.Helpers;

public static class FileOperations
{
    private static void LoadTreeFromFile(TreeNode? rootNode, string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(filePath);
        }

        var root = XDocument.Load(filePath).Root;

        rootNode = root.ToTreeNode();
    }

    public static async Task<TreeNode?> LoadTreeFromUrlAsync(string url)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(url);

        using (StreamReader streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
        {
            string resultString = await streamReader.ReadToEndAsync();
            var root = XDocument.Parse(resultString).Root;
            return root.ToTreeNode();
        }
    }
}