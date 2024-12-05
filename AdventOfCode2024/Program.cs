namespace AdventOfCode2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Day_One.Solution());
            //Console.WriteLine(Day_One.Solution_Part_Two());
            //Console.WriteLine(DayTwo.Solution_One());
            //Console.WriteLine(DayTwo.Solution_Two());
            //DayThree.ReadFile();
            //Console.WriteLine(DayThree.Solution_Two());
            //DayFour.ReadFile();
            //Console.WriteLine(DayFour.Solution_Two());
            DayFive.ReadFile();
            try
            {
                Console.WriteLine(DayFive.Solution_Two());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
