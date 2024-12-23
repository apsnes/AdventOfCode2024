using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal static class Day23
    {
        private static List<(string pc1, string pc2)> connections = new();
        internal static void ReadFile()
        {
            var lines = File.ReadAllLines("Day23/Day23.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split("-");
                connections.Add((parts[0], parts[1]));
            }
        }
        internal static void CountConnections()
        {
            foreach (var conn in connections)
            {
                string pc1 = conn.pc1;
                string pc2 = conn.pc2;
                foreach (var conn2 in connections)
                {
                    if (conn2.pc1 == pc2  && conn2.pc2 == pc1)
                    {
                        connections.Remove(conn2);
                    }
                }
            }
            HashSet<(string, string, string)> sets = new();
            foreach (var conn in connections)
            {
                string pc1 = conn.pc1;
                string pc2 = conn.pc2;
                foreach (var conn2 in connections)
                {
                    if (conn2 == conn) continue;
                }
            }
        }
    }
}
