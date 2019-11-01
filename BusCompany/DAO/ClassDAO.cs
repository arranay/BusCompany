using System.Data.SqlClient;
using log4net;

namespace BusCompany.DAO
{
    public class ClassDAO
    {
        private const string connectionString = @"Initial Catalog = BusCompany;" +
        @"Data Source=LOCALHOST\SQLEXPRESS;" + @"Integrated Security=True;" +
        @"Pooling=False";

        protected static readonly ILog log = LogManager.GetLogger(typeof(ClassDAO));
        protected SqlConnection Connection { get; set; }

        public void Connect()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Соединение открыто");
        }

        public void Disconnect()
        {
            Connection.Close();
            log4net.Config.DOMConfigurator.Configure();
            log.Info("Соединение закрыто");
        }

    }
}