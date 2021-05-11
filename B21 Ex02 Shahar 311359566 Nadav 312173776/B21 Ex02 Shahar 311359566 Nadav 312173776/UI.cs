using System;
using System.Collections.Generic;
using System.Text;


namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class UI
    {

        public static void BoardPrinter(Board i_Board)
        {
            //Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder row = new StringBuilder();

            for (int i = 1; i <= i_Board.BoardSize; i++)
            {
                row.Append("   " + i);
            }
            Console.WriteLine(row);

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                row.Clear();
                row.Append((i + 1) + "|");
                for (int j = 01; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.BoardMatrix[i, j] == Move.enumXO.EMPTY)
                    {
                        row.Append("   |");
                    }
                    else
                    {
                        row.Append(" " + i_Board.BoardMatrix[i, j] + " |");
                    }

                }
                Console.WriteLine(row);
                row.Clear();
                row.Append(" =").Append('=', 4 * i_Board.BoardSize);
                Console.WriteLine(row);
            }
        }




        public static Move GetPlayerMove()
        {
            Console.WriteLine("Please enter your move");
            Console.WriteLine("Please enter your row position");
            string row = Console.ReadLine();
            Console.WriteLine("Please enter your column position");
            string column = Console.ReadLine();
            while (!(IsValidInput(row)) && !(IsValidInput(column)))
            {
                Console.WriteLine("Please enter your other row position");
                row = Console.ReadLine();
                Console.WriteLine("Please enter your other column position");
                column = Console.ReadLine();
            }
            Move PlayerMove = new Move(int.Parse(row), int.Parse(column));
            return PlayerMove;
        }

        private static bool IsValidInput(string i_Input)
        {
            if (i_Input == "Q")
            {
                Console.WriteLine("Are you sure you want to quit? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Environment.Exit(0);
                }
                else
                {
                    GetPlayerMove();
                }
            }

            int position;
            bool valid = int.TryParse(i_Input, out position);
            return valid;
        }
    }



}

