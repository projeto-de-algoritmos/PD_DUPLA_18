using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static void ProcessAnswer(int q, int[,,,] dp)
        {
            while (q-- > 0)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int a = input[0] - 1;
                int b = input[1] - 1;
                int c = input[2] - 1;
                int d = input[3] - 1;
        
                Console.WriteLine(dp[a, b, c, d]);
            }
        }
        
        private static void ProcessMatrix(int[,] aux, int[,] dis, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                int d = 0;
    
                for (int j = 0; j < m; j++)
                {
                    d++;
                    aux[i, j] = row[j] - '0';
    
                    if (aux[i, j] == 1)
                        d = 0;
                    
                    dis[i, j] = d;
                }
            }
        }
        
        private static void ProcessDP(int[,,,] dp, int[,] dis, int n, int m)
        {
            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < m; b++)
                {
                    for (int c = a; c < n; c++)
                    {
                        for (int d = b; d < m; d++)
                        {
                            if (c - 1 >= 0)
                                dp[a, b, c, d] += dp[a, b, c - 1, d];
                            
                            if (d - 1 >= 0)
                                dp[a, b, c, d] += dp[a, b, c, d - 1];
                            
                            if (c - 1 >= 0 && d - 1 >= 0)
                                dp[a, b, c, d] -= dp[a, b, c - 1, d - 1];
                            
                            int r = d - b + 1;

                            for (int i = c; i >= a; i--)
                            {
                                r = Math.Min(r, dis[i, d]);
                                dp[a, b, c, d] += r;
                            }
                        }
                    }
                }
            }   
        }
        
        static void Main(string[] args)
        {
            int n, m, q;
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = input[0];
            m = input[1];
            q = input[2];

            int[,] aux = new int[n, m];
            int[,] dis = new int[n, m];
            int[,,,] dp = new int[n, m, n, m];

            ProcessMatrix(aux, dis, n, m);
            ProcessDP(dp, dis, n, m);
            ProcessAnswer(q, dp);
        }
    }
}
