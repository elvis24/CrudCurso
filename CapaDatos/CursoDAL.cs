using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CursoDAL:Conexion
    {
        public List<CursoBE> ListarCurso()
        {
            List<CursoBE> lista = new List<CursoBE>();

            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spListar_curso", con) { CommandType = CommandType.StoredProcedure })
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            CursoBE cursoBE = new CursoBE();
                            cursoBE.idCurso = Convert.ToInt32(dr["ID"]);
                            cursoBE.curso = dr["Curso"].ToString();
                            cursoBE.profesorBE.nombres = dr["PROFESOR"].ToString();
                            lista.Add(cursoBE);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public bool InsertarCurso(CursoBE cursoBE)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsetar_curso", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@curso", SqlDbType.VarChar, 50).Value = cursoBE.curso;
                        cmd.Parameters.Add("@idProfesor", SqlDbType.Int).Value = cursoBE.profesorBE.idProfesor;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        resp = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return resp;
        }

        public bool AcutalizarCurso(CursoBE cursoBE)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spActualizar_curso", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@idCurso", SqlDbType.Int).Value = cursoBE.idCurso;
                        cmd.Parameters.Add("@curso", SqlDbType.VarChar, 50).Value = cursoBE.curso;
                        cmd.Parameters.Add("@idProfesor", SqlDbType.Int).Value = cursoBE.profesorBE.idProfesor;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        resp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public CursoBE BuscarPorId(int idCurso)
        {
            CursoBE cursoBE = new CursoBE();
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spBuscarxId_curso", con) { CommandType=CommandType.StoredProcedure })
                    {
                        con.Open();
                        SqlParameter pIdCurso = new SqlParameter();
                        pIdCurso.ParameterName = "@idCurso";
                        pIdCurso.SqlDbType = SqlDbType.Int;
                        pIdCurso.Value = idCurso;
                        cmd.Parameters.Add(pIdCurso);

                        SqlDataReader dr = cmd.ExecuteReader();

                        dr.Read();
                        if (dr.HasRows)
                        {
                            cursoBE.idCurso = Convert.ToInt32(dr["ID"]);
                            cursoBE.curso = dr["Curso"].ToString();
                            cursoBE.profesorBE.nombres = dr["PROFESOR"].ToString();
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cursoBE;
        }

        public bool EliminarCurso(int idCurso)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spElminiar_curso", con) { CommandType=CommandType.StoredProcedure })
                    {
                        con.Open();

                        SqlParameter pIdCurso = new SqlParameter();
                        pIdCurso.ParameterName = "@idCurso";
                        pIdCurso.Value = idCurso;
                        cmd.Parameters.Add(pIdCurso);

                        cmd.ExecuteNonQuery();
                        resp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }
    }
}
