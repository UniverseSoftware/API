﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace WebApplicationAPI.Models.CadUsuario
{
    public class CadUsuarioDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PLATPET"].ConnectionString;
        }

        public static int InsertCadUsuario(CadUsuario cadusuario,int tpuser)
        {
            int reg = 0;

            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " INSERT INTO USUARIO (USERUSUARIO,PASSUSUARIO,TIPOUSUARIO,STATUSUSUARIO) VALUES (@USER,@PASS,@TIPO,@STATUS) ";
                if (tpuser == 2)
                {
                    sql += " INSERT INTO PESSOA (IDUSUARIO,CPFPESSOA,TELPESSOA,EMAILPESSOA,ENDPESSOA,NOMEPESSOA,SOBRENOMEPESSOA)	VALUES	(SCOPE_IDENTITY() ,@CGC,@TEL,@EMAIL,@ENDE,@NOME,@SNOME) ";
                }
                else
                {
                    sql += " INSERT INTO EMPRESA	(IDUSUARIO,CNPJEMPRESA,TELEMPRESA,ENDEMPRESA,EMAILEMPRESA,NFANTASIAEMPRESA,RAZAOEMPRESA) VALUES (SCOPE_IDENTITY() ,@CGC,@TEL,@EMAIL,@ENDE,@NOME,@SNOME) ";
                }
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@USER", cadusuario.UserUsuario);
                    //cmd.Parameters.AddWithValue("@PASS", FormsAuthentication.HashPasswordForStoringInConfigFile(cadusuario.PassUsuario, "MD5"));
                    cmd.Parameters.AddWithValue("@PASS", MD5Hash(cadusuario.PassUsuario));
                    cmd.Parameters.AddWithValue("@TIPO", tpuser);
                    cmd.Parameters.AddWithValue("@STATUS", cadusuario.StatusUsuario);
                    cmd.Parameters.AddWithValue("@CGC", cadusuario.CGCEP);
                    cmd.Parameters.AddWithValue("@NOME", cadusuario.NomeEP);
                    cmd.Parameters.AddWithValue("@SNOME", cadusuario.SnomeEP);
                    cmd.Parameters.AddWithValue("@EMAIL", cadusuario.EmailEP);
                    cmd.Parameters.AddWithValue("@TEL", cadusuario.TelEP);
                    cmd.Parameters.AddWithValue("@ENDE", cadusuario.EndEP);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateCadUsuario(CadUsuario cadusuario,int tpuser)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = " UPDATE USUARIO SET USUARIO.PASSUSUARIO = @PASS, USUARIO.STATUSUSUARIO = @STATUS WHERE USUARIO.IDUSUARIO = @ID;  ";

                if (tpuser == 1)
                {
                    sql += " UPDATE EMPRESA SET EMPRESA.CNPJEMPRESA = @CGC, EMPRESA.NFANTASIAEMPRESA = @SNOME, EMPRESA.RAZAOEMPRESA = @NOME, EMPRESA.EMAILEMPRESA = @EMAIL, EMPRESA.ENDEMPRESA = @ENDE, EMPRESA.TELEMPRESA = @TEL WHERE EMPRESA.IDUSUARIO = @ID ";
                }
                else
                {
                    sql += " UPDATE PESSOA SET PESSOA.CPFPESSOA = @CGC, PESSOA.NOMEPESSOA = @NOME, PESSOA.SOBRENOMEPESSOA = @SNOME, PESSOA.EMAILPESSOA = @EMAIL, PESSOA.TELPESSOA = @TEL, PESSOA.ENDPESSOA = @ENDE WHERE PESSOA.IDUSUARIO = @ID  ";
                }

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", cadusuario.IdUsuario);
                    //cmd.Parameters.AddWithValue("@PASS", FormsAuthentication.HashPasswordForStoringInConfigFile(cadusuario.PassUsuario, "MD5"));
                    cmd.Parameters.AddWithValue("@PASS", MD5Hash(cadusuario.PassUsuario));
                    cmd.Parameters.AddWithValue("@STATUS", cadusuario.StatusUsuario);
                    cmd.Parameters.AddWithValue("@CGC", cadusuario.CGCEP);
                    cmd.Parameters.AddWithValue("@NOME", cadusuario.NomeEP);
                    cmd.Parameters.AddWithValue("@SNOME", cadusuario.SnomeEP);
                    cmd.Parameters.AddWithValue("@EMAIL", cadusuario.EmailEP);
                    cmd.Parameters.AddWithValue("@TEL", cadusuario.TelEP);
                    cmd.Parameters.AddWithValue("@ENDE", cadusuario.EndEP);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        /*
        public static int DeleteCadUsuario(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM PESSOA WHERE IDPESSOA = @IDPESSOA";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDPESSOA", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        */
        public static List<CadUsuario> GetCadUsuarios()
        {
            List<CadUsuario> _CadUsuario = new List<CadUsuario>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO AS ID,USUARIO.USERUSUARIO AS USR,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'administrador' END AS NOME,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.RAZAOEMPRESA ELSE 'platpet' END AS SNOME,USUARIO.PASSUSUARIO AS PASS,USUARIO.TIPOUSUARIO AS TIPO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAIL, STATUSUSUARIO AS STATUS,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.IDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.IDEMPRESA ELSE 0 END AS IDEP,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.CPFPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.CNPJEMPRESA ELSE '' END AS CGC,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.TELPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.TELEMPRESA ELSE '' END AS TEL,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.ENDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.ENDEMPRESA ELSE '' END AS ENDE FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO ", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var cadusuario = new CadUsuario();

                                cadusuario.IdUsuario    = Convert.ToInt32(dr["ID"]);
                                cadusuario.UserUsuario  = dr["USR"].ToString();
                                cadusuario.PassUsuario  = dr["PASS"].ToString();
                                cadusuario.TipoUsuario      = Convert.ToInt32(dr["TIPO"]);
                                cadusuario.StatusUsuario    = Convert.ToInt32(dr["STATUS"]);
                                cadusuario.IdEP         = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP        = dr["CGC"].ToString();
                                cadusuario.NomeEP       = dr["NOME"].ToString();
                                cadusuario.SnomeEP      = dr["SNOME"].ToString();
                                cadusuario.EmailEP      = dr["EMAIL"].ToString();
                                cadusuario.TelEP        = dr["TEL"].ToString();
                                cadusuario.EndEP        = dr["ENDE"].ToString();

                                _CadUsuario.Add(cadusuario);
                            }
                        }
                        return _CadUsuario;
                    }
                }
            }
        }

        public static CadUsuario GetCadUsuario(int id)
        {
            CadUsuario cadusuario = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO AS ID,USUARIO.USERUSUARIO AS USR,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'administrador' END AS NOME,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.RAZAOEMPRESA ELSE 'platpet' END AS SNOME,USUARIO.PASSUSUARIO AS PASS,USUARIO.TIPOUSUARIO AS TIPO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAIL, STATUSUSUARIO AS STATUS,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.IDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.IDEMPRESA ELSE 0 END AS IDEP,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.CPFPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.CNPJEMPRESA ELSE '' END AS CGC,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.TELPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.TELEMPRESA ELSE '' END AS TEL,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.ENDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.ENDEMPRESA ELSE '' END AS ENDE FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO WHERE USUARIO.IDUSUARIO = @ID ", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cadusuario = new CadUsuario();
                                cadusuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                                cadusuario.UserUsuario = dr["USR"].ToString();
                                cadusuario.PassUsuario = dr["PASS"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["TIPO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUS"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["CGC"].ToString();
                                cadusuario.NomeEP = dr["NOME"].ToString();
                                cadusuario.SnomeEP = dr["SNOME"].ToString();
                                cadusuario.EmailEP = dr["EMAIL"].ToString();
                                cadusuario.TelEP = dr["TEL"].ToString();
                                cadusuario.EndEP = dr["ENDE"].ToString();
                            }
                        }
                        return cadusuario;
                    }
                }
            }
        }

        public static CadUsuario GetLogin(string userusuario)
        {

            CadUsuario cadusuario = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" SELECT USUARIO.IDUSUARIO AS ID,USUARIO.USERUSUARIO AS USR,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.NOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.NFANTASIAEMPRESA ELSE 'administrador' END AS NOME,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.SOBRENOMEPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.RAZAOEMPRESA ELSE 'platpet' END AS SNOME,USUARIO.PASSUSUARIO AS PASS,USUARIO.TIPOUSUARIO AS TIPO,CASE WHEN USUARIO.TIPOUSUARIO = 1 THEN EMPRESA.EMAILEMPRESA WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.EMAILPESSOA ELSE 'UNIVERSE.SOFTWARE.2019@GMAIL.COM'	END EMAIL, STATUSUSUARIO AS STATUS,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.IDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.IDEMPRESA ELSE 0 END AS IDEP,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.CPFPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.CNPJEMPRESA ELSE '' END AS CGC,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.TELPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.TELEMPRESA ELSE '' END AS TEL,CASE WHEN USUARIO.TIPOUSUARIO = 2 THEN PESSOA.ENDPESSOA WHEN TIPOUSUARIO = 1 THEN EMPRESA.ENDEMPRESA ELSE '' END AS ENDE FROM USUARIO LEFT JOIN PESSOA  ON USUARIO.IDUSUARIO = PESSOA.IDUSUARIO LEFT JOIN EMPRESA ON USUARIO.IDUSUARIO = EMPRESA.IDUSUARIO WHERE USUARIO.USERUSUARIO = @USER ", con))
                {
                    cmd.Parameters.AddWithValue("@USER", userusuario);
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                cadusuario = new CadUsuario();
                                cadusuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                                cadusuario.UserUsuario = dr["USR"].ToString();
                                cadusuario.PassUsuario = dr["PASS"].ToString();
                                cadusuario.TipoUsuario = Convert.ToInt32(dr["TIPO"]);
                                cadusuario.StatusUsuario = Convert.ToInt32(dr["STATUS"]);
                                cadusuario.IdEP = Convert.ToInt32(dr["IDEP"]);
                                cadusuario.CGCEP = dr["CGC"].ToString();
                                cadusuario.NomeEP = dr["NOME"].ToString();
                                cadusuario.SnomeEP = dr["SNOME"].ToString();
                                cadusuario.EmailEP = dr["EMAIL"].ToString();
                                cadusuario.TelEP = dr["TEL"].ToString();
                                cadusuario.EndEP = dr["ENDE"].ToString();
                            }
                        }
                        return cadusuario;
                    }
                }
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
}