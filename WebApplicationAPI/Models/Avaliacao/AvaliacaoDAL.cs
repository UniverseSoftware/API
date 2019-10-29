using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Avaliacao
{
    public class AvaliacaoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertAvaliacao(Avaliacao avaliacao)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " INSERT INTO AVALIACAO (IDPEDIDO, NOTAAVALIACAO, TITULOAVALIACAO, COMENTAVALIACAO) VALUES (@IDPEDIDO, @NOTAAVALIACAO, @TITULOAVALIACAO, @COMENTAVALIACAO) ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPEDIDO", avaliacao.IdPedido);
                    cmd.Parameters.AddWithValue("@NOTAAVALIACAO", avaliacao.NotaAvaliacao);
                    cmd.Parameters.AddWithValue("@TITULOAVALIACAO", avaliacao.TituloAvaliacao);
                    cmd.Parameters.AddWithValue("@COMENTAVALIACAO", avaliacao.ComentAvaliacao);
                    
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateAvaliacao(Avaliacao avaliacao)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE AVALIACAO SET IDPEDIDO = @IDPEDIDO, NOTAAVALIACAO = @NOTAAVALIACAO, TITULOAVALIACAO = @TITULOAVALIACAO, COMENTAVALIACAO = @COMENTAVALIACAO WHERE IDEMPRESA=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPEDIDO", avaliacao.IdPedido);
                    cmd.Parameters.AddWithValue("@NOTAAVALIACAO", avaliacao.NotaAvaliacao);
                    cmd.Parameters.AddWithValue("@TITULOAVALIACAO", avaliacao.TituloAvaliacao);
                    cmd.Parameters.AddWithValue("@COMENTAVALIACAO", avaliacao.ComentAvaliacao);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteAvaliacao(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM AVALIACAO WHERE IDAVALIACAO = @ID";
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

        public static List<Avaliacao> GetAvaliacoes()
        {
            List<Avaliacao> _Avaliacoes = new List<Avaliacao>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDAVALIACAO, IDPEDIDO, NOTAAVALIACAO, TITULOAVALIACAO, COMENTAVALIACAO FROM AVALIACAO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var avaliacao = new Avaliacao();

                                avaliacao.IdAvaliacao = Convert.ToInt32(dr["IDAVALIACAO"]);
                                avaliacao.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                avaliacao.NotaAvaliacao = Convert.ToDouble(dr["NOTAAVALIACAO"]);
                                avaliacao.TituloAvaliacao = dr["TITULOAVALIACAO"].ToString();
                                avaliacao.ComentAvaliacao = dr["COMENTAVALIACAO"].ToString();
                                
                                _Avaliacoes.Add(avaliacao);
                            }
                        }
                        return _Avaliacoes;
                    }
                }
            }
        }

        public static Avaliacao GetAvaliacao(int id)
        {
            Avaliacao avaliacao = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDAVALIACAO, IDPEDIDO, NOTAAVALIACAO, TITULOAVALIACAO, COMENTAVALIACAO FROM AVALIACAO WHERE IDAVALIACAO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                avaliacao = new Avaliacao();

                                avaliacao.IdAvaliacao = Convert.ToInt32(dr["IDAVALIACAO"]);
                                avaliacao.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                avaliacao.NotaAvaliacao = Convert.ToDouble(dr["NOTAAVALIACAO"]);
                                avaliacao.TituloAvaliacao = dr["TITULOAVALIACAO"].ToString();
                                avaliacao.ComentAvaliacao = dr["COMENTAVALIACAO"].ToString();
                            }
                        }
                        return avaliacao;
                    }
                }
            }
        }
    }
}