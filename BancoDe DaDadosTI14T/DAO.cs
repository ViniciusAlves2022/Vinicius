using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BancoDe_DaDadosTI14T
{
    class DAO
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        public int i;
        public string msg;
        public int contador;
        public int[] codigo;// vetor de código
        public string[] nome;//Vetor de nome
        public string[] telefone;//Vetor de telefone
        public string[] endereco;//Vetor de enderço
        public DateTime[] data;//Vetor de datas
        public string[] usuario;//Vetor de usuario
        public string[] senha;// Vetor de senha

        public DAO()
        {
            //script para conexão do banco de dados
            conexao = new MySqlConnection("server=localhost;DataBase=turma14;Uid=root;Password=;Allow Zero DateTime=True");
            try
            {
                conexao.Open();//Tentando conecatar ao BD
                Console.WriteLine("conectado com sucesso!");
                

            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                Console.ReadLine();//Manter o programa aberto
            }
        }//fim do método inserir

        public DateTime Converter(object bancoDeDados)
        {
            string texto = bancoDeDados + "";
            texto = texto.Replace("-", "/");
            DateTime dt = Convert.ToDateTime(texto);
            return dt;
        }//fim do converter
        public void Inserir(string nome, string telefone, string endereco, DateTime dtNacimento, string usuario, string senha)
        {
            try
            {
                //Modificar a estura de data
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dtNacimento.Year + "-" + dtNacimento.Month + "-" + dtNacimento.Day;
                // pareparo o código para inserção no banco 

                dados = "('','" + nome + "','" + telefone + "','" + endereco + "','" + parameter.Value + "','" + usuario + "','" + senha + "')";
                comando = "insert into pessoa(codigo, nome, telefone, endereco, dataDeNascimento) values" + dados;
                //executar o comando de inserção no banco de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();//Executa o insert no BD
                Console.WriteLine(resultado + " Linha Afetadas");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                Console.ReadLine();//Manter o programa aberto 
            }
        }//fim do método inserir


        public void preencherVetor()
        {
            string query = "select * from pessoa";//Coletar os dados do BD

            //Instanciar
            codigo   = new int[100];
            nome     = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            data     = new DateTime[100];
            usuario  = new string[100];
            senha    = new string[100];

            //Preencher com valores iniciais
            for(i=0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                data[i] = new DateTime();
                usuario[i] = "";
                senha[i] = "";
            }//fim do for 
            //Criando o comando para consultar no BD
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura dos dados do banco 
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigo[i]   = Convert.ToInt32(leitura["codigo"]);
                nome[i]     = leitura["nome"]     + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                usuario[i]  = leitura["usuario"] + "";
                senha[i]    = leitura["senha"] + "";
                data[i] = DateTime.Parse(leitura["dataDeNascimento"] + "");
                i++;
                contador++;
            }//fim do while

            //Fechar a leitura de dados no banco 
            leitura.Close();

        }//fim do método de preenchimento do vetor

        //Método que consulta TODOS OS DADOS no banco de dados

        public string ConsultarTudo(int cod)
        {
            //Preencher os vetores
            preencherVetor();
            for(i = 0; i < contador; i++)
            {
                if(codigo[i] == cod)
                {


                    msg = "Código: " + codigo[i] +
                        ", Nome: " + nome[i] +
                        ", Telefone: " + telefone[i] +
                        ", Endereço: " + endereco[i] +
                        ", Data de Nascimento:" + data[i] +
                        ", Usuario:" + usuario[i] +
                        ", Senha:" + senha[i] +
                        "\n\n";
                    return msg;
                }
            }// fim do for

            return msg;
        }// fim do método conultarTudo 


        public string ConsultarNome(int cod)
        {
            preencherVetor();
            for(i=0; i < contador; i++)
            {
                if(codigo[i] == cod)
                {
                    return[i];
                }
            }//fim do for
            return "Codigo informado não encontrado";
        }//fim do consultarNome
    }//fim da classe
}//fim do projeto