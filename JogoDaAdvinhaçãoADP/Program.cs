namespace JogoDaAdvinhaçãoADP
{
    internal class Program
    {
        static int score = 1000;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("* Bem-vindo(a) ao Jogo da Advinhação! *");
                Console.WriteLine("***************************************");

                int numeroRandom = new Random().Next(1, 21);
                int tentativas = 0;

                Console.WriteLine("Digite um numero respectivo para selecionar sua dificuldade:");
                Console.WriteLine("[1] Fácil (15 tentativas)");
                Console.WriteLine("[2] Médio (10 tentativas)");
                Console.WriteLine("[3] Difícil (5 tentativas)");

                int dificuldade = Convert.ToInt32(Console.ReadLine());

                switch (dificuldade)
                {
                    case 1:
                        tentativas = 15;
                        break;

                    case 2:
                        tentativas = 10;
                        break;

                    case 3:
                        tentativas = 5;
                        break;
                }

                while (tentativas > 0)
                {
                    Console.WriteLine("Faça seu chute!:");
                    int resposta = Convert.ToInt32(Console.ReadLine());

                    if (tentativas == 0)
                    {
                        Console.WriteLine("Suas Chances acabaram, Voce perdeu!");
                    }
                    else if (resposta == numeroRandom)
                    {
                        Console.WriteLine($"Parabéns, voce acertou!\nO numero secreto era {numeroRandom}");
                        tentativas = 0;
                    }
                    else if (resposta < numeroRandom)
                    {
                        score = score - Math.Abs(resposta - numeroRandom) / 2;
                        tentativas--;

                        if (tentativas != 0)
                        {
                            Console.WriteLine("O numero digitado é menor que o numero aleatório");
                            Console.WriteLine($"Voce fez {score} pontos!");
                        }
                    }
                    else if (resposta > numeroRandom)
                    {
                        score = score - Math.Abs(resposta - numeroRandom) / 2;
                        tentativas--;

                        if (tentativas != 0)
                        {
                            Console.WriteLine("O numero digitado é maior que o numero aleatório");
                            Console.WriteLine($"Voce fez {score} pontos!");
                        }
                    }
                }

                Console.WriteLine($"Seu resultado final foi de {score} Pontos!");
                Console.WriteLine("Gostaria de tentar novamente? [S/N]");
                char escolha = Console.ReadKey().KeyChar;
                Console.ReadKey();
                Console.Clear();

                if (escolha == 's' || escolha == 'S')
                    continue;
                else if (escolha == 'n' || escolha == 'N')
                    break;
            }

            Console.WriteLine();
        }
    }
}
