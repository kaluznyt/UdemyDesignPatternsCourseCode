﻿using System;
using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple
{
    public class Journal
    {
        public readonly List<string> _entries = new List<string>();

        private static int _count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count;
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }
}