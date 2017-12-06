using System;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class ClientesCRUD
    {
        SqlConnection cnClient;
        SqlCommand comandosClient;

        SqlDataReader rdClient;
        public bool Adicionar(Clientes client)
        {
            bool rs = false;

            try
            {
                cnClient = new SqlConnection();
                cnClient.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=nomedobanco; user id = usuario; password = senha;";
                //comando open (abre o banco de dados) não pode ficar acima do connectionString
                cnClient.Open();
                comandosClient = new SqlCommand();
                //onde os comandos devem ser conectados
                comandosClient.Connection = cnClient;
                //qual o tipo de comando que iremos executar, neste exemplo será texto:
                comandosClient.CommandType = CommandType.Text;
                comandosClient.CommandText = "insert into clientes (nomecliente, email, cpf) values (@nomeC, @emailC,@cpf)";
                //add parametro com valor:
                comandosClient.Parameters.AddWithValue("@nomeC", client.NomeCliente);
                comandosClient.Parameters.AddWithValue("@emailC", client.Email);
                comandosClient.Parameters.AddWithValue("@cpf", client.CPF);

                int r = comandosClient.ExecuteNonQuery();
                if (r > 0)
                    rs = true;
                //limpar os parametros para nao dar problema
                comandosClient.Parameters.Clear();
            }
            //catch do sql
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar cadastrar. " + se.Message);
            }
            //catch do c#
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            //colocar o close do bd fora do try e do catch, dentro do finally
            finally
            {
                cnClient.Close();
            }
            return rs;
        }

        public bool Atualizar(Clientes client)
        {
            bool rs = false;

            try
            {
                cnClient = new SqlConnection();
                cnClient.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=nomedobanco; user id = usuario; password = senha;";
                //comando open (abre o banco de dados) não pode ficar acima do connectionString
                cnClient.Open();
                comandosClient = new SqlCommand();
                //onde os comandos devem ser conectados
                comandosClient.Connection = cnClient;
                //qual o tipo de comando que iremos executar, neste exemplo será texto:
                comandosClient.CommandType = CommandType.Text;
                comandosClient.CommandText = "update clientes set nomecliente = @nomeC where idCliente=@vn";
                //add parametro com valor:
                comandosClient.Parameters.AddWithValue("@nomeC", client.NomeCliente);
                comandosClient.Parameters.AddWithValue("@vn", client.IdCliente);

                int r = comandosClient.ExecuteNonQuery();
                if (r > 0)
                    rs = true;
                //limpar os parametros para nao dar problema
                comandosClient.Parameters.Clear();
            }
            //catch do sql
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar. " + se.Message);
            }
            //catch do c#
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            //colocar o close do bd fora do try e do catch, dentro do finally
            finally
            {
                cnClient.Close();
            }
            return rs;
        }

    }
}