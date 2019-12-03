using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.ServicoEmpresa
{
    public class ServicoEmpresaDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertServicoEmpresa(ServicoEmpresa servicoempresa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " INSERT INTO SERV_EMPR (IDEMPRESA, IDSERVICO, VLSERV_EMPR) VALUES (@IDEMPRESA, @IDSERVICO, @VLSERV_EMPR) ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDEMPRESA", servicoempresa.IdEmpresa);
                    cmd.Parameters.AddWithValue("@IDSERVICO", servicoempresa.IdServico);
                    cmd.Parameters.AddWithValue("@VLSERV_EMPR", servicoempresa.VlServicoEmpresa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateServicoEmpresa(ServicoEmpresa servicoempresa)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " UPDATE SERV_EMPR SET IDEMPRESA = @IDEMPRESA, IDSERVICO = @IDSERVICO, VLSERV_EMPR = @VLSERV_EMPR WHERE IDSERV_EMPR = @ID ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", servicoempresa.IdServicoEmpresa);
                    cmd.Parameters.AddWithValue("@NOMESERVICO", servicoempresa.IdEmpresa);
                    cmd.Parameters.AddWithValue("@DESCSERVICO", servicoempresa.IdServico);
                    cmd.Parameters.AddWithValue("@VLSERV_EMP", servicoempresa.VlServicoEmpresa);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteServicoEmpresa(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM SERV_EMPR WHERE IDSERV_EMPR = @ID";
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

        public static List<ServicoEmpresa> GetServicoEmpresas()
        {
            List<ServicoEmpresa> _ServicoEmpresa = new List<ServicoEmpresa>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSERV_EMPR,IDEMPRESA, SE.IDSERVICO, VLSERV_EMPR, NOMESERVICO FROM SERV_EMPR SE INNER JOIN SERVICO S ON  SE.IDSERVICO = S.IDSERVICO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var servicoempresa = new ServicoEmpresa();

                                servicoempresa.IdServicoEmpresa = Convert.ToInt32(dr["IDSERV_EMPR"]);
                                servicoempresa.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                servicoempresa.IdServico = Convert.ToInt32(dr["IDSERVICO"]);
                                servicoempresa.VlServicoEmpresa = Convert.ToDouble(dr["VLSERV_EMPR"]);
                                servicoempresa.NomeServico = dr["NOMESERVICO"].ToString();

                                _ServicoEmpresa.Add(servicoempresa);
                            }
                        }
                        return _ServicoEmpresa;
                    }
                }
            }
        }

        public static ServicoEmpresa GetServicoEmpresa(int id)
        {
            ServicoEmpresa servicoempresa = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSERV_EMPR,IDEMPRESA, SE.IDSERVICO, VLSERV_EMPR, NOMESERVICO FROM SERV_EMPR SE INNER JOIN SERVICO S ON  SE.IDSERVICO = S.IDSERVICO WHERE IDEMPRESA = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                servicoempresa = new ServicoEmpresa();

                                servicoempresa.IdServicoEmpresa = Convert.ToInt32(dr["IDSERV_EMPR"]);
                                servicoempresa.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                servicoempresa.IdServico = Convert.ToInt32(dr["IDSERVICO"]);
                                servicoempresa.VlServicoEmpresa = Convert.ToDouble(dr["VLSERV_EMPR"]);
                                servicoempresa.NomeServico = dr["NOMESERVICO"].ToString();
                            }
                        }
                        return servicoempresa;
                    }
                }
            }
        }

        public static List<ServicoEmpresa> GetServicosEmpresas(int id)
        {
            List<ServicoEmpresa> _ServicoEmpresa = new List<ServicoEmpresa>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSERV_EMPR,IDEMPRESA, SE.IDSERVICO, VLSERV_EMPR, NOMESERVICO FROM SERV_EMPR SE INNER JOIN SERVICO S ON  SE.IDSERVICO = S.IDSERVICO  WHERE IDEMPRESA = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var servicoempresa = new ServicoEmpresa();

                                servicoempresa.IdServicoEmpresa = Convert.ToInt32(dr["IDSERV_EMPR"]);
                                servicoempresa.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                servicoempresa.IdServico = Convert.ToInt32(dr["IDSERVICO"]);
                                servicoempresa.VlServicoEmpresa = Convert.ToDouble(dr["VLSERV_EMPR"]);
                                servicoempresa.NomeServico = dr["NOMESERVICO"].ToString();

                                _ServicoEmpresa.Add(servicoempresa);
                            }
                        }
                        return _ServicoEmpresa;
                    }
                }
            }
        }

    }
}