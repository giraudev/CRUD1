using System;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD

{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;

        SqlDataReader rd;


        public bool Adicionar(Categoria cat)
        {
            bool rs = false;

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria; user id = ***; password = ******;";
                //comando open (abre o banco de dados) não pode ficar acima do connectionString
                cn.Open();
                comandos = new SqlCommand();
                //onde os comandos devem ser conectados
                comandos.Connection = cn;
                //qual o tipo de comando que iremos executar, neste exemplo será texto:
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "insert into categorias (titulo) values (@titulo)";
                //add parametro com valor:
                comandos.Parameters.AddWithValue("@titulo", cat.Titulo);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;
                //limpar os parametros para nao dar problema
                comandos.Parameters.Clear();
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
                cn.Close();
            }
            return rs;
        }

        public bool Atualizar(Categoria cat)
        {
            bool rs = false;

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria; user id = ***; password = ******;";
                //comando open (abre o banco de dados) não pode ficar acima do connectionString
                cn.Open();
                comandos = new SqlCommand();
                //onde os comandos devem ser conectados
                comandos.Connection = cn;
                //qual o tipo de comando que iremos executar, neste exemplo será texto:
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "update categoria set titulo = @titulo where idcategoria=@vn)";
                //add parametro com valor:
                comandos.Parameters.AddWithValue("@titulo", cat.Titulo);
                comandos.Parameters.AddWithValue("@vn", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;
                //limpar os parametros para nao dar problema
                comandos.Parameters.Clear();
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
                cn.Close();
            }
            return rs;
        }

        public bool Deletar(Categoria cat)
        {
            bool rs = false;

            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria; user id = ***; password = ******;";
                //comando open (abre o banco de dados) não pode ficar acima do connectionString
                cn.Open();
                comandos = new SqlCommand();
                //onde os comandos devem ser conectados
                comandos.Connection = cn;
                //qual o tipo de comando que iremos executar, neste exemplo será texto:
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "delete from categoria where idcategoria=@vn)";
                //add parametro com valor:
                comandos.Parameters.AddWithValue("@vn", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;
                //limpar os parametros para nao dar problema
                comandos.Parameters.Clear();
            }
            //catch do sql
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar. " + se.Message);
            }
            //catch do c#
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            //colocar o close do bd fora do try e do catch, dentro do finally
            finally
            {
                cn.Close();
            }
            return rs;
        }



    }
}