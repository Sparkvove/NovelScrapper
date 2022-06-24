namespace BasicNovelScrapper
{


class Program
{
    static void Main(string[] args)
    {
      
            List<Novel> novels = new List<Novel>();
            var LightNovelPubScrapper = new LightNovelPubScrapper();
            Console.WriteLine("Downloading Novels...");
            novels = LightNovelPubScrapper.GetNovels();
            Console.WriteLine("Saving Novels...");
            var saveToJson = new JsonService(novels);
            Console.WriteLine("Program finished, you can safely exit...");

        }

}


}