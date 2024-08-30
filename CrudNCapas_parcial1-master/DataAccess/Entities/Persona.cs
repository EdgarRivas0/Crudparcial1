using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Connection;
using Common.Attributes;

namespace DataAccess.Entities
{
    public class Persona
    {
        //variables
        Connection_Database c = new Connection_Database(); //Declara una instancia privada de la clase Connection_Database llamada c. Esta instancia se usará para gestionar la conexión a la base de datos.
        SqlCommand cmd = new SqlCommand(); //Declara una instancia privada de la clase SqlCommand llamada cmd. SqlCommand se usa para ejecutar comandos SQL
        SqlDataReader dr; //Declara una variable privada de tipo SqlDataReader llamada dr. SqlDataReader se usa para leer los datos devueltos por un comando SQL ejecutado en la base de datos.
        DataTable td = new DataTable(); // Declara una instancia privada de la clase DataTable llamada td. DataTable se usa para almacenar datos en memoria en forma de una tabla estructurada, que puede ser útil para manejar y visualizar datos en la aplicación.

        public DataTable Mostrar()
        {
            try // Inicia un bloque try para manejar excepciones que puedan ocurrir durante la ejecución del código dentro del bloque. Esto permite capturar y manejar errores de manera controlada.
            {
                cmd.Connection = c.OpenConnection(); //Establece la conexión del objeto SqlCommand (cmd) usando la conexión abierta proporcionada por el método OpenConnection de la instancia c de Connection_Database.
                cmd.CommandText = "SP_Mostrar"; //Establece el texto del comando (CommandText) del objeto SqlCommand a "SP_Mostrar", que es el nombre del procedimiento almacenado que se desea ejecutar.
                cmd.CommandType = CommandType.StoredProcedure; //Establece el tipo de comando (CommandType) del objeto SqlCommand a StoredProcedure, indicando que el comando es un procedimiento almacenado en la base de datos.
                dr = cmd.ExecuteReader(); //Ejecuta el comando utilizando el método ExecuteReader del objeto SqlCommand. Esto devuelve un SqlDataReader (dr) que se usa para leer los resultados del procedimiento almacenado.
                td.Load(dr); //Carga los datos del SqlDataReader (dr) en la DataTable (td). El método Load lee los datos y los almacena en la DataTable.
            }
            catch (Exception ex) //Captura cualquier excepción que ocurra durante la ejecución del bloque try. Esto permite manejar errores de manera controlada.
            {
                string msj = ex.ToString(); //Convierte la excepción capturada (ex) a una cadena y la asigna a una variable msj. Esta variable puede usarse para mostrar o registrar el mensaje de error.
            }
            finally //Inicia un bloque finally que se ejecuta después del bloque try y catch, independientemente de si se produjo una excepción o no. Se usa para realizar limpieza o liberar recursos.
            {
                cmd.Connection = c.CloseConnection(); // Cierra la conexión a la base de datos utilizando el método CloseConnection de la instancia c de Connection_Database y asigna la conexión cerrada al objeto SqlCommand.
            }
            return td; //Devuelve la DataTable (td) que contiene los datos leídos desde la base de datos
        }

        public DataTable Buscar(string Buscar) //Está diseñado para ejecutar una búsqueda en la base de datos basada en el parámetro Buscar y devolver los resultados en una tabla de datos.
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", Buscar);
                dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                td.Load(dr);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
            return td;
        }

        public void Insertar(AttributePeople obj) //El método no devuelve ningún valor (void). Está diseñado para insertar una nueva entrada en la base de datos utilizando los datos del objeto obj.
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Insertar";
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex) 
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection= c.CloseConnection();
            }
        }

        public void Modificar(AttributePeople obj) //El método no devuelve ningún valor (void). Está diseñado para modificar una entrada existente en la base de datos utilizando los datos del objeto obj.
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }

        public void Eliminar(AttributePeople obj) //El método no devuelve ningún valor (void). Está diseñado para eliminar una entrada en la base de datos utilizando el identificador del objeto obj.
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.CloseConnection();
            }
        }
    }
}
