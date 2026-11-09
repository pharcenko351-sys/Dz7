using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {

            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            ChristmasTree tree = new ChristmasTree();
            tree = new Toys(tree, "chervoni kuli");
            tree = new Garland(tree);
            tree.Show();
            tree.Shine();

            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }
        void AddedBehavior()
        { }
    }

    class ChristmasTree
    {
        public virtual void Show() { Console.WriteLine("Yalynka"); }
        public virtual void Shine() { Console.WriteLine("Ne svityt'sya"); }
    }

    class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;
        public TreeDecorator(ChristmasTree t) { tree = t; }
        public override void Show() { tree.Show(); }
        public override void Shine() { tree.Shine(); }
    }

    class Toys : TreeDecorator
    {
        private string toys;
        public Toys(ChristmasTree t, string p) : base(t) { toys = p; }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("  + prykrasy: " + toys);
        }
    }

    class Garland : TreeDecorator
    {
        public Garland(ChristmasTree t) : base(t) { }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("  + girlyanda");
        }
        public override void Shine() { Console.WriteLine("Svityt'sya"); }
    }

}
