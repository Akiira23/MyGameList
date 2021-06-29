using System;

namespace MyGameList
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarJogos();
						break;
					case "2":
						InserirJogo();
						break;
					case "3":
						AtualizarJogo();
						break;
					case "4":
						ExcluirJogo();
						break;
					case "5":
						VisualizarJogo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("MyGamesList a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar todos os jogos");
			Console.WriteLine("2- Inserir um novo jogo");
			Console.WriteLine("3- Atualizar um jogo");
			Console.WriteLine("4- Excluir um jogo");
			Console.WriteLine("5- Visualizar um jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
        private static void ListarJogos()
		{
			Console.WriteLine("Listando os jogos cadastrados");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo cadastrado.");
				return;
			}

			foreach (var jogo in lista)
			{
                var excluido = jogo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
        private static void InserirJogo()
		{
			Console.WriteLine("Inserir um novo jogo");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lancamento do Jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Plataforma)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
			}
			Console.Write("Digite a Plataforma do Jogo: ");
			int entradaPlataforma = int.Parse(Console.ReadLine());

			Console.Write("Digite a Nota do Jogo: ");
			int entradaNota = int.Parse(Console.ReadLine());

            Console.Write("Digite se o Jogo foi Finalizado (true or false): ");
			bool entradaFinalizado = bool.Parse(Console.ReadLine());

			Games novaSerie = new Games(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano_lancamento: entradaAno,
										plataforma: (Plataforma)entradaPlataforma,
                                        nota: entradaNota,
                                        finalizado: entradaFinalizado);

			repositorio.Insere(novaSerie);
		}
        private static void AtualizarJogo()
		{
			Console.Write("Digite o id do Jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lancamento do Jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Plataforma)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
			}
			Console.Write("Digite a Plataforma do Jogo: ");
			int entradaPlataforma = int.Parse(Console.ReadLine());

			Console.Write("Digite a Nota do Jogo: ");
			int entradaNota = int.Parse(Console.ReadLine());

            Console.Write("Digite se o Jogo foi Finalizado (true or false): ");
			bool entradaFinalizado = bool.Parse(Console.ReadLine());

			Games atualizaJogos = new Games(id: indiceJogo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano_lancamento: entradaAno,
										plataforma: (Plataforma)entradaPlataforma,
                                        nota: entradaNota,
                                        finalizado: entradaFinalizado);

			repositorio.Atualiza(indiceJogo, atualizaJogos);
		}
        private static void VisualizarJogo()
		{
			Console.Write("Digite o id do Jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			var jogo = repositorio.RetornaPorId(indiceJogo);

			Console.WriteLine(jogo);
		}
        private static void ExcluirJogo()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJogo);
		}
    }
}
