using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel
{
    public static class Randomer
    {
        private static Random _rand;
        static Randomer()
        {
            _rand = new Random();
        }

        public static string GenerateKey()
        {
            char[] str = new char[6];
            for (int i = 1; i <= 3; i++)
            {
                switch(i)
                {
                    case 1:
                        str[0] = (char)_rand.Next(65, 90);
                        str[1] = (char)_rand.Next(65, 90);
                        break;
                    case 2:
                        str[2] = (char)_rand.Next(48, 57);
                        str[3] = (char)_rand.Next(48, 57);
                        break;
                    case 3:
                        str[4] = (char)_rand.Next(65, 90);
                        str[5] = (char)_rand.Next(65, 90);
                        break;
                    default:
                        break;
                }
            }
            return new string(str);
        }
    }
}
