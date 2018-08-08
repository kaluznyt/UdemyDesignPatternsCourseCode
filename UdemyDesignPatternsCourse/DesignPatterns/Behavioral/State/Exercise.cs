using System;

namespace Coding.Exercise
{
    public class CombinationLock
    {
        public CombinationLock(int[] combination)
        {
            this.code = string.Join(string.Empty, combination);
        }

        // you need to be changing this on user input
        private string status = String.Empty;

        public string Status
        {
            get
            {
                if (this.status == this.code)
                {
                    return "OPEN";
                }
                else if (!this.code.StartsWith(this.status))
                {
                    return "ERROR";
                }
                else if (this.status == string.Empty)
                {
                    return "LOCKED";
                }
                else if (this.status.Equals(this.code))
                    return "UNLOCKED";
                else
                    return this.status;
            }
        }

        private readonly string code;

        public void EnterDigit(int digit)
        {
            this.status += digit;
        }
    }
}