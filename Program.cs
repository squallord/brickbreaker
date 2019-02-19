using System;
using System.Text;
using System.Threading;

namespace brickbreaker {
    class Program {
        static void Main (string[] args) {
            const int altura_fase = 20;
            const int largura_fase = 80;

            // define a fase
            int[][] fase = new int[altura_fase][];
            for (int i = 0; i < fase.Length; i++)
                fase[i] = new int[largura_fase];

            // define a raquete
            // tamanho de 6 caracteres
            char[] raquete = { '<', '=', '=', '=', '=', '>' };
            int raqueteX = largura_fase / 2 - raquete.Length / 2;
            int raqueteY = altura_fase - 3;

            // define o tijolo ("inimigo")
            char[] tijolo = { '[', '=', '=', '=', '=', ']' };
            int tijoloX = largura_fase / 2 - tijolo.Length / 2;
            int tijoloY = 3;

            // define a bola
            char bola = 'o';
            int bolaX = largura_fase / 2;
            int bolaY = altura_fase - 5;

            // incrementos de posicao da bola
            // ela inicia indo pra noroeste
            int incX = 1; // para direita
            int incY = -1; // para cima

            Console.CursorVisible = false;

            // armazena o botão que o jogador pressiona
            ConsoleKey key = ConsoleKey.NoName;

            // booleana que faz o jogo inicar ao pressionar espaço
            bool iniciouJogo = false;

            do {
                Thread.Sleep (2);
                Console.Clear ();

                if (Console.KeyAvailable) {
                    key = Console.ReadKey (true).Key;

                    if (key == ConsoleKey.Spacebar) {
                        key = ConsoleKey.NoName;
                        iniciouJogo = true;
                    }
                }

                // imprime a fase
                for (int i = 0; i < fase.Length; i++) {
                    for (int j = 0; j < fase[i].Length; j++) {
                        if (j % fase[i].Length == 0 || j % fase[i].Length == fase[i].Length - 1 || i == 0 || i == fase.Length - 1)
                            Console.Write ("0");
                        else
                            Console.Write (" ");
                    }
                    Console.WriteLine ();
                }

                // imprime a bolinha
                Console.SetCursorPosition (bolaX, bolaY);
                Console.Write ("o");

                // imprime a raquete
                Console.SetCursorPosition (raqueteX, raqueteY);
                for (int i = 0; i < raquete.Length; i++) {
                    Console.Write (raquete[i]);
                    //Console.SetCursorPosition (Console.CursorTop, Console.CursorLeft + 1);
                }

                // aqui vai a lógica do jogo
                if (iniciouJogo) {
                    // movimento da bolinha
                    if (bolaX + 1 >= largura_fase - 1)
                        incX = -1;
                    if (bolaX - 1 <= 0)
                        incX = 1;
                    if (bolaY + 1 >= altura_fase - 1)
                        incY = -1;
                    if (bolaY - 1 <= 0)
                        incY = 1;

                    bolaX += incX;
                    bolaY += incY;
                    // fim do movimento da bolinha

                    // movimento da raquete
                    if (raqueteX - 1 > 0 && (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)) {
                        key = ConsoleKey.NoName;
                        raqueteX--;
                    }
                    if (raqueteX + raquete.Length < largura_fase - 1 && (key == ConsoleKey.D || key == ConsoleKey.RightArrow)) {
                        key = ConsoleKey.NoName;
                        raqueteX++;
                    }
                    // fim do movimento da raquete
                }
            }
            while (key != ConsoleKey.Q);

            Console.ReadKey (true);
        }
    }
}