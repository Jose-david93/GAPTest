using Insight.Database;
using Ninject;
using System.Data.SqlClient;

namespace GAP.AccessData.Insight
{
    class ADInsight
    {
        private static string DefaultConnection = "";// ConfigurationHelper.GetConfig()["ConnectionStringBol"];

        [Inject]
        public static SqlConnection DefaultCnn
        {
            get
            {
                SqlInsightDbProvider.RegisterProvider();
                return new SqlConnection(DefaultConnection);
            }
        }
    }
}
