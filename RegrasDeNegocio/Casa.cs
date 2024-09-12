using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestaoCondominio.RegrasDeNegocio
{
    public class Casa
    {
        //atributos
        public int Id { get; set; }
        public int Serie { get; set; }
        public string NomeTurma { get; set; }

        public List<Pessoa> AlunosMatriculados { get; set; }
        //metodo construtor

        public Casa(int id, int serie, string nomeTurma)
        {
            this.Id = id;
            this.Serie = serie;
            this.NomeTurma = nomeTurma;
            AlunosMatriculados = new List<Pessoa>();

        }

        int cont = 1;
        int posicao = 0;
        byte opcao = 0;
        double contemA = 0;
        double contemR = 0;
        double contT = 0;
        public void CadastrarAlunos()
        {
            int opc = 1;
            while (opc != 0)
            {
                Console.Clear();
                Console.WriteLine("* + * + * + * + * + * + * + CADASTRAR ALUNO * + * + * + * + * + * + * +");
                Console.WriteLine();
                Aluno aluno = new Aluno();
                aluno.Id = AlunosMatriculados.Count + 1;
                aluno.NumeroDeMatricula = AlunosMatriculados.Count + 1000;
                Console.Write("Nome.....................: ");
                aluno.Nome = Console.ReadLine();
                Console.Write("Nota 1.....................: ");
                aluno.Nota1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nota 2.....................: ");
                aluno.Nota2 = Convert.ToDouble(Console.ReadLine());
                // colocar o aluno na lista (matricular-los)
                AlunosMatriculados.Add(aluno);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n                            * + * + * + * + * + * + * + ALUNO CADASTRADO COM SUCESSO * + * + * + * + * + * + * +");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Deseja continuar cadastrando???(S/N)");
                var resp = Console.ReadLine().ToUpper();
                if (resp == "N") opc = 0;

            }

        }//fim do metodo cadastrar alunos
        public void ConsultarAluno()
        {
            int OPC = 1;
            while (OPC != 0)
            {
                Console.Clear();
                Console.WriteLine("* + * + * + * + * + * + * + CONSULTAR ALUNO * + * + * + * + * + * + * +");
                Console.WriteLine();
                Console.WriteLine($"Serie/Turma {Serie}/{NomeTurma}");

                Console.Write("Nome.....................:");
                var nome = Console.ReadLine().ToUpper();
                var aluno = AlunosMatriculados.Where(a => a.Nome.ToUpper() == nome).FirstOrDefault();
                if (aluno != null)
                {
                    Console.Clear();
                    Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + ");
                    Console.WriteLine($"N° Matricula.....................{aluno.NumeroDeMatricula}");
                    Console.WriteLine($"Nome.....................{aluno.Nome}");
                    Console.WriteLine($"Nota 1.....................{aluno.Nota1}");
                    Console.WriteLine($"Nota 2.....................{aluno.Nota2}");
                    Console.WriteLine($"Media.....................{aluno.CalcularMedia()}");
                    Console.WriteLine($"Situação.....................{aluno.VerificarSituacao()}");
                    Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + \n");
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("--> ALUNO NÃO ENCONTRADO <--");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Deseja continuar consultando? (S/N).........: ");
                var resp = Console.ReadLine().ToUpper();
                if (resp == "N") OPC = 0;
            }

        }// fim do metodo consultar aluno
        public void FiltrarAluno()
        {
            Console.Clear();
            Console.WriteLine("* + * + * + * + * + * + * + FILTRAR ALUNO POR NOME * + * + * + * + * + * + * +");
            Console.WriteLine();
            Console.Write("Pesquisar Nome.....................: ");
            var nome = Console.ReadLine();

            var consultarAluno = AlunosMatriculados.Where(aluno => aluno.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
            foreach (var aluno in consultarAluno.OrderBy(x => x.Nome).ToList())
            {
                Console.WriteLine("\n\n* + * + * + * + * + * + * + * + * + * + * + * + * + * + ");
                Console.WriteLine($"N° Matricula.....................{aluno.NumeroDeMatricula}");
                Console.WriteLine($"Nome.....................{aluno.Nome}");
                Console.WriteLine($"Nota 1.....................{aluno.Nota1}");
                Console.WriteLine($"Nota 2.....................{aluno.Nota2}");
                Console.WriteLine($"Media.....................{aluno.CalcularMedia()}");
                Console.WriteLine($"Situação.....................{aluno.VerificarSituacao()}");
                Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + \n");

            }
            Console.ReadKey();

        }// fim do metodo filtrar alunos
        public void ListarAlunosAprovados()
        {
            Console.Clear();
            Console.WriteLine("* + * + * + * + * + * + * + LISTAR ALUNOS APROVADOS * + * + * + * + * + * + * + \n");

            var alunosAprovados = AlunosMatriculados.Where(aluno => aluno.CalcularMedia() >= 60).ToList();
            foreach (var aluno in alunosAprovados.OrderBy(x => x.Nome).ToList())
            {
                Console.WriteLine("\n\n* + * + * + * + * + * + * + * + * + * + * + * + * + * + ");
                Console.WriteLine($"N° Matricula.....................{aluno.NumeroDeMatricula}");
                Console.WriteLine($"Nome.....................{aluno.Nome}");
                Console.WriteLine($"Nota 1.....................{aluno.Nota1}");
                Console.WriteLine($"Nota 2.....................{aluno.Nota2}");
                Console.WriteLine($"Media.....................{aluno.CalcularMedia()}");
                Console.WriteLine($"Situação.....................{aluno.VerificarSituacao()}");
                Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + \n");

            }
            Console.ReadKey();

        }// fim do metodo listar alunos aprovados
        public void ListarAlunosReprovados()
        {
            Console.Clear();
            Console.WriteLine("* + * + * + * + * + * + * + LISTAR ALUNOS REPROVADOS * + * + * + * + * + * + * + \n");

            var alunosReprovados = AlunosMatriculados.Where(aluno => aluno.CalcularMedia() < 60).ToList();
            foreach (var aluno in alunosReprovados.OrderBy(x => x.Nome).ToList())
            {
                Console.WriteLine("\n\n* + * + * + * + * + * + * + * + * + * + * + * + * + * + ");
                Console.WriteLine($"N° Matricula.....................{aluno.NumeroDeMatricula}");
                Console.WriteLine($"Nome.....................{aluno.Nome}");
                Console.WriteLine($"Nota 1.....................{aluno.Nota1}");
                Console.WriteLine($"Nota 2.....................{aluno.Nota2}");
                Console.WriteLine($"Media.....................{aluno.CalcularMedia()}");
                Console.WriteLine($"Situação.....................{aluno.VerificarSituacao()}");
                Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + \n");

            }

            Console.ReadKey();

        }// fim do metodo listar alunos aprovados
        public void ListarTodosAlunosTurma()
        {
            Console.Clear();
            Console.WriteLine("* + * + * + * + * + * + * + LISTAR ALUNOS DA TURMA * + * + * + * + * + * + * + \n");


            foreach (var aluno in AlunosMatriculados.OrderBy(x => x.Nome).ToList())
            {
                Console.WriteLine("\n\n* + * + * + * + * + * + * + * + * + * + * + * + * + * + ");
                Console.WriteLine($"N° Matricula.....................{aluno.NumeroDeMatricula}");
                Console.WriteLine($"Nome.....................{aluno.Nome}");
                Console.WriteLine($"Nota 1.....................{aluno.Nota1}");
                Console.WriteLine($"Nota 2.....................{aluno.Nota2}");
                Console.WriteLine($"Media.....................{aluno.CalcularMedia()}");
                Console.WriteLine($"Situação.....................{aluno.VerificarSituacao()}");
                Console.WriteLine("* + * + * + * + * + * + * + * + * + * + * + * + * + * + \n");

            }

            Console.ReadKey();

        }// fim do metodo listar alunos reprovados
        public void EstatisticaDaTurma()
        {
            Console.Clear();
            Console.WriteLine("* + * + * + * + * + * + * + ESTATÍSTICA DA TURMA * + * + * + * + * + * + * + \n");
            double alunosAprovados = AlunosMatriculados.Where(aluno => aluno.CalcularMedia() >= 60).Count();
            double alunosReprovados = AlunosMatriculados.Where(aluno => aluno.CalcularMedia() < 60).Count();
            double alunosTodo = AlunosMatriculados.Count();
            var estatisticaA = (alunosAprovados / alunosTodo) * 100;
            var estatisticaR = (alunosReprovados / alunosTodo) * 100;

            Console.WriteLine($"A estatística de alunos APROVADOS é de {estatisticaA}%");
            Console.WriteLine($"A estatística de alunos REPROVADOS é de {estatisticaR}%");
            Console.ReadKey();

        }// fim do metodo estatistico


    }// fim classe SalaDeAula
}
    }
}
