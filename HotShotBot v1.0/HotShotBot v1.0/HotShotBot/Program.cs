using System;
using AIMLbot;
using System.Speech.Synthesis;



namespace HotShotBot
{

    public class HotShotBot
    {

        const string UserId = "consoleUser";
        private Bot AimlBot;
        private User myUser;
  
        public HotShotBot()
        {
       
            //------I added this code just coz I love that Light Green Geeky Looking Console ;-)------
                    //Console.BackgroundColor = ConsoleColor.Blue;
                      Console.ForegroundColor = ConsoleColor.Green;
            //----------------------------------------------------------------------------------------

            AimlBot = new Bot();
            myUser = new User(UserId, AimlBot);
            Console.Title = "HotShotBot v1.0 - By Vivek Yadav (www.Shellvhack.com)";
            Initialize();
        }

        // Loads all the AIML files in the \AIML folder         
        public void Initialize()
        {
            AimlBot.loadSettings();
            AimlBot.isAcceptingUserInput = false;
            AimlBot.loadAIMLFromFiles();
            AimlBot.isAcceptingUserInput = true;
        }

        // Given an input string, finds a response using AIMLbot lib
        public String getOutput(String input)
        {
            Request r = new Request(input, myUser, AimlBot);
            Result res = AimlBot.Chat(r);
            return (res.Output);
        }
    }
    class Program
    {
        static HotShotBot bot;
        static void Main(string[] args)
        {
            string input="start";
            while (input!="exit" )
            {
            
                bot = new HotShotBot();
                Console.Write("You: ");
                input = Console.ReadLine();
                var output = bot.getOutput(input);
                
                //Console.WriteLine(input);
                Console.WriteLine("Bot: " + output);
            
                //Make the bot Speak
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = -2;     // -10...10

                // Synchronous
                synthesizer.Speak(output);

                // Asynchronous
                // synthesizer.SpeakAsync(output);

            }
         }
    }
}
