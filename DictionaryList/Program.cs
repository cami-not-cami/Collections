namespace DictionaryList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();
            dict.Add("Princess",0.1F);
            dict.Add("Cami", 0.2F);
            dict.Add("Mia", 0.3F);
            dict.Add("matthias", 1.0F);
            dict.Add("Benn", 2.0F);
            dict.Add("Cate", 3.0F);
            dict.Add("Hannah", 4.0F);

            float test = dict["Cami"];

            



        }
    }
}
