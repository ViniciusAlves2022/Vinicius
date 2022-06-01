using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDe_DaDadosTI14T
{
    class Control
    {
        //instanciar a classe DAO
        DAO conexao;//Criando a variável conexao
        public int opcao;
        public DateTime dtNascimento;
        public Control()
        {
            conexao = new DAO();//Instanciando a variável conexao
            dtNascimento = new DateTime();//00/00/0000 00:00:00
        }// fim do construtor

        public void Menu()
        {
            Console.WriteLine("Escolha uma das opç~es abaixo: \n\n" +
                                "1. Cadastrar\n" +
                                "2. Consular Tudo\n" +
                                "3. Atualizar\n" +
                                "4. Excluir\n" +
                                "5. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do menu

        public void Executar()
        {
            Menu();//Chamar o meu com todos os dados
            switch (opcao)
            {
                case 1:
                    // Coletando dados 
                    Console.WriteLine("Informe seu nome: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Informe seu telefone: ");
                    string telefone = Console.ReadLine();
                    Console.WriteLine("Informe seu enderco: ");
                    string enderco = Console.ReadLine();
                    Console.WriteLine("Informe seu data de nascimento: ");
                    dtNascimento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Informe seu usuario: ");
                    string usuario = Console.ReadLine();
                    Console.WriteLine("Informe seu senha: ");
                    string senha = Console.ReadLine();
                    //Utillizando esses dados no método inserir
                    conexao.Inserir(nome, telefone, enderco, dtNascimento, usuario, senha);
                    break;
                case 2:
                    Console.WriteLine("Código informado não é válido!");
                    break;
                default:
                    Console.WriteLine("Código informado não é válido!");
                    break;
            }//fim do switch
        }//fim do executar
    }// fim da classe
}//fim do projeto
