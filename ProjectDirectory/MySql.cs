using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDirectory
{
    internal class MySql
    {
        public string Database { get; set; }
        public String ConStr {  get; set; }
        public MySql(String Database)
        {
            this.Database = Database;
        }

        public async Task<bool> Connection(String sql, Func<MySqlCommand ,bool> action)
        {
            ConStr = $"server=127.0.0.1;port=3306;database={this.Database};uid=root;pwd=root;charset=utf8";

            using (MySqlConnection conn = new MySqlConnection(ConStr))
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = new MySqlCommand(sql,conn)) 
                {
                    return action(cmd);
                }
            }
        }
    }

}
