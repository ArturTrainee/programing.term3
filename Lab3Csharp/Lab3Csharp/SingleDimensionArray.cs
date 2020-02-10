using System.Linq;

namespace Lab3Csharp
{
    internal class SingleDimensionArray<E>
    {
        public SingleDimensionArray(E element) : this(new E[] { element })
        {
        }

        public SingleDimensionArray(E[] elements)
        {
            Elements = elements ?? throw new System.ArgumentNullException("Elements are null");
        }

        public E[] Elements { get => Elements; set => Elements = value; }

        public E this[int index]
        {
            get => Elements[index];
            set => Elements[index] = value;
        }

        public E GetMax() => Elements.Max();

        public E GetMin() => Elements.Min();

        public override string ToString() => string.Join("\t", Elements.Select(e => e.ToString()).ToArray());
    }
}