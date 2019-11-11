using System.Linq;

namespace Lab3Csharp
{
    /* 1. Реалізувати клас, що представляє одновимірний масив і містить:
     * опис індексатора для доступу до елементів. 
     * Передбачити методи введення/виведення, 
     * знаходження максимального та мінімального елементів.
    */
    internal class SingleDimensionArray<E>
    {
        private E[] elements;

        public SingleDimensionArray(E element) : this(new E[] { element }) { }
        public SingleDimensionArray(E[] elements)
        {
            if (elements is null) throw new System.ArgumentNullException(nameof(elements));
            else this.Elements = elements;
        }

        public E this[int index]
        {
            get => Elements[index];
            set => Elements[index] = value;
        }

        public E[] Elements { get => Elements; set => Elements = value; }

        public E GetMax() => Elements.Max();

        public E GetMin() => Elements.Min();

        public override string ToString() => string.Join("\t", Elements.Select(e => e.ToString()).ToArray());
    }
}