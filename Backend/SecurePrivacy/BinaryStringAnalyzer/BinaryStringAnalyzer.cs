using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStringAnalyzer
{
    public class BinaryStringAnalyzer
    {
        public static bool IsGoodBinaryString(string binaryString)
        {
            int count0 = 0, count1 = 0;

            foreach (char c in binaryString)
            {
                if (c == '0')
                {
                    count0++;
                }
                else if (c == '1')
                {
                    count1++;
                }
                else
                {
                    return false;
                }

                if (count1 < count0)
                {
                    return false;
                }
            }

            return count0 == count1;
        }

    }
}
