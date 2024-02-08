namespace lode_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                int[,] pole = new int[10, 10];
                int[,] pole2 = new int[10, 10];
                Console.Clear();
                GenerovaniLode(pole);
                GenerovaniLode2(pole);
                GenerovaniLode3(pole);
                GenerovaniLode4(pole);
                ////VypisPole(pole);
                Console.WriteLine();
                VypisPole2(pole2);
                Strileni(pole, pole2);
                Console.ReadKey(true);
                Console.Clear();
                Console.Write("Chcete hrat znovu? y/n: ");
                input = Console.ReadLine();
            } while (input == "y" || input == "Y");

        }

        static void GenerovaniLode(int[,] pole) // vygeneruje první 1x4 loď
        {
            int i = 0;
            Random generator = new Random();
            int randomRadekLod1x4 = generator.Next(0, 10);
            int randomSloupecLod1x4 = generator.Next(0, 7);
            for (int s = randomSloupecLod1x4; i < 4; s++)
            {
                i++;
                pole[randomRadekLod1x4, s] = 1;
            }
        }
        static void GenerovaniLode2(int[,] pole) //vygeneruje druhou 1x3 loď a jestli se překrývá, tak ji vygeneruje znova
        {
            bool misto;
            Random generator = new Random();
            while (true)
            {
                misto = true;
                int randomRadekLod1x3 = generator.Next(0, 10);
                int randomSloupecLod1x3 = generator.Next(0, 8);

                for (int r = 0; r < 1; r++)
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (pole[randomRadekLod1x3 + r, randomSloupecLod1x3 + s] != 0)
                            misto = false;
                    }
                }

                if (misto)
                {
                    for (int r = 0; r < 1; r++)
                    {
                        for (int s = 0; s < 3; s++)
                        {
                            pole[randomRadekLod1x3 + r, randomSloupecLod1x3 + s] = 2;
                        }
                    }
                    break;
                }
            }
        }

        static void GenerovaniLode3(int[,] pole)//vygeneruje 1x3 loď s komínem -||-
        {
            Random generator = new Random();
            bool misto;
            while (true)
            {
                misto = true;
                int randomRadekLod1x3k = generator.Next(0, 9);
                int randomSloupecLod1x3k = generator.Next(0, 8);
                for (int r = 0; r < 2; r++)
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (pole[randomRadekLod1x3k + r, randomSloupecLod1x3k + s] != 0)
                            misto = false;
                    }
                }

                if (misto)
                {
                    for (int r = 0; r < 2; r++)
                    {
                        for (int s = 0; s < 3; s++)
                        {
                            pole[randomRadekLod1x3k + r, randomSloupecLod1x3k + s] = 3;
                            pole[randomRadekLod1x3k, randomSloupecLod1x3k] = 0;
                            pole[randomRadekLod1x3k, randomSloupecLod1x3k + 2] = 0;
                        }
                    }
                    break;
                }
            }
        }

        static void GenerovaniLode4(int[,] pole)
        {
            Random generator = new Random();
            bool misto;
            while (true) {
                misto = true;
                int randomRadek4x1 = generator.Next(0, 7);
                int randomSloupec4x1 = generator.Next(0, 10);

                for (int r = 0; r < 4; r++)
                {
                    for (int s = 0; s < 1; s++)
                    {
                        if (pole[randomRadek4x1 + r, randomSloupec4x1 + s] != 0)
                            misto = false;
                    }
                }

                if (misto)
                {
                    for (int r = 0; r < 4; r++)
                    {
                        for (int s = 0; s < 1; s++)
                        {
                            pole[randomRadek4x1 + r, randomSloupec4x1 + s] = 4;
                        }
                    }
                    break;
                }
            }
        }

        static void VypisPole(int[,] pole) // pole, kde jdou vidět vypsané lodě (nápověda)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("LODĚ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    A B C D E F G H I J");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int r = 0; r < pole.GetLength(0); r++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (r == 9)
                {
                    Console.Write($"{r + 1}. ");
                }
                else
                {
                    Console.Write($"{r + 1}.  ");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    if (pole[r, s] == 1 || pole[r, s] == 2 || pole[r, s] == 3 || pole[r,s] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(pole[r, s] + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }
        static void VypisPole2(int[,] pole2) //vypíše pole, do kterého hráč střílí
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("LODĚ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    A B C D E F G H I J");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int r = 0; r < pole2.GetLength(0); r++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (r == 9)
                {
                    Console.Write($"{r + 1}. ");
                }
                else
                {
                    Console.Write($"{r + 1}.  ");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int s = 0; s < pole2.GetLength(1); s++)
                {
                    if (pole2[r, s] == 1 || pole2[r, s] == 2 || pole2[r, s] == 3 || pole2[r,s] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    string print = pole2[r, s].ToString();
                    if (print == "-1")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        print = "X";
                    }
                    Console.Write(print + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }


        static void Strileni(int[,] pole, int[,] pole2) // vybírání souřadnic střely
        {

            int radek = 0;
            int sloupec = 0;
            int pokusy = 0;

            while (true)
            {

                Console.Write("Vyberte radek: ");
                radek = OvereniVstupuRadek(pole2, radek, "radek");
                Console.Write("Vyberte sloupec: ");
                sloupec = OvereniVstupuSloupec(pole2, sloupec);

                if (pole[radek - 1, sloupec - 1] == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MISTO BYLO JIZ ZASAZENO!");
                }

                if (pole[radek - 1, sloupec - 1] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ZASAH!");
                    pole[radek - 1, sloupec - 1] = 5;
                    pole2[radek - 1, sloupec - 1] = 1;
                }
                else if (pole[radek - 1, sloupec - 1] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ZASAH!");
                    pole[radek - 1, sloupec - 1] = 5;
                    pole2[radek - 1, sloupec - 1] = 2;
                }
                else if (pole[radek - 1, sloupec - 1] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ZASAH!");
                    pole[radek - 1, sloupec - 1] = 5;
                    pole2[radek - 1, sloupec - 1] = 3;
                }
                else if (pole[radek-1, sloupec-1] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ZASAH!");
                    pole[radek - 1, sloupec - 1] = 5;
                    pole2[radek - 1, sloupec - 1] = 4;
                }
                if (pole[radek - 1, sloupec - 1] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("VEDLE!");
                    pole2[radek - 1, sloupec - 1] = -1;
                }
                pokusy++;

                Console.ForegroundColor = ConsoleColor.Gray;

                // kontroluje, jestli se v poli vyskytují lodě, jestli ne, skončí
                bool pokracovani = Konec(pokusy, pole);

                if (pokracovani == false)
                {
                    Console.Clear();
                    VypisPole2(pole2);
                    Console.WriteLine("HRA UKONČENA!");
                    Console.WriteLine($"Pokusy: {pokusy}");
                    break;
                }
                else
                {
                    Console.ReadKey(true);
                    Console.Clear();
                    //VypisPole(pole);
                    //Console.WriteLine();
                    VypisPole2(pole2);
                }
            }
        }

        static int OvereniVstupuRadek(int[,] pole2, int co, string vstup) //ověřuje jestli je input řádku v rozsahu
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out co))
                {
                    if (co >= 1 && co <= 10)
                        break;
                }
                Console.Clear();
                Console.WriteLine("Error!");
                Console.ReadKey(true);
                Console.Clear();
                VypisPole2(pole2);
                Console.Write($"Vyberte {vstup}: ");
            }
            return co;
        }

        static int OvereniVstupuSloupec(int[,] pole2, int co)//ověřuje jestli je input sloupce v rozsahu a převádí písmena na čísla sloupců
        {
            string input = Console.ReadLine();
            while (input.ToUpper() != "A" && input.ToUpper() != "B" && input.ToUpper() != "C" && input.ToUpper() != "D" && input.ToUpper() != "E" && input.ToUpper() != "F" && input.ToUpper() != "G" && input.ToUpper() != "H" && input.ToUpper() != "I" && input.ToUpper() != "J")
            {
                Console.Clear();
                Console.WriteLine("Error!");
                Console.ReadKey(true);
                Console.Clear();
                VypisPole2(pole2);
                Console.Write("Vyberte sloupec: ");
                input = Console.ReadLine();
                if (input.ToUpper() == "A" && input.ToUpper() == "B" && input.ToUpper() == "C" && input.ToUpper() == "D" && input.ToUpper() == "E" && input.ToUpper() == "F" && input.ToUpper() == "G" && input.ToUpper() == "H" && input.ToUpper() == "I" && input.ToUpper() == "J")
                    break;
            }
            switch (input.ToUpper())
            {
                case "A":
                    co = 1;
                    break;
                case "B":
                    co = 2;
                    break;
                case "C":
                    co = 3;
                    break;
                case "D":
                    co = 4;
                    break;
                case "E":
                    co = 5;
                    break;
                case "F":
                    co = 6;
                    break;
                case "G":
                    co = 7;
                    break;
                case "H":
                    co = 8;
                    break;
                case "I":
                    co = 9;
                    break;
                case "J":
                    co = 10;
                    break;
            }

            return co;
        }

        static bool Konec(int pokusy, int[,] pole) //pokud najde loď v poli pokracovani = true, jestli pokracovani = false a ukonci hru
        {
            bool konec = true;
            bool pokracovani = true;
            for (int r = 0; r < pole.GetLength(0); r++)
            {
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    if (pole[r, s] == 1 || pole[r, s] == 2 || pole[r, s] == 3 || pole[r,s] == 4)
                    {
                        pokracovani = true;
                        konec = false;
                    }

                    else if (konec)
                    {
                        pokracovani = false;
                    }
                }
            }
            return pokracovani;
        }
    }
}