using System;
using System.Threading.Tasks;

namespace translation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0) {
                throw new ArgumentException("No text to translate! Please specify your text as quoted sentences.");
            }

            var client = new TranslatorClient();
            foreach (var sentence in args)
            {
                Console.WriteLine(await client.Translate(sentence));
            }
        }
    }
}
