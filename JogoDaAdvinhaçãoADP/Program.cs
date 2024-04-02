namespace JogoDaAdvinhaçãoADP
{
    internal class Program
    {
        static int score = 1000;

        static void Main(string[] args)
        {
            while (true)
            {
                MenuBemVindo();
                int tentativas = InputDificuldade();
                tentativas = OperacaoAcertos(tentativas);
                resultadoFinal();

                if (!TentarNovamente())
                    break;
            }

            Console.WriteLine();
        }

        private static void MenuBemVindo()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Bem-vindo(a) ao Jogo da Advinhação! *");
            Console.WriteLine("***************************************");
            Console.WriteLine("Digite um numero respectivo para selecionar sua dificuldade:");
            Console.WriteLine("[1] Fácil (15 tentativas)");
            Console.WriteLine("[2] Médio (10 tentativas)");
            Console.WriteLine("[3] Difícil (5 tentativas)");
        }

        private static int InputDificuldade()
        {
            int tentativas = 0;
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

            return tentativas;
        }

        private static int OperacaoAcertos(int tentativas)
        {
            int numeroAleatorio = new Random().Next(1, 21);
            while (tentativas > 0)
            {
                Console.WriteLine("Faça seu chute!:");
                int resposta = Convert.ToInt32(Console.ReadLine());

                if (resposta == numeroAleatorio)
                {
                    Console.WriteLine($"Parabéns, voce acertou!\nO numero secreto era {numeroAleatorio}");
                    tentativas = 0;
                }

                else if (resposta < numeroAleatorio)
                {
                    score = score - Math.Abs(resposta - numeroAleatorio) / 2;
                    tentativas--;

                    if (tentativas != 0)
                    {
                        Console.WriteLine("O numero digitado é menor que o numero aleatório");
                        Console.WriteLine($"Sua pontuação atual é de: {score} pontos!");
                    }

                    else if (tentativas == 0 && resposta != numeroAleatorio)
                    {
                        Console.WriteLine("Suas Chances acabaram, Voce perdeu!");
                    }
                }

                else if (resposta > numeroAleatorio)
                {
                    score = score - Math.Abs(resposta - numeroAleatorio) / 2;
                    tentativas--;

                    if (tentativas != 0)
                    {
                        Console.WriteLine("O numero digitado é maior que o numero aleatório");
                        Console.WriteLine($"Sua pontuação atual é de: {score} pontos!");
                    }
                }
            }

            return tentativas;
        }

        private static void resultadoFinal()
        {
            Console.WriteLine($"Seu resultado final foi de {score} Pontos!");
        }

        private static bool TentarNovamente()
        {
            Console.WriteLine("Gostaria de tentar novamente? [S/N]");
            char escolha = Console.ReadKey().KeyChar;
            Console.Clear();

            if (escolha == 's' || escolha == 'S')
                return true;
            else if (escolha == 'n' || escolha == 'N')
                return false;
            else
            {
                Console.WriteLine("Opção inválida.");
                return false;
            }
        }
    }
}