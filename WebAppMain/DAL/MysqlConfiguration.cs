using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            //AutomaticMigrationsEnabled = false;

            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator()); //it will generate MySql commands instead of SqlServer commands.

            //SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema)); //here s the thing.

            SetHistoryContext("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }
}