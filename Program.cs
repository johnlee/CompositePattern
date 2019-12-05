using System;
using System.Collections.Generic;

namespace DnetComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composite Design Pattern");

            var root = new Composite("root");
            root.Add(new Leaf("LA"));
            root.Add(new Leaf("LB"));
            var comp1 = new Composite("C1");
            comp1.Add(new Leaf("C1.LA"));
            comp1.Add(new Leaf("C1.LB"));
            var comp2 = new Composite("C2");
            comp2.Add(new Leaf("C2.LA"));
            comp2.Add(new Leaf("C2.LB"));
            comp1.Add(comp2);
            root.Add(comp1);
            root.Add(new Leaf("LC"));

            var leaf = new Leaf("LD");
            root.Add(leaf);
            root.Remove(leaf);

            root.PrimaryOperation(1); // Example1
            Console.WriteLine("------------------");
            comp1.PrimaryOperation(1); // Example2
            Console.WriteLine("------------------");
            comp2.PrimaryOperation(1); // Example3

            //-root
            //-- - LA
            //-- - LB
            //-- - C1
            //---- - C1.LA
            //---- - C1.LB
            //---- - C2
            //------ - C2.LA
            //------ - C2.LB
            //-- - LC
            //------------------
            //- C1
            //-- - C1.LA
            //-- - C1.LB
            //-- - C2
            //---- - C2.LA
            //---- - C2.LB
            //------------------
            //- C2
            //-- - C2.LA
            //-- - C2.LB
        }
    }

    public abstract class Component
    {
        public string Name { get; }
        public Component(string name)
        {
            this.Name = name;
        }
        public abstract void PrimaryOperation(int depth);
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name) { }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
        }
    }

    public class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name) { }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
            foreach (var component in this.children)
            {
                component.PrimaryOperation(depth + 2);
            }
        }
        public void Add(Component c)
        {
            this.children.Add(c);
        }
        public void Remove(Component c)
        {
            this.children.Remove(c);
        }
    }
}
