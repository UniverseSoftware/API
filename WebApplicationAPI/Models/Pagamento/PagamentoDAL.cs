using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Pagamento
{
    public class PagamentoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPagamento(Pagamento pagamento)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO PAGAMENTO (DESCPAGAMENTO) VALUES (@DESCPAGAMENTO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DESCPAGAMENTO", pagamento.DescPagamento);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePagamento(Pagamento pagamento)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE PAGAMENTO SET DESCPAGAMENTO = @DESCPAGAMENTO ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DESCPAGAMENTO", pagamento.DescPagamento);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePagamento(int id)
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

        public static List<Pagamento> GetPagamentos()
        {
            List<Pagamento> _Pagamento = new List<Pagamento>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPAGAMENTO, DESCPAGAMENTO FROM PAGAMENTO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pagamento = new Pagamento();

                                pagamento.IdPagamento = Convert.ToInt32(dr["IDPAGAMENTO"]);
                                pagamento.DescPagamento = dr["DESCPAGAMENTO"].ToString();

                                _Pagamento.Add(pagamento);
                            }
                        }
                        return _Pagamento;
                    }
                }
            }
        }

        public static Pagamento GetPagamento(int id)
        {
            Pagamento pagamento = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDPAGAMENTO, DESCPAGAMENTO FROM PAGAMENTO WHERE IDPAGAMENTO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                pagamento = new Pagamento();
                                pagamento.IdPagamento = Convert.ToInt32(dr["IDPAGAMENTO"]);
                                pagamento.DescPagamento = dr["DESCPAGAMENTO"].ToString();
                            }
                        }
                        return pagamento;
                    }
                }
            }
        }
    }
}