using System;
using System.Configuration;
using System.IO;

namespace SearchEnginePopularityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string keyWord = null;
                while (string.IsNullOrWhiteSpace(keyWord))
                {
                    Console.WriteLine("Please Enter Keyword to be Searched (it cannot be null or blank):");
                    keyWord = Console.ReadLine();
                }

                string url = null;
                while (string.IsNullOrWhiteSpace(url))
                {
                    Console.WriteLine(
                        "Please Enter URL whose Popularity Needs to be Evaluated (it cannot be null or blank):");
                    url = Console.ReadLine();
                }

                /* string keyWord = "conveyancing software";
                 string URL = "www.smokeball.com.au";*/

                PopularityEvaluator evaluator = new PopularityEvaluator(new Google());

                string result = string.Join(",",
                    evaluator.EvaluatePopularity(keyWord, url,
                        int.Parse(ConfigurationManager.AppSettings["searchCount"])));//get list of matching search result indexes

                Console.WriteLine(String.Format("{0} was found on the following Search Results:{1} ", url, result));

                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
            catch (Exception ex)
            {
                //program could be extended to do more detailed logging
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\Logs.txt", ex.Message + "" + ex.StackTrace + Environment.NewLine);

                Console.Write("An error occured: " + ex.Message);
                Console.WriteLine("Press any key to exit.");
                Console.Read();
            }
        }
    }

}

