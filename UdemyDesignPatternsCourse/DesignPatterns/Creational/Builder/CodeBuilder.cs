using System.Collections.Generic;
using System.Text;

namespace UdemyDesignPatternsCourse.DesignPatterns.Builder
{
    public class CodeBuilder
    {
        private class Field
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }

        private List<Field> fields = new List<Field>();
        private StringBuilder sb = new StringBuilder();
        private int indentSize = 2;

        public CodeBuilder(string className)
        {
            sb.AppendLine($"public class {className}");
        }

        public CodeBuilder AddField(string name, string type)
        {
            this.fields.Add(new Field() { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            var indentation = new string(' ', indentSize);

            sb.AppendLine("{");
            foreach (var field in fields)
            {
                sb.AppendFormat($"{indentation}public {field.Type} {field.Name};");
                sb.AppendLine();
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
