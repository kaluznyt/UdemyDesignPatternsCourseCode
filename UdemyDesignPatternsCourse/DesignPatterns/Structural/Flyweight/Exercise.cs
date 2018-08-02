using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    class Exercise
    {
    }
    public class Sentence
    {
        private List<WordToken> words = new List<WordToken>();

        public Sentence(string plainText)
        {
            if (!string.IsNullOrWhiteSpace(plainText))
                foreach (var s in plainText.Split(' '))
                {
                    words.Add(new WordToken { Capitalize = false, word = s });
                }
        }

        public WordToken this[int index]
        {
            get
            {
                var token = words[index];
                return token;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var wordToken in words)
            {
                sb.Append($"{(wordToken.Capitalize ? wordToken.word.ToUpper() : wordToken.word)} ");

            }

            return sb.ToString().TrimEnd();
        }

        public class WordToken
        {
            public string word;
            public bool Capitalize;
        }
    }
}
