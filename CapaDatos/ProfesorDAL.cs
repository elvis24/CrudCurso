using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProfesorDAL:Conexion
    {
        public List<ProfesorBE> ListaProfesor()
        {
            List<ProfesorBE> lista = new List<ProfesorBE>();
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spListar_profesor", con) { CommandType = CommandType.StoredProcedure })
                    {
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ProfesorBE profesorBE = new ProfesorBE();
                            profesorBE.idProfesor = Convert.ToInt32(dr["ID"]);
                            profesorBE.nombres = dr["NOMBRES"].ToString();
                            profesorBE.apellidosPat = dr["APELLIDO PATERNO"].ToString();
                            profesorBE.apellidoMat = dr["APELLIDO MATERNO"].ToString();

                            lista.Add(profesorBE);
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

        public bool InsertarProfesor(ProfesorBE profesorBE)
        {
            bool resp = false;
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertar_profesor", con) { CommandType=CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = profesorBE.nombres;
                        cmd.Parameters.Add("@apePat", SqlDbType.VarChar, 50).Value = profesorBE.apellidosPat;
                        cmd.Parameters.Add("@apeMat", SqlDbType.VarChar, 50).Value = profesorBE.apellidoMat;

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

        public ProfesorBE BuscarPorID(int idProfesor)
        {
            ProfesorBE profesorBE = new ProfesorBE();
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    //using (SqlCommand cmd = new SqlCommand("spConsultarId", con) { CommandType=CommandType.StoredProcedure })
                    //{
                    //    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = profesorBE.idProfesor;
                    //    con.Open();



                    //    SqlDataReader dr = cmd.ExecuteReader();

                    //    dr.Read();
                    //    if (dr.HasRows)
                    //    {

                    //        profesorBE.idProfesor = Convert.ToInt32(dr["ID"]);
                    //        profesorBE.nombres = dr["NOMBRES"].ToString();
                    //        profesorBE.apellidosPat = dr["APELLIDO PATERNO"].ToString();
                    //        profesorBE.apellidoMat = dr["APELLIDO MATERNO"].ToString();
                    //    }
                    //}
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spConsultarId", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter pIdProfesor = new SqlParameter();
                    pIdProfesor.ParameterName = "@id";
                    pIdProfesor.SqlDbType = SqlDbType.Int;
                    pIdProfesor.Value = idProfesor;
                    cmd.Parameters.Add(pIdProfesor);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    if (dr.HasRows)
                    {

                        profesorBE.idProfesor = Convert.ToInt32(dr["ID"]);
                        profesorBE.nombres = dr["NOMBRES"].ToString();
                        profesorBE.apellidosPat = dr["APELLIDO PATERNO"].ToString();
                        profesorBE.apellidoMat = dr["APELLIDO MATERNO"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return profesorBE;
        }

        public bool ActualizarProfesor(ProfesorBE profesorBE)
        {
            bool resp = false;
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spActualizar_profesor", con) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 50)).Value = profesorBE.idProfesor;
                        cmd.Parameters.Add(new SqlParameter("@nombres", SqlDbType.VarChar, 50)).Value = profesorBE.nombres;
                        cmd.Parameters.Add(new SqlParameter("@apePat", SqlDbType.VarChar, 50)).Value = profesorBE.apellidosPat;
                        cmd.Parameters.Add(new SqlParameter("@apeMat", SqlDbType.VarChar, 50)).Value = profesorBE.apellidoMat;

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

        public bool EliminarProfesor(int idProfesor)
        {
            bool elimina = false;
            try
            {
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spEliminar_profesor", con) { CommandType = CommandType.StoredProcedure})
                    {
                        con.Open();
                        SqlParameter pIdProfesor = new SqlParameter();
                        pIdProfesor.ParameterName = "@id";
                        pIdProfesor.Value = idProfesor;
                        cmd.Parameters.Add(pIdProfesor);

                        cmd.ExecuteNonQuery();
                        elimina = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return elimina;
        }
    }
}
