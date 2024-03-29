using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DapperStore.Infra.StoreContext.DataConnection
{
    public class OracleDataConnection : IDisposable
    {
        public OracleConnection Connection { get; set; }

        public OracleDataConnection()
        {
            Connection = new OracleConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}