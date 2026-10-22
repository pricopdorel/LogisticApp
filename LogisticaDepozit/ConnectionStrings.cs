using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaDepozit
{
    public static class ConnectionStrings
    {
        public const string Darius = @"data source=DESKTOP-8FI7P38\SQLEXPRESS;initial catalog=LogisticDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        public const string Dorel = @"data source=DESKTOP-OSUV1BO\SQLEXPRESS;initial catalog=LogisticDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        public const string Minia = @"Data Source=DESKTOP-QUDR49C;Initial Catalog=LogisticDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public const string Bogdan = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LogisticDBnew1;Connect Timeout=30;Encrypt=False;";
    }

}
