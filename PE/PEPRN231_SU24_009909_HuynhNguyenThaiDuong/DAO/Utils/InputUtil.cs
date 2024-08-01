using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Utils
{
    public class InputUtil
    {
        public static bool CheckCapitalLetter(string name)
        {
            string[] part = name.Split(' ');

            foreach (string s in part)
            {
                if (!char.IsUpper(s[0]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
