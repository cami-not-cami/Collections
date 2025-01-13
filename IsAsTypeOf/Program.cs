
namespace IsAsTypeOf
{
    public class Tier
    {
        public string Name { get; set; }
    }
    public class Katze : Tier
    {
        public void Miau()
        {
            Console.WriteLine("Miau");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new Katze();
            Katze meinTier = new Katze(); //Erstelle object
            katze.Name = "zurli";
            Tier tier = meinTier ;// greife mit Base Reference zu
            meinTier.Name = "gucci";

            katze.Miau();

            if (katze is Tier)
            {
                Console.WriteLine("Type stimmt!");
            }
            else
            {
                Console.WriteLine("Type falsch");
            }
            //Expliziertes Casten von Objekttypen bei Vererbungen
            // entspricht (Katze)neuesTier
            Katze meineKatze = meinTier as Katze; //umwandel in ursprungliche klasse
            meineKatze.Name = "REY";
            //meineKatze.Miau();
            Console.WriteLine(meineKatze.Name);


            if (meineKatze.GetType()== typeof(Tier))
            {
                Type test = meineKatze.GetType();
                Console.WriteLine(test);
            }

            int cici = 1091;
            object pisi = cici;
            cici = 2049;
            Console.WriteLine("Der wert is {0}",pisi);
            Console.WriteLine("Der wert is {0}", cici);
            int kirirk = (int)pisi;
            Console.WriteLine(kirirk);


        }
    }
}
