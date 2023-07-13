using System;

namespace Ip_Validator
{
    class Program
    {
        static void Main()
        {
            void Log(object o) => Console.WriteLine(o);
            Log(is_valid_IP("01.02.03.04")); // should be false
            Log(is_valid_IP("1.1.1.1")); // should be true
        }
        public static bool is_valid_IP(string IpAddres)
        {
            string[] adress = IpAddres.Split('.');
            if (adress.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                int result;

                // this will erroneously reject 0.0.0.0
                if (adress[i][0] == '0')
                {
                    return false;
                }

                if (!int.TryParse(adress[i], out result))
                {
                    return false;
                }

                if (result > 255)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
