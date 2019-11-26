using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Plano
{
    public class PlanoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPlano(Plano plano)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO PLANO (TIPOPLANO, DESCPLANO, DURAPLANO, VALORPLANO) VALUES (@TIPOPLANO, @DESCPLANO, @DURAPLANO, @VALORPLANO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TIPOPLANO", plano.TipoPlano);
                    cmd.Parameters.AddWithValue("@DESCPLANO", plano.DescPlano);
                    cmd.Parameters.AddWithValue("@DURAPLANO", plano.DuraPlano);
                    cmd.Parameters.AddWithValue("@VALORPLANO", plano.ValorPlano);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePlano(Plano plano)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE PLANO SET TIPOPLANO = @TIPOPLANO, DESCPLANO = @DESCPLANO, DURAPLANO = @DURAPLANO, VALORPLANO = @VALORPLANO WHERE IDPLANO = @ID ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID",    plano.IdPlano);
                    cmd.Parameters.AddWithValue("@TIPOPLANO",  plano.TipoPlano);
                    cmd.Parameters.AddWithValue("@DESCPLANO",  plano.DescPlano);
                    cmd.Parameters.AddWithValue("@DURAPLANO",  plano.DuraPlano);
                    cmd.Parameters.AddWithValue("@VALORPLANO", plano.ValorPlano);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePlano(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM PAGAMENTO WHERE IDPAGAMENTO = @ID";
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

        public static List<Plano> GetPlanos()
        {
            List<Plano> _Plano = new List<Plano>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPLANO, TIPOPLANO, DESCPLANO, DURAPLANO, VALORPLANO FROM PLANO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var plano = new Plano();

                                plano.IdPlano = Convert.ToInt32(dr["IDPLANO"]);
                                plano.TipoPlano = Convert.ToInt32(dr["TIPOPLANO"]);
                                plano.DescPlano = dr["DESCPLANO"].ToString();
                                plano.DuraPlano = Convert.ToInt32(dr["DURAPLANO"]);
                                plano.ValorPlano = Convert.ToDouble(dr["VALORPLANO"]);

                                _Plano.Add(plano);
                            }
                        }
                        return _Plano;
                    }
                }
            }
        }

        public static Plano GetPlano(int id)
        {
            Plano plano = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPLANO, TIPOPLANO, DESCPLANO, DURAPLANO, VALORPLANO FROM PLANO WHERE IDPLANO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                plano = new Plano();
                                plano.IdPlano = Convert.ToInt32(dr["IDPLANO"]);
                                plano.TipoPlano = Convert.ToInt32(dr["TIPOPLANO"]);
                                plano.DescPlano = dr["DESCPLANO"].ToString();
                                plano.DuraPlano = Convert.ToInt32(dr["DURAPLANO"]);
                                plano.ValorPlano = Convert.ToDouble(dr["VALORPLANO"]);
                            }
                        }
                        return plano;
                    }
                }
            }
        }
    }
}