using System;
using System.Text;
namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Program
    {
        private static int m_TurnNum;


        static void Main(string[] args)
        {
            string[,] arr = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = "   ";
                }
            }
            StringBuilder row = new StringBuilder();
            for (int i =0 ; i < 3; i++)
            {
                row.Append("   " + i);
            }
            Console.WriteLine(row);

            for (int i = 0; i < 3; i++)
            {
                row.Clear();
                row.Append(i + "|");
                for (int j = 0; j < 3; j++)
                {
                    row.Append(arr[i, j] + "|");
                }
                Console.WriteLine(row);
                row.Clear();
                row.Append(" =").Append('=', 4 * 3);
                Console.WriteLine(row);
            }















            }


        public static int TurnNum {
            get { return m_TurnNum; }
            set { m_TurnNum++; }
        }




    }
}
