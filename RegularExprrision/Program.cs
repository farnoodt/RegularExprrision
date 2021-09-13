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
            bool[,] result = new bool[Slen, Plen];
            result[0, 0] = true;

            for (int i = 0; i < Slen; i++)
            {
                for (int j = i; j < Plen; j++)
                {
                    FillResult(result, i, j);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < Plen; i++)
                if (result[Slen - 1, i])
                    return true;

            return false;
        }

        public void FillResult(bool[,] result, int i, int j)
        {

            if (i == 0)
            {
                if (s[i] == p[j] || p[j] == '.')
                {
                    result[i, j] = true;
                    return;
                }

                if (j > 0)
                {
                    if((p[j] == '*' && p[j - 1] == s[i]) || p[j - 1] == '.')
                    result[i, j] = true;
                    return;
                }
                return;
            }
            else
            {
                if (result[i - 1, j - 1])
                {
                    if (s[i] == p[j] || p[j] == '.')
                    {
                        result[i, j] = true;
                        return;
                    }

                    if (p[j] == '*' && (p[j - 1] == s[i] || p[j-1] == '.'))
                    {
                        result[i, j] = true;
                        return;
                    }
                }
            }
        }
    }
}
