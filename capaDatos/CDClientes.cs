using MySql.Data.MySqlClient;
using capaEntidad;
using System.Data;

namespace capaDatos
{
    public class CDClientes
    {

        string CadenaConexion = "Server=localhost;User=root;Password=;Port=3306;database=curso_cs";

        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse " + ex.Message);
                return;
            }

            mySqlConnection.Close();    
            MessageBox.Show("Conectado");
        }

        public void Crear(CEClientes cE) 
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `clientes` (`nombre`, `apellido`, `foto`) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();//el execute non query se utiliza con comandos que no devuelven valor
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado");
        }

        public DataSet Listar() 
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes`;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection); //esta linea nos permite obtener los datos sin necesidad de usar un execute query
            Adaptador.Fill(dataSet,"tblCliente"); //aqui se llena la el dataGrid con los datos

            return dataSet; 

        }
        public void Editar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `clientes` SET `nombre` = '" + cE.Nombre + "', `apellido` = '" + cE.Apellido + "', `foto` = '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "' WHERE (`id` = '" + cE.Id + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();//el execute non query se utiliza con comandos que no devuelven valor
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado");
        }

        public void Eliminar(CEClientes cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `clientes` WHERE (`id` = '" + cE.Id + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();//el execute non query se utiliza con comandos que no devuelven valor
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado");
        }

    }
}