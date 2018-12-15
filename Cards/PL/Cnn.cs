using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace PL
{
    public class Cnn
    {
        public static IEnumerable<object[]> ExecCmd(SqlCommand Cmd, bool Query = true)
        {
            if (string.IsNullOrWhiteSpace(Cmd.CommandText))
                throw new ArgumentException();

            string cnnStr = GetConnectionString();

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();

                Cmd.Connection = cnn;
                Cmd.CommandType = CommandType.StoredProcedure;

                if (!Query)
                {
                    SqlParameter cmdRet = Cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                    cmdRet.Direction = ParameterDirection.ReturnValue;

                    Cmd.ExecuteNonQuery();

                    if ((int)Cmd.Parameters["@ReturnValue"].Value < 0)
                        throw new Exception(cmdRet.Value.ToString());

                    yield break;
                }

                using (SqlDataReader reader = Cmd.ExecuteReader())
                {
                    Thread rThread2 = new Thread(new ThreadStart(Cmd.Cancel));
                    rThread2.Start();
                    rThread2.Join();

                    while (reader.Read())
                    {
                        object[] ret = new object[reader.FieldCount];
                        reader.GetValues(ret);
                        yield return ret;
                    }
                }
            }
        }

        public static IEnumerable<object[]> ExecCmd(string s, bool Query = true)
        {
            foreach (var o in ExecCmd(new SqlCommand(s), Query))
                yield return o;
        }

        static private string GetConnectionString()
        {
            return
                  "Data Source=(localdb)\\MSSQLLocalDB;"
                + "Initial Catalog=tarjs;"
                + "Integrated Security=True";
        }
    }
}