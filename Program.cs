using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Numerics;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            Assert.AreEqual(ex1("Ana are mere si galbene"), "si");
            Assert.AreEqual(ex2(new Vector2(1, 5), new Vector2(4, 1)), 5.0f);
            Assert.AreEqual(ex3(new int[] { 1, 0, 2, 0, 3 }, new int[] { 1, 2, 0, 3, 1 }), 4);
            CollectionAssert.AreEqual(ex4("ana are ana are mere rosii ana"), new string[] { "mere", "rosii" });
            Assert.AreEqual(ex5(new int[] { 1, 2, 3, 4, 2 }), 2);
        }

        //values - vector de int-uri
        static private int ex5(int[] values)
        {
            return values.GroupBy(w => w).Where(g => g.Count() > 1).Select(g => g.Key).ToArray()[0];
        }

        //text - string-ul din care sa se gaseasca cuvintele unice
        static private string[] ex4(string text)
        {
            string[] words = text.Split(' ');
            return words.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key).ToArray();
        }

        //a, b - doi vectori de int-uri de aceeasi marime
        static private int ex3(int[] a, int[] b)
        {
            int product = 0;
            for(int i = 0; i < a.Length; i++)
            {
                product += a[i] * b[i];
            }
            return product;
        }

        //a, b - doua locatii
        static private float ex2(Vector2 a, Vector2 b)
        {
            return MathF.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
        }

        //text - textul din care se returneaza ultimul cuvant din punct de vedere alfabetic
        static private string ex1(string text)
        {
            string[] words = text.Split(' ');
            char max = (char)0;
            string w = "";
            foreach(string word in words)
            {
                if(word[0] >= max)
                {
                    max = word[0];
                    w = word;
                }
            }
            return w;
        }
    }
}
