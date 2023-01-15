using System.Data;

namespace Application.SQLCommands
{
    public interface IDBCommandFactory
    {
        IDbCommand GetCommand();
        IDataReader ExecuteCommand(ref IDbCommand command);
    }
}
