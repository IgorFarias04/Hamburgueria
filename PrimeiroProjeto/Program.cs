//Chef's Burger
string mensagemDeBoasVindas = "Boas vindas a lanchonete Chef's Burger";

Dictionary<string, List<int>> lanchesRegistrados = new Dictionary<string, List<int>>();
lanchesRegistrados.Add("X-Burger", new List<int> { 10, 8, 6});
lanchesRegistrados.Add("X-Bacon", new List<int> ());

void ExibirLogo()
{
    Console.WriteLine(@"
█▀▀ █░█ █▀▀ █▀▀ ▀ █▀   █▄▄ █░█ █▀█ █▀▀ █▀▀ █▀█
█▄▄ █▀█ ██▄ █▀░ ░ ▄█   █▄█ █▄█ █▀▄ █▄█ ██▄ █▀▄");

    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
     Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um Lanche;");
    Console.WriteLine("Digite 2 para mostrar todos os Lanches;");
    Console.WriteLine("Digite 3 para avaliar um Lanche;");
    Console.WriteLine("Digite 4 para exibir a média de um Lanche;");
    Console.WriteLine("Digite 0 para sair.");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarLanches();
            break;

        case 2: MostrarLanchesRegistrados();
            break;

        case 3:
            AvaliarUmLanche();
            break;

        case 4:
            MediaDoLanche();
            break;

        case 0:
            Console.WriteLine("Tchau Tchau :)");
            break;

        default: Console.WriteLine("\nOpção inválida");
            Thread.Sleep(4000);
            ExibirOpcoesDoMenu();
            break;
    }


}

void RegistrarLanches()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Lanches");
    Console.Write("\nDigite o nome do Lanche que deja registrar: ");
    string nomeDoLanche = Console.ReadLine()!;
    lanchesRegistrados.Add(nomeDoLanche, new List<int>());
    Console.WriteLine($"O lanche {nomeDoLanche} foi registrado com sucesso!");
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}

void MostrarLanchesRegistrados()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todos os lanches registrados");
    Console.WriteLine("Lanches Registrados:\n");
    
    foreach (string lanche in lanchesRegistrados.Keys)
    {
        Console.WriteLine($"Lanche: {lanche}");
    }
    Console.WriteLine("\nDigite uma Tecla para retornar ao menu.");
    Console.ReadKey();
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

void AvaliarUmLanche()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Lanche");
    Console.Write("Digite o nome do lanche que deseja avaliar: ");
    string nomeDoLanche = Console.ReadLine();

    if (lanchesRegistrados.ContainsKey(nomeDoLanche)) 
    {
        Console.Write($"Qual a nota que o Lanche {nomeDoLanche} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        lanchesRegistrados[nomeDoLanche].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para {nomeDoLanche}.");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    else
    {
        Console.WriteLine($"\nO lanche {nomeDoLanche} não foi encontrado.");
        Console.WriteLine("Digite uma tecla qualquer para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu(); 
    }
}

void MediaDoLanche()
{
    Console.Clear();
    ExibirTituloDaOpcao("Media dos Lanches");
    Console.Write("Digite o lanche que deseja consultar a média: ");
    string nomeDoLanche = Console.ReadLine()!;
    
    if (lanchesRegistrados.ContainsKey(nomeDoLanche)) 
    {
        List<int> notasDoLanche = lanchesRegistrados[nomeDoLanche];
        Console.WriteLine($"\nA média do lanche {nomeDoLanche} é {notasDoLanche.Average()}.");
        Console.WriteLine("Digite uma tecla para retornar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }

    else
    {
        Console.WriteLine($"\nO Lanche {nomeDoLanche} não foi encontrada.");
        Console.WriteLine("Digite uma tecla qualquer para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


ExibirLogo();
ExibirOpcoesDoMenu();

