using System;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Program
    {
        private static int m_TurnNum;


        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Hello");
            Move first = new Move(1, 2);
            first.SetMove(2, 3);
            first.SetMove(4, 5);
            first.SetMove(6, 7);
            Console.WriteLine(first.turns);
            Console.WriteLine(first.m_Turn);











        }


        public static int TurnNum {
            get { return m_TurnNum; }
        }




    }
}
