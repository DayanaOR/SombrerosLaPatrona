using System.Data;
using MySqlConnector;

namespace SombrerosLaPatrona.DataBaseAccess
{
    public class DataBase
    {
        private string cadena_conexion { get; set; }
        public DataBase()
        {
            cadena_conexion = "Server=localhost; Port=3306; Database=sombreroslapatrona; Uid=root; Pwd=12345;";
        }

        public DataSet ? EjecutarQuery(string query)
        {
            DataSet dataSet = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(cadena_conexion))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(dataSet);

                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }

            return dataSet;
        }
    }
}
