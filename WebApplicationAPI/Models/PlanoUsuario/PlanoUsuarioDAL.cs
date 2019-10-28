using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.PlanoUsuario
{
    public class PlanoUsuarioDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPlanoUsuario(PlanoUsuario planousuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO USR_PLANO (IDPLANO, IDUSUARIO, VALIDUSR_PLANO) VALUES (@IDPLANO, @IDUSUARIO, @VALIDUSR_PLANO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPLANO", planousuario.IdPlano);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", planousuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@VALIDUSR_PLANO", planousuario.ValidUsuarioPlano);
                   
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePlanoUsuario(PlanoUsuario planousuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE USR_PLANO SET IDPLANO = @IDPLANO, IDUSUARIO = @IDUSUARIO, VALIDUSR_PLANO = @VALIDUSR_PLANO ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPLANO", planousuario.IdPlano);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", planousuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@VALIDUSR_PLANO", planousuario.ValidUsuarioPlano);


                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePlanoUsuario(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM USR_PLANO WHERE IDUSR_PLANO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<PlanoUsuario> GetPlanoUsuarios()
        {
            List<PlanoUsuario> _PlanoUsuario = new List<PlanoUsuario>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSR_PLANO, IDPLANO, IDUSUARIO, VALIDUSR_PLANO FROM USR_PLANO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var planousuario = new PlanoUsuario();

                                planousuario.IdUsuarioPlano = Convert.ToInt32(dr["IDUSR_PLANO"]);
                                planousuario.IdPlano = Convert.ToInt32(dr["IDPLANO"]);
                                planousuario.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                planousuario.ValidUsuarioPlano = Convert.ToInt32(dr["VALIDUSR_PLANO"]);

                                _PlanoUsuario.Add(planousuario);
                            }
                        }
                        return _PlanoUsuario;
                    }
                }
            }
        }

        public static PlanoUsuario GetPlanoUsuario(int id)
        {
            PlanoUsuario planousuario = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSR_PLANO, IDPLANO, IDUSUARIO, VALIDUSR_PLANO FROM USR_PLANO WHERE IDUSR_PLANO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                planousuario = new PlanoUsuario();

                                planousuario.IdUsuarioPlano = Convert.ToInt32(dr["IDUSR_PLANO"]);
                                planousuario.IdPlano = Convert.ToInt32(dr["IDPLANO"]);
                                planousuario.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                                planousuario.ValidUsuarioPlano = Convert.ToInt32(dr["VALIDUSR_PLANO"]);
                            }
                        }
                        return planousuario;
                    }
                }
            }
        }
    }
}