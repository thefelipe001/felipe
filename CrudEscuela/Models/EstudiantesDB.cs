using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEscuela.Models
{


    public class EstudiantesDB
    {

        string connectionString = "Data Source=.;Initial Catalog=felipe;Integrated Security=True";


        public IEnumerable<Estudiante> Todolosestudiantes()
        {
            List<Estudiante> listaestudiantes = new List<Estudiante>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("Sp_TodolosEstudiantes", con);

                comando.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.id =Convert.ToInt32( dr["id"].ToString());
                    estudiante.Matricula = dr["matricula"].ToString();
                    estudiante.Nombre = dr["nombre"].ToString();
                    estudiante.Apellido = dr["apellido"].ToString();
                    estudiante.Sexo = dr["sexo"].ToString();
                    estudiante.Materia = dr["materia"].ToString();
                    estudiante.Tutor = dr["tutor"].ToString();



                    listaestudiantes.Add(estudiante);

                }
                con.Close();

            }
            return listaestudiantes;
        }
        //Para Insertar
        public void AgregarEstudiantes(Estudiante estudiante)

        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("Sp_IngreseEstudiantes", con);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
                comando.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@sexo", estudiante.Sexo);
                comando.Parameters.AddWithValue("@materia", estudiante.Materia);
                comando.Parameters.AddWithValue("@tutor", estudiante.Tutor);

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();

            }

        }
        //Actualizar
        public void actualizar(Estudiante estudiante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("Sp_ActualizarEstudiantes", con);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@matricula", estudiante.Matricula);
                comando.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@sexo", estudiante.Sexo);
                comando.Parameters.AddWithValue("@materia", estudiante.Materia);
                comando.Parameters.AddWithValue("@tutor", estudiante.Tutor);

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();

            }


        }

        //Eliminar
        public void Eliminar(int? matricula) { 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("Sp_ActualizarEstudiantes", con);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@matricula", matricula);

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();

            }


        }


        //Obtener Empleado por matricula
        public Estudiante ObtenerEstudiantes(int matricula)
        {
            Estudiante estudiante = new Estudiante();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("Sp_ObtenerEstudiantes", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@matricula", matricula);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    estudiante.Matricula = dr["matricula"].ToString();
                    estudiante.Nombre = dr["nombre"].ToString();
                    estudiante.Apellido = dr["apellido"].ToString();
                    estudiante.Sexo = dr["sexo"].ToString();
                    estudiante.Materia = dr["materia"].ToString();
                    estudiante.Tutor = dr["tutor"].ToString();




                }
                con.Close();

            }
            return estudiante;
        }

    }
}

