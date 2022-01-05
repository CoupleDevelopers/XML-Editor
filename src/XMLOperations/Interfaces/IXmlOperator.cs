using XMLOperations.Configuration;

namespace XMLOperations.Interfaces;

public interface IXmlOperator
{
    public void Operate(DirectoryInfo directory, OperationOptions options);

    public void Operate(FileInfo file, OperationOptions options);
}