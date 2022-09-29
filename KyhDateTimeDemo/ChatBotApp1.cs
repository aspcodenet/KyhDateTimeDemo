using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyhDateTimeDemo
{
    /*
      *Random AI Chatbot

**********************



Skapa en funktion som ska returnera en random text från en lista med en massa "svar" tex



"Jag mår bra"
"Lämna mig ifred"
"Vad sa du?"
"whatever"
"Kanske det"
"Ingen aning"
"Ja vad bra"

Sen skriver du en liten "chatbot", användaren matar in och du anropar funktionen för att få ett svar och 

skriver ut svaret. Och upprepa forever


     *
     */
    public class ChatBotApp1
    {

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(":");
                var input = Console.ReadLine();
                var answer = GetRandomAnswer();
                Console.WriteLine(answer);
            }
        }

        private string GetRandomAnswer()
        {
            var random = new Random();
            var arrayOfAnswers = new string[]
            {
                "Jag mår bra",
                "Lämna mig ifred",
                "Vad sa du?",
                "whatever",
                "Kanske det",
                "Ingen aning",
                "Ja vad bra",
                "Stick och brinn",
                "Hej då"
            };
            int index = random.Next(0, arrayOfAnswers.Length);
            return arrayOfAnswers[index];
        }
    }






    public class ChatBotBob
    {

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(":");
                var input = Console.ReadLine();
                var answer = GenerateResponse(input);
                Console.WriteLine(answer);
            }
        }

        private string GenerateResponse(string input)
        {
            if (input.EndsWith("?")) return "Sure!";
            return "";
        }
    }
}
