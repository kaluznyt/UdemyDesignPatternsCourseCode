using System.Collections.Generic;
using System.Linq;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            int GetOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(GetOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i=>strings[i]));
    }
}