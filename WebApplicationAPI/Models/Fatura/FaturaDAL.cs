using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Fatura
{
    public class FaturaDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertFatura(Fatura fatura)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO FATURA (DTEFATURA, DTVFATURA, TOTFATURA, VLDFATURA, VLPFATURA) VALUES (@DTEFATURA, @DTVFATURA, @TOTFATURA, @VLDFATURA, @VLPFATURA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DTEFATURA", fatura.DteFatura);
                    cmd.Parameters.AddWithValue("@DTVFATURA", fatura.DtvFatura);
                    cmd.Parameters.AddWithValue("@TOTFATURA", fatura.TotFatura);
                    cmd.Parameters.AddWithValue("@VLDFATURA", fatura.VldFatura);
                    cmd.Parameters.AddWithValue("@VLPFATURA", fatura.VlpFatura);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateFatura(Fatura fatura)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE FATURA SET DTEFATURA = @DTEFATURA, DTVFATURA = @DTVFATURA, TOTFATURA = @TOTFATURA, VLDFATURA = @VLDFATURA, VLPFATURA = @VLPFATURA WHERE IDFATURA = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID"       , fatura.IdFatura);
                    cmd.Parameters.AddWithValue("@DTEFATURA", fatura.DteFatura);
                    cmd.Parameters.AddWithValue("@DTVFATURA", fatura.DtvFatura);
                    cmd.Parameters.AddWithValue("@TOTFATURA", fatura.TotFatura);
                    cmd.Parameters.AddWithValue("@VLDFATURA", fatura.VldFatura);
                    cmd.Parameters.AddWithValue("@VLPFATURA", fatura.VlpFatura);


                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteFatura(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM FATURA WHERE IDFATURA = @ID";
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

        public static List<Fatura> GetFaturas()
        {
            List<Fatura> _Faturas = new List<Fatura>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDFATURA, DTEFATURA, DTVFATURA, TOTFATURA, VLDFATURA, VLPFATURA FROM FATURA ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var fatura = new Fatura();

                                fatura.IdFatura = Convert.ToInt32(dr["IDFATURA"]);
                                fatura.DteFatura = Convert.ToDateTime(dr["DTEFATURA"]);
                                fatura.DtvFatura = Convert.ToDateTime(dr["DTVFATURA"]);
                                fatura.TotFatura = Convert.ToDouble(dr["TOTFATURA"]);
                                fatura.VldFatura = Convert.ToDouble(dr["VLDFATURA"]);
                                fatura.VlpFatura = Convert.ToDouble(dr["VLPFATURA"]);

                                _Faturas.Add(fatura);
                            }
                        }
                        return _Faturas;
                    }
                }
            }
        }

        public static Fatura GetFatura(int id)
        {
            Fatura fatura = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDFATURA, DTEFATURA, DTVFATURA, TOTFATURA, VLDFATURA, VLPFATURA FROM FATURA WHERE IDFATURA = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                fatura = new Fatura();
                                fatura.IdFatura = Convert.ToInt32(dr["IDFATURA"]);
                                fatura.DteFatura = Convert.ToDateTime(dr["DTEFATURA"]);
                                fatura.DtvFatura = Convert.ToDateTime(dr["DTVFATURA"]);
                                fatura.TotFatura = Convert.ToDouble(dr["TOTFATURA"]);
                                fatura.VldFatura = Convert.ToDouble(dr["VLDFATURA"]);
                                fatura.VlpFatura = Convert.ToDouble(dr["VLPFATURA"]);
                            }
                        }
                        return fatura;
                    }
                }
            }
        }
    }
}