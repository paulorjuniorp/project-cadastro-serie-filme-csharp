using System;

namespace cadastro_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        string opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
                        while(opcaoUsuarioSerie.ToUpper() != "X"){
                            switch(opcaoUsuarioSerie){
                            case "1":
                                ListarSeries();
                                break;
                            case "2":
                                InserirSerie();
                                break;
                            case "3":
                                AtualizarSerie();
                                break;
                            case "4":
                                ExcluirSerie();
                                break;
                            case "5":
                                VisualizarSerie();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                            }
                            opcaoUsuarioSerie = ObterOpcaoUsuarioSerie();
                        }
                    break;
                    case "2":
                        string opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
                        while(opcaoUsuarioFilme.ToUpper() != "X"){
                            switch(opcaoUsuarioFilme){
                            case "1":
                                ListarFilmes();
                                break;
                            case "2":
                                InserirFilme();
                                break;
                            case "3":
                                AtualizarFilme();
                                break;
                            case "4":
                                ExcluirFilme();
                                break;
                            case "5":
                                VisualizarFilme();
                                break;
                            case "C":
                                Console.Clear();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                            }
                            opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries(){
            Console.WriteLine("Listar séries :D");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*": ""));
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite um genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie(){
            Console.WriteLine("Digite o di da série");
            int indicaSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indicaSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indicaSerie, atualizaSerie);

        }

        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da série");
            int indicaSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indicaSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da série");
            int indicaSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornarPorId(indicaSerie);
            Console.WriteLine(serie);
        }

        private static void ListarFilmes(){
            Console.WriteLine("Listar filmes bb");

            var lista = filmeRepositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }

            foreach(var filme in lista){
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*": ""));
            }
        }

        private static void InserirFilme(){
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite um genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a sinopse do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Insere(novoFilme);
        }

        private static void AtualizarFilme(){
            Console.WriteLine("Digite o di da série");
            int indicaFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indicaFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Atualiza(indicaFilme, atualizaFilme);

        }

        private static void ExcluirFilme(){
            Console.WriteLine("Digite o id da série");
            int indicaFilme = int.Parse(Console.ReadLine());

            filmeRepositorio.Exclui(indicaFilme);
        }

        private static void VisualizarFilme(){
            Console.WriteLine("Digite o id da série");
            int indicaFilme = int.Parse(Console.ReadLine());
            var filme = filmeRepositorio.RetornarPorId(indicaFilme);
            Console.WriteLine(filme);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Roi, usuário né?!");
            Console.WriteLine("Informe o que você deseja cadastrar");
            Console.WriteLine("1 - Cadastrar série");
            Console.WriteLine("2 - Cadastrar filme");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterOpcaoUsuarioSerie(){
            Console.WriteLine();
            Console.WriteLine("Roi, usuário né?!");
            Console.WriteLine("Informe a sua opção desejada *-*");
            Console.WriteLine("1 - Lista séries");
            Console.WriteLine("2 - Inserir uma nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Exluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuarioSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuarioSerie;
        }

        private static string ObterOpcaoUsuarioFilme(){
            Console.WriteLine();
            Console.WriteLine("Roi, usuário né?!");
            Console.WriteLine("Informe a sua opção desejada *-*");
            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir uma novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Exluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuarioFilme = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuarioFilme;
        }
    }
}
