using XMLOperations.Interfaces;
using XMLOperations.Configuration;
using System.Runtime.CompilerServices;

namespace XMLOperations;

public class XmlOperator : IXmlOperator
{
    public void Operate(DirectoryInfo directory, OperationOptions options)
    {
        throw new NotImplementedException();
    }

    public void Operate(FileInfo file, OperationOptions options)
    {
        if (!IsExtensionCorrect(file.Extension)) return; 
        throw new NotImplementedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool IsExtensionCorrect(string extension) => extension == ".xml";
}

