using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode
{
    class PasswordOne
    {
        public int max;
        public char condition;
        public int min;
        public string password;
        public bool valid;

        public PasswordOne(int min, int max, char condition, string password)
        {
            this.min = min;
            this.max = max;
            this.condition = condition;
            this.password = password;
            isValid();
        }

        public void isValid()
        {
            int cnt = 0;
            foreach(char cur in password)
            {
                if (cur == condition)
                    cnt++;
            }

            if (cnt <= max && cnt >= min)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
        }
    }
}
