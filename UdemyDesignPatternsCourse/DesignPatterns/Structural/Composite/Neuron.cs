using System.Collections;
using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Composite
{
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;

        public List<Neuron> In = new List<Neuron>();
        public List<Neuron> Out = new List<Neuron>();

        public void ConnectTo(Neuron other)
        {
            Out.Add(other);
            other.In.Add(this);
        }

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}