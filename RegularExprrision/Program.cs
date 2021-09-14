using System;

namespace RegularExprrision
{
    class Program
    {
        private static string s, p;
        static void Main(string[] args)
        {
            s = "aab";
            p = "c*a*b";

            Program P = new Program();
            Console.WriteLine(P.CheckValidity(p, s));
        }

        public bool CheckValidity(string pattern, string S)
        {
            int Slen = S.Length;
            int Plen = pattern.Length;
            bool[,] dp = new bool[Slen+1, Plen+1];
            dp[0, 0] = true;

            for (int i = 0; i < Slen; i++)
            {
                for (int j = i; j < Plen; j++)
                {
                    FillResult(dp, i-1, j-1, i , j);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < Plen; i++)
                if (dp[Slen - 1, i])
                    return true;

            return false;
        }

        public void FillResult(bool[,] dp, int sIndex, int pIndex, int i, int j)
        {

            if (p[pIndex] == '*')
            {
                if (i > 0 && (p[pIndex - 1] == s[sIndex] || p[pIndex - 1] == '.'))
                {
                    // aa    * = 0 (dp[i, j-2])   aa   * = 1~n (dp[i - 1, j])
                    //  a*                         a*
                    dp[i, j] = dp[i, j - 2] || dp[i - 1, j];
                }
                else
                {
                    // ab   * = 0 (dp[i, j-2])
                    //  a*
                    dp[i, j] = dp[i, j - 2];
                }
            }
            else if (i > 0 && p[pIndex] == '.')
            {
                // abc
                // ab.
                dp[i, j] = dp[i - 1, j - 1];
            }
            else
            {
                if (i > 0 && p[pIndex] == s[sIndex])
                {
                    // ab
                    // ab
                    dp[i, j] = dp[i - 1, j - 1];
                }
            }
        }
    }
}
