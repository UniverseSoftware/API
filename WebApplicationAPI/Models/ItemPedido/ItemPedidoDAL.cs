using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace WebApplicationAPI.Models.ItemPedido
{
    public class ItemPedidoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertItemPedido(ItemPedido itempedido)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO ITEMPEDIDO (IDPEDIDO, ITEMPEDIDO, IDSERV_EMPR, QTDSERVICO, VLSERVICO, TOTSERVICO, OBSSERVICO,IDFATURA) VALUES (@IDPEDIDO, @ITEMPEDIDO, @IDSERV_EMPR, @QTDSERVICO, @VLSERVICO, @TOTSERVICO, @OBSSERVICO, @IDFATURA)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPEDIDO", itempedido.IdPedido);
                    cmd.Parameters.AddWithValue("@ITEMPEDIDO", itempedido.itemPedido);
                    cmd.Parameters.AddWithValue("@IDSERV_EMPR", itempedido.IdServicoEmpresa);
                    cmd.Parameters.AddWithValue("@QTDSERVICO", itempedido.QtdServico);
                    cmd.Parameters.AddWithValue("@VLSERVICO", itempedido.VlServico);
                    cmd.Parameters.AddWithValue("@TOTSERVICO", itempedido.TotServico);
                    cmd.Parameters.AddWithValue("@OBSSERVICO", itempedido.ObsServico);
                    cmd.Parameters.AddWithValue("@IDFATURA", itempedido.IdFatura);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateItemPedido(ItemPedido itempedido)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE ITEMPEDIDO SET IDPEDIDO=@IDPEDIDO, ITEMPEDIDO=@ITEMPEDIDO, IDSERV_EMPR=@IDSERV_EMPR, QTDSERVICO=@QTDSERVICO, VLSERVICO=@VLSERVICO, TOTSERVICO=@TOTSERVICO, OBSSERVICO=@OBSSERVICO,IDFATURA=@IDFATURA WHERE IDITEMPEDIDO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", itempedido.IdItemPedido);
                    cmd.Parameters.AddWithValue("@IDPEDIDO", itempedido.IdPedido);
                    cmd.Parameters.AddWithValue("@ITEMPEDIDO", itempedido.itemPedido);
                    cmd.Parameters.AddWithValue("@IDSERV_EMPR", itempedido.IdServicoEmpresa);
                    cmd.Parameters.AddWithValue("@QTDSERVICO", itempedido.QtdServico);
                    cmd.Parameters.AddWithValue("@VLSERVICO", itempedido.VlServico);
                    cmd.Parameters.AddWithValue("@TOTSERVICO", itempedido.TotServico);
                    cmd.Parameters.AddWithValue("@OBSSERVICO", itempedido.ObsServico);
                    cmd.Parameters.AddWithValue("@IDFATURA", itempedido.IdFatura);


                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteItemPedido(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM ITEMPEDIDO WHERE IDITEMPEDIDO = @ID";
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

        public static List<ItemPedido> GetItemPedidos()
        {
            List<ItemPedido> _ItemPedidos = new List<ItemPedido>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDITEMPEDIDO, IDPEDIDO, ITEMPEDIDO, IDSERV_EMPR, QTDSERVICO, VLSERVICO, TOTSERVICO, OBSSERVICO,IDFATURA FROM ITEMPEDIDO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var itempedido = new ItemPedido();

                                itempedido.IdItemPedido = Convert.ToInt32(dr["IDITEMPEDIDO"]);
                                itempedido.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                itempedido.itemPedido = Convert.ToInt32(dr["ITEMPEDIDO"]);
                                itempedido.IdServicoEmpresa = Convert.ToInt32(dr["IDSERV_EMPR"]);
                                itempedido.QtdServico = Convert.ToInt32(dr["QTDSERVICO"]);
                                itempedido.VlServico = Convert.ToDouble(dr["VLSERVICO"]);
                                itempedido.TotServico = Convert.ToDouble(dr["TOTSERVICO"]);
                                itempedido.ObsServico = (dr["OBSSERVICO"]).ToString();
                                itempedido.IdFatura = Convert.ToInt32(dr["IDFATURA"]);


                                _ItemPedidos.Add(itempedido);
                            }
                        }
                        return _ItemPedidos;
                    }
                }
            }
        }

        public static ItemPedido GetItemPedido(int id)
        {
            ItemPedido itempedido = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT IDITEMPEDIDO, IDPEDIDO, ITEMPEDIDO, IDSERV_EMPR, QTDSERVICO, VLSERVICO, TOTSERVICO, OBSSERVICO,IDFATURA FROM ITEMPEDIDO WHERE IDITEMPEDIDO = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                itempedido = new ItemPedido();
                                itempedido.IdItemPedido = Convert.ToInt32(dr["IDITEMPEDIDO"]);
                                itempedido.IdPedido = Convert.ToInt32(dr["IDPEDIDO"]);
                                itempedido.itemPedido = Convert.ToInt32(dr["ITEMPEDIDO"]);
                                itempedido.IdServicoEmpresa = Convert.ToInt32(dr["IDSERV_EMPR"]);
                                itempedido.QtdServico = Convert.ToInt32(dr["QTDSERVICO"]);
                                itempedido.VlServico = Convert.ToDouble(dr["VLSERVICO"]);
                                itempedido.TotServico = Convert.ToDouble(dr["TOTSERVICO"]);
                                itempedido.ObsServico = (dr["OBSSERVICO"]).ToString();
                                itempedido.IdFatura = Convert.ToInt32(dr["IDFATURA"]);
                            }
                        }
                        return itempedido;
                    }
                }
            }
        }
    }
}