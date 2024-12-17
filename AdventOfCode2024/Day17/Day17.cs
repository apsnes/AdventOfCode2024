using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day17
    {
        internal static long RegisterA = 44348299;
        internal static long RegisterB = 0;
        internal static long RegisterC = 0;
        internal static int[] Program = { 2, 4, 1, 5, 7, 5, 1, 6, 0, 3, 4, 2, 5, 5, 3, 0 };
        internal static int CurrentPointer = 0;
        internal static List<long> ToOutput = new();
        internal static bool Jumped = false;
        internal static string FirstOutput = "";
        internal static Dictionary<int, long> ComboOperands = new Dictionary<int, long>
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 2 },
            { 3, 3 },
            { 4, RegisterA },
            { 5, RegisterB },
            { 6, RegisterC }
        };
        internal static void Solution_One()
        {
            while (CurrentPointer < Program.Length)
            {
                Perform_Instruction(Program[CurrentPointer], Program[CurrentPointer + 1]);
                if (Jumped)
                {
                    Jumped = false;
                    continue;
                }
                CurrentPointer += 2;
            }
            FirstOutput = (String.Join(",", ToOutput));
            Console.WriteLine(FirstOutput);
        }
        internal static void Perform_Instruction(int instruction, int operand)
        {
            switch (instruction)
            {
                case 0: 
                    RegisterA = RegisterA / (int)Math.Floor((Math.Pow(2, ComboOperands[operand])));
                    ComboOperands[4] = RegisterA;
                    break;
                case 1: 
                    RegisterB = RegisterB ^ operand;
                    ComboOperands[5] = RegisterB;
                    break;
                case 2: 
                    RegisterB = ComboOperands[operand] % 8;
                    ComboOperands[5] = RegisterB;
                    break;
                case 3:
                    if (RegisterA == 0) break;
                    CurrentPointer = operand;
                    Jumped = true;
                    break;
                case 4:
                    RegisterB = RegisterB ^ RegisterC;
                    ComboOperands[5] = RegisterB;
                    break;
                case 5:
                    ToOutput.Add(ComboOperands[operand] % 8);
                    break;
                case 6:
                    RegisterB = RegisterA / (int)(Math.Pow(2, ComboOperands[operand]));
                    ComboOperands[5] = RegisterB;
                    break;
                case 7:
                    RegisterC = RegisterA / (int)(Math.Pow(2, ComboOperands[operand]));
                    ComboOperands[6] = RegisterC;
                    break;
            }
        }
        internal static void Solution_Two()
        {
            CurrentPointer = 0;
            ToOutput.Clear();
            string ExpectedSolution = String.Join(",", Program);
            for (long i = 0; i < long.MaxValue; i++)
            {
                RegisterA = i;
                while (CurrentPointer < Program.Length)
                {
                    Perform_Instruction(Program[CurrentPointer], Program[CurrentPointer + 1]);
                    if (Jumped)
                    {
                        Jumped = false;
                        continue;
                    }
                    CurrentPointer += 2;
                }
                string CurrentOutput = (String.Join(",", ToOutput));
                if (CurrentOutput == ExpectedSolution)
                {                  
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
