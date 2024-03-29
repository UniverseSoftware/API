﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.ServicoEmpresa
{
    public class ServicoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertServico(Servico servico)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO SERVICO (NOMESERVICO, DESCSERVICO) VALUES (@NOMESERVICO, @DESCSERVICO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMESERVICO", servico.NomeServico);
                    cmd.Parameters.AddWithValue("@DESCSERVICO", servico.DescServico);
                   
                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateServico(Servico servico)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " UPDATE SERVICO SET NOMESERVICO = @NOMESERVICO, DESCSERVICO = @DESCSERVICO ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOMESERVICO", servico.NomeServico);
                    cmd.Parameters.AddWithValue("@DESCSERVICO", servico.DescServico);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteServico(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM SERVICO WHERE IDSERVICO = @ID";
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

        public static List<Servico> GetServicos()
        {
            List<Servico> _Servico = new List<Servico>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSERVICO, NOMESERVICO, DESCSERVICO FROM SERVICO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var servico = new Servico();

                                servico.IdServico = Convert.ToInt32(dr["IDSERVICO"]);
                                servico.NomeServico = dr["NOMESERVICO"].ToString();
                                servico.DescServico = dr["DESCSERVICO"].ToString();


                                _Servico.Add(servico);
                            }
                        }
                        return _Servico;
                    }
                }
            }
        }

        public static Servico GetServico(int id)
        {
            Servico servico = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDSERVICO, NOMESERVICO, DESCSERVICO FROM SERVICO WHERE IDSERVICO = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                servico = new Servico();
                                servico.IdServico = Convert.ToInt32(dr["IDSERVICO"]);
                                servico.NomeServico = dr["NOMESERVICO"].ToString();
                                servico.DescServico = dr["DESCSERVICO"].ToString();
                            }
                        }
                        return servico;
                    }
                }
            }
        }
    }
}