using System;
using System.Collections.Generic;

// Class to represent a comment
public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Class to represent a YouTube video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            Console.WriteLine($"  - {comment.CommenterName}: \"{comment.Text}\"");
        }
        Console.WriteLine();
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create video 1
        Video video1 = new Video("C# Abstraction Explained", "TechGuru", 480);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "I finally understand abstraction."));
        video1.AddComment(new Comment("Charlie", "Very helpful, thanks!"));
        videos.Add(video1);

        // Create video 2
        Video video2 = new Video("Top 10 Coding Mistakes", "DevLife", 620);
        video2.AddComment(new Comment("David", "Number 4 happened to me yesterday."));
        video2.AddComment(new Comment("Eva", "Useful tips!"));
        video2.AddComment(new Comment("Frank", "Subscribed!"));
        video2.AddComment(new Comment("Grace", "Can you make a part 2?"));
        videos.Add(video2);

        // Create video 3
        Video video3 = new Video("Object-Oriented Programming Basics", "CodeAcademy", 900);
        video3.AddComment(new Comment("Henry", "This should be required viewing."));
        video3.AddComment(new Comment("Ivy", "Clear and concise."));
        video3.AddComment(new Comment("Jack", "Best OOP intro I've seen."));
        videos.Add(video3);

        // Create video 4 (optional extra to show 3-4 videos)
        Video video4 = new Video("Design Patterns in C#", "SoftwareArchitect", 1200);
        video4.AddComment(new Comment("Kevin", "Singleton pattern is my favorite."));
        video4.AddComment(new Comment("Laura", "Very professional."));
        video4.AddComment(new Comment("Mike", "Need more like this."));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}