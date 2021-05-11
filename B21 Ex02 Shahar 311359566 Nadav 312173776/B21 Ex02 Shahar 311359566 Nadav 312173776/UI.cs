using System;
using System.Collections.Generic;
using System.Text;


namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class UI
    {

        public static void BoardPrinter(Board i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
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
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.BoardMatrix[i, j] == Move.enumXO.EMPTY)
                    {
                        row.Append("   |");
                    }
                    else
                    {
                        row.Append($" {i_Board.BoardMatrix[i, j]} |");
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
            Console.WriteLine("Please enter your row number and column number seprated by a space");
            string moveString = Console.ReadLine();
            string[] inputs = moveString.Split(' ');
            int[] parsedInts = new int[2];
            while (!IsValidInputs(inputs, out parsedInts))
            {
                Console.WriteLine("Invalid input, please enter your row number and column number seprated by a space");
                moveString = Console.ReadLine();
                inputs = moveString.Split(' ');
                parsedInts = new int[2];
            }
            Move PlayerMove = new Move(parsedInts[0]-1, parsedInts[1]-1);
            return PlayerMove;
        }

        private static bool IsValidInputs(string[] i_Inputs, out int[] o_parsedInts)
        {
            bool valid = true;
            if(i_Inputs.Length == 1)
            {
                if (i_Inputs[0] == "Q")
                {
                    Console.WriteLine("Are you sure you want to quit? (Y/N)");
                    string answer = Console.ReadLine();
                    if (answer == "Y")
                    {
                        Environment.Exit(0);
                    }
                    else if (answer == "N")
                    {
                        GetPlayerMove();
                    }
                }
            }
            if(i_Inputs.Length != 2)
            {
                valid = false;
            }
            int[] parsedInts = new int[2];
            for(int i =0; i<i_Inputs.Length; i++)
            {
                if (!int.TryParse(i_Inputs[i].ToString(), out parsedInts[i]))
                {
                    valid = false;
                }
            }
            o_parsedInts = parsedInts;
            return valid;
        }
    }



}

