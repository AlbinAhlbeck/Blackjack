using System;

namespace UtilitiesLib
{
    public static class Parser
    {
        public static int ParseString(string anString)
        {
            int number;
            bool success = int.TryParse(anString, out number);
            if (success)
            {
                return number;
            }
            else
            {
                throw new Exception("Could not parse");
            }
                          
        }

        public static int ParseString(string anString, int highLimit, int lowLimit)
        {
            int number;

            bool success = int.TryParse(anString, out number);
            if (success)
            {
                if (number < highLimit && number > lowLimit)
                {
                    return number;
                }
            }
            
            throw new Exception("Could not parse");

        }

        public static string ParseInt(int anInt)
        {
            return anInt.ToString();
        }

        public static string ParseInt(int anInt, int lowLimit, int highLimit)
        {
            if (anInt < highLimit && anInt > lowLimit)
            {
                return anInt.ToString();
            }
            else
            {
                return null;
            }
        }


    }
}
