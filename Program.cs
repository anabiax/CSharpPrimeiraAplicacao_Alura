string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"}; 

Dictionary<string, List<int>> gruposRegistrados = new Dictionary<string, List<int>>();
gruposRegistrados.Add("Turma do pagode.", new List<int> { 10, 8, 9 });
gruposRegistrados.Add("Revelação.", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");

    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um grupo.");
    Console.WriteLine("Digite 2 para mostrar todos os grupos musicais.");
    Console.WriteLine("Digite 3 para avaliar um grupo.");
    Console.WriteLine("Digite 4 para exibir a média de um grupo.");
    Console.WriteLine("Digite 0 para sair.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarGrupo();
            break;
        case 2: MostrarGruposRegistrados();
            break;
        case 3: AvaliarUmGrupo();
            break;
        case 4: ExibirMedia();
            break;
        case 0: Console.WriteLine("Adeus.");
            break;
        default: Console.WriteLine("Opção inválida.");
            break;
    }
}

void RegistrarGrupo()
{
    Console.Clear();

    ExibirTituloDaOpcao("Registro dos grupos.");
    Console.Write("Digite o nome do grupo que deseja registrar:");
    string nomeDoGrupo = Console.ReadLine()!;
    gruposRegistrados.Add(nomeDoGrupo, new List<int>());
    Console.WriteLine($"O grupo {nomeDoGrupo} foi registrado com sucesso!");

    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarGruposRegistrados()
{
    Console.Clear();

    ExibirTituloDaOpcao("Exibindo todas os grupos registrados na nossa aplicação.");
    
    /*
    for (int i = 0; i < listaDasBandas.Count; i++)
    {
        //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }
    */

    foreach (string grupo in gruposRegistrados.Keys)
    {
        Console.WriteLine($"Grupo: {grupo}.");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
    Console.ReadKey();

    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmGrupo()
{
    // digite qual grupo deseja avaliar
    // se o grupo exitir no dicionario -> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear();

    ExibirTituloDaOpcao("Avaliar grupo.");
    Console.Write("Digite o nome do grupo que deseja avaliar: ");
    string nomeDoGrupo = Console.ReadLine()!;

    if (gruposRegistrados.ContainsKey(nomeDoGrupo))
    {
        Console.Write($"Nota para o grupo {nomeDoGrupo}");
        int nota = int.Parse(Console.ReadLine()!);
        gruposRegistrados[nomeDoGrupo].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o grupo {nomeDoGrupo}.");

        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nO grupo {nomeDoGrupo} não foi encontrado.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();

        Console.Clear();    
        ExibirOpcoesDoMenu();
    }
    
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir a média do grupo.");

    Console.Write("Digite o nome do grupo que deseja exibir a média: ");
    string nomeDoGrupo = Console.ReadLine()!;

    if (gruposRegistrados.ContainsKey(nomeDoGrupo))
    {
        List<int> notasDoGrupo = gruposRegistrados[nomeDoGrupo];
        Console.WriteLine($"\nA média do grupo {nomeDoGrupo} é {notasDoGrupo.Average()}.");
        Console.WriteLine("Digite uma tecla para votar ao menu principal.");
        Console.ReadKey();

        Console.Clear();    
        ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine($"\nO grupo {nomeDoGrupo} não foi encontrado.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();

        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();