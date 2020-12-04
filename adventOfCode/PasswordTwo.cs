using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode
{
    class PasswordTwo
    {
        public int posOne;
        public char condition;
        public int posTwo;
        public string password;
        public bool valid;

        public PasswordTwo(int posOne, int posTwo, char condition, string password)
        {
            this.posOne = posOne - 1;
            this.posTwo = posTwo - 1;
            this.condition = condition;
            this.password = password;
            isValid();
        }

        public void isValid()
        {   
            if ((password[posOne] != condition && password[posTwo] != condition)
                || (password[posOne] == condition && password[posTwo] == condition))
                valid = false;
            else
                valid = true;
        }
    }
}
