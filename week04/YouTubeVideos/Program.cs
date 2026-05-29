//---------------------------------------------------------------------------------
//
// CSE210 - Program.cs
// Title: W04 Foundation Program 1: YouTube Video Program
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = [];

        Video video1 = new Video("The Return of Jedi", "George Lucas", 175);

        video1.AddComment(new Comment("Mauricio", "I liked!"));
        video1.AddComment(new Comment("Brandon", "Brilliant Vader's acting."));
        video1.AddComment(new Comment("Rebeca", "The pacing is perfect."));
        video1.AddComment(new Comment("Daniel", "One of the best films ever made."));

        videos.Add(video1);

        Video video2 = new Video("The Chosen", "Dallas Jenkins", 142);

        video2.AddComment(new Comment("Julie", "Very inspiring story."));
        video2.AddComment(new Comment("Iraildes", "Emotionally powerful."));
        video2.AddComment(new Comment("Maria", "I liked the story."));
        video2.AddComment(new Comment("Filipe", "Absolutely unforgettable. Will watch it again!"));

        videos.Add(video2);

        Video video3 = new Video("Close Encounters of the Third Kind", "Steven Spielberg", 198);

        video3.AddComment(new Comment("Donald", "I cried, very strongly."));
        video3.AddComment(new Comment("James", "Could not be better."));
        video3.AddComment(new Comment("Barak", "The movie was very touching."));
        video3.AddComment(new Comment("Anitta", "The Movie was about what?"));

        videos.Add(video3);

        Video video4 = new Video("King Kong", "Peter Jackson", 201);

        video4.AddComment(new Comment("Josh", "Amazing... Amazing..."));
        video4.AddComment(new Comment("Angelia", "This movie brings me good feelings."));
        video4.AddComment(new Comment("Olivia", "Everything was fantastic, especially the soundtrack."));
        video4.AddComment(new Comment("Gillian", "The truth is out there, in the woods..."));

        videos.Add(video4);

        Console.Clear();

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title.........: {video.GetTitle()}");
            Console.WriteLine($"Author........: {video.GetAuthor()}");
            Console.WriteLine($"Length........: {video.GetLength()} minutes");
            Console.WriteLine($"Nº of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"    {comment.GetName()}: {comment.GetComment()}");
            }

            Console.WriteLine();
        }
    }
}