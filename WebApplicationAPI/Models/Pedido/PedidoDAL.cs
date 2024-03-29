﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationAPI.Models.Pedido
{
    public class PedidoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertPedido(Pedido pedido)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO PEDIDO (IDEMPRESA, IDPAGAMENTO, IDPET, TOTPEDIDO) VALUES (@IDEMPRESA, @IDPAGAMENTO, @IDPET, @TOTPEDIDO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDEMPRESA", pedido.IdEmpresa);
                    cmd.Parameters.AddWithValue("@IDPAGAMENTO", pedido.IdPagamento);
                    cmd.Parameters.AddWithValue("@IDPET", pedido.IdPet);
                    cmd.Parameters.AddWithValue("@TOTPEDIDO", pedido.TotPedido);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdatePedido(Pedido pedido)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE PEDIDO SET IDEMPRESA = @IDEMPRESA, IDPAGAMENTO = @IDPAGAMENTO, IDPET = @IDPET, TOTPEDIDO = @TOTPEDIDO WHERE IDPEDIDO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", pedido.IdPedido);
                    cmd.Parameters.AddWithValue("@IDEMPRESA", pedido.IdEmpresa);
                    cmd.Parameters.AddWithValue("@IDPAGAMENTO", pedido.IdPagamento);
                    cmd.Parameters.AddWithValue("@IDPET", pedido.IdPet);
                    cmd.Parameters.AddWithValue("@TOTPEDIDO", pedido.TotPedido);


                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeletePedido(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM PEDIDO WHERE IDPEDIDO = @ID";
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

        public static List<Pedido> GetPedidos()
        {
            List<Pedido> _Pedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT PD.IDPEDIDO, PD.IDEMPRESA, EM.RAZAOEMPRESA, PD.IDPAGAMENTO, PA.DESCPAGAMENTO, PD.IDPET, P.NOMEPET, P.IDPESSOA, PE.NOMEPESSOA ,PD.TOTPEDIDO  FROM PEDIDO PD  INNER JOIN PET P ON PD.IDPET = P.IDPET  INNER JOIN PESSOA PE ON P.IDPESSOA = PE.IDPESSOA INNER JOIN PAGAMENTO PA ON PD.IDPAGAMENTO = PA.IDPAGAMENTO INNER JOIN EMPRESA EM ON PD.IDEMPRESA = EM.IDEMPRESA ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pedido = new Pedido();

                                pedido.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                pedido.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                pedido.NomeEmpresa = dr["RAZAOEMPRESA"].ToString();
                                pedido.IdPagamento = Convert.ToInt32(dr["IDPAGAMENTO"]);
                                pedido.DescPagamento = dr["DESCPAGAMENTO"].ToString();
                                pedido.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pedido.NomePet = dr["NOMEPET"].ToString();
                                pedido.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pedido.NomePessoa = dr["NOMEPESSOA"].ToString();
                                pedido.TotPedido = Convert.ToDouble(dr["TOTPEDIDO"]);
                                                         
                                _Pedidos.Add(pedido);
                            }
                        }
                        return _Pedidos;
                    }
                }
            }
        }

        public static Pedido GetPedido(int id)
        {
            Pedido pedido = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT PD.IDPEDIDO, PD.IDEMPRESA, EM.RAZAOEMPRESA, PD.IDPAGAMENTO, PA.DESCPAGAMENTO, PD.IDPET, P.NOMEPET, P.IDPESSOA, PE.NOMEPESSOA ,PD.TOTPEDIDO  FROM PEDIDO PD  INNER JOIN PET P ON PD.IDPET = P.IDPET  INNER JOIN PESSOA PE ON P.IDPESSOA = PE.IDPESSOA INNER JOIN PAGAMENTO PA ON PD.IDPAGAMENTO = PA.IDPAGAMENTO INNER JOIN EMPRESA EM ON PD.IDEMPRESA = EM.IDEMPRESA WHERE PD.IDPEDIDO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                pedido = new Pedido();
                                pedido.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                pedido.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                pedido.NomeEmpresa = dr["RAZAOEMPRESA"].ToString();
                                pedido.IdPagamento = Convert.ToInt32(dr["IDPAGAMENTO"]);
                                pedido.DescPagamento = dr["DESCPAGAMENTO"].ToString();
                                pedido.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pedido.NomePet = dr["NOMEPET"].ToString();
                                pedido.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pedido.NomePessoa = dr["NOMEPESSOA"].ToString();
                                pedido.TotPedido = Convert.ToDouble(dr["TOTPEDIDO"]);
                            }
                        }
                        return pedido;
                    }
                }
            }
        }

        public static List<Pedido> GetPedidosPessoa(int id)
        {
            List<Pedido> _Pedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT PD.IDPEDIDO, PD.IDEMPRESA, EM.RAZAOEMPRESA, PD.IDPAGAMENTO, PA.DESCPAGAMENTO, PD.IDPET, P.NOMEPET, P.IDPESSOA, PE.NOMEPESSOA ,PD.TOTPEDIDO  FROM PEDIDO PD  INNER JOIN PET P ON PD.IDPET = P.IDPET  INNER JOIN PESSOA PE ON P.IDPESSOA = PE.IDPESSOA INNER JOIN PAGAMENTO PA ON PD.IDPAGAMENTO = PA.IDPAGAMENTO INNER JOIN EMPRESA EM ON PD.IDEMPRESA = EM.IDEMPRESA WHERE P.IDPESSOA = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var pedido = new Pedido();

                                pedido.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                pedido.IdEmpresa = Convert.ToInt32(dr["IDEMPRESA"]);
                                pedido.NomeEmpresa = dr["RAZAOEMPRESA"].ToString();
                                pedido.IdPagamento = Convert.ToInt32(dr["IDPAGAMENTO"]);
                                pedido.DescPagamento = dr["DESCPAGAMENTO"].ToString();
                                pedido.IdPet = Convert.ToInt32(dr["IDPET"]);
                                pedido.NomePet = dr["NOMEPET"].ToString();
                                pedido.IdPessoa = Convert.ToInt32(dr["IDPESSOA"]);
                                pedido.NomePessoa = dr["NOMEPESSOA"].ToString();
                                pedido.TotPedido = Convert.ToDouble(dr["TOTPEDIDO"]);

                                _Pedidos.Add(pedido);
                            }
                        }
                        return _Pedidos;
                    }
                }
            }
        }

    }
}