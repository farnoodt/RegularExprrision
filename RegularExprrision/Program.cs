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
            var ns = s.Length;
            var np = p.Length;

            var dp = new bool[ns + 1, np + 1];

            // init - only s: "" and p: "" => true, the other all false
            dp[0, 0] = true;

            for (int i = 0; i <= ns; i++)
            {
                var sIndex = i - 1;
                for (int j = 1; j <= np; j++)
                {
                    var pIndex = j - 1;

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

            return dp[ns, np];
        }


    }
}
