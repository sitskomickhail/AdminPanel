using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.SQL
{
    public static class DataWorker
    {
        private static MySqlConnection conn;

        static DataWorker()
        {
            conn = DataUtils.GetDBConnection();
        }

        public static bool KeyQuery(string key, int durationTime)
        {
            DateTime date;
            if (durationTime == 12) date = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
            else if (durationTime == 100) date = new DateTime(DateTime.Now.Year + durationTime, DateTime.Now.Month, DateTime.Now.Day);
            else if (DateTime.Now.Month <= 6) date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + durationTime, DateTime.Now.Day);
            else
            {
                if (DateTime.Now.Month + durationTime > 12) date = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month + durationTime - 12, DateTime.Now.Day);
                else date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + durationTime, DateTime.Now.Day);
            }

            conn.Open();
            string sql = "INSERT INTO LicenseTBO (license_key, duration_key, active_key) VALUES (@key, @date, @active)";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@key", MySqlDbType.String).Value = key;
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@active", MySqlDbType.Int32).Value = 0;
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                catch { return false; }
            }
            return true;
        }
    }
}