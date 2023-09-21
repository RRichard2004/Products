namespace ConsoleApp2
{
    internal class Program
    {
        class Allat
        {
            protected string hely;
            protected string beszel;

            public Allat(string hely) 
            {
                this.hely = hely;
            }
            
            public override string? ToString()
            {
                return base.ToString();
            }
            public virtual void Beszel() 
            {
                beszel = "";
            }


            public string MitMond() { return beszel; }

        }

        class Kutya : Allat
        {
            protected string gazdi;

            public Kutya(string gazdi,string hely):base(hely)
            {
                this.gazdi = gazdi;
            }
            public override void Beszel()
            {
                beszel = "wau";
            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Allat a = new Allat("MISKOLC");
            a.Beszel();
            Kutya k = new Kutya("ARNOT", "jOCI");
            k.Beszel();
            Console.WriteLine(a.MitMond());
            Console.WriteLine(k.MitMond());
        }
    }
}