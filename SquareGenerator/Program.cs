using System;

namespace SquareGenerator {
    class Program {
        static void Main() {
            string input;
            int minSquare = 2;
            while (true) {
                input = AskForInput(ref minSquare);

                if (int.TryParse(input, out int squareSize)) {

                    if (squareSize == 0) return;

                    if (squareSize > minSquare) {
                        int maxlayers = (squareSize - 3) / 4;
                        bool even = squareSize % 2 == 0;

                        DrawSquare(squareSize, 0, ref maxlayers, ref even);

                        continue;
                    }
                }

                ErrorMessage(minSquare);
            }
        }

        public static string AskForInput(ref int minSquare) {
            Console.Write($"Please enter the size of the square (whole number) larger than {minSquare} or 0 to exit: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            return input;
        }

        public static void DrawSquare(int size, int layers, ref int maxLayers, ref bool even) {
            SquareTopBottom(size, layers);

            SquareSide(size, layers);

            int newSize = size - 4;
            if (newSize > 2) {
                DrawSquare(newSize, layers + 1, ref maxLayers, ref even);
            } else if (size > 4) {
                SquareSide(size, layers);
                SquareSide(size, layers);
            };

            if (layers != maxLayers || even) {
                SquareSide(size, layers);
            }

            SquareTopBottom(size, layers);
        }

        public static void SquareTopBottom(int size, int layers) {
            WriteLayers(layers, true);

            for (int i = 0; i < size; i++) {
                WriteStar();
            }

            WriteLayers(layers, false);

            Console.WriteLine();
        }

        public static void SquareSide(int size, int layers) {
            WriteLayers(layers, true);
            WriteStar();

            while (size > 2) {
                WriteSpace();
                size--;
            }

            WriteStar();
            WriteLayers(layers, false);

            Console.WriteLine();
        }

        public static void WriteLayers(int layers, bool left) {
            if (left) {
                for (int i = 0; i < layers; i++) {
                    WriteStar();
                    WriteSpace();
                };

            } else {
                for (int i = 0; i < layers; i++) {
                    WriteSpace();
                    WriteStar();
                }
            }
        }

        public static void WriteStar() {
            Console.Write(" *");
        }

        public static void WriteSpace() {
            Console.Write("  ");
        }
        public static void ErrorMessage(int minSquare) {
            Console.WriteLine($"Error: The input needs to be a whole number larger than {minSquare} - Please try again\n");
        }
    }
}
