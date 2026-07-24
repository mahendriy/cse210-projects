using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics", "Tessa Reed", 540);
        video1.AddComment(new Comment("Owen", "Great intro to classes!"));
        video1.AddComment(new Comment("Mina", "The examples were very clear."));
        video1.AddComment(new Comment("Liam", "I learned a lot from this video."));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Design", "Marcus Lee", 720);
        video2.AddComment(new Comment("Nora", "This helped me understand abstraction."));
        video2.AddComment(new Comment("Eli", "The diagrams made the concepts easier to follow."));
        video2.AddComment(new Comment("Sage", "I want to watch more videos like this."));
        video2.AddComment(new Comment("Jules", "Excellent explanation of responsibilities."));
        videos.Add(video2);

        Video video3 = new Video("Encapsulation in Practice", "Priya Shah", 610);
        video3.AddComment(new Comment("Ben", "The private fields example was very useful."));
        video3.AddComment(new Comment("Maya", "I can see how this applies to real projects."));
        video3.AddComment(new Comment("Kai", "Nice and concise walkthrough."));
        videos.Add(video3);

        Console.WriteLine("YouTube Video Summary");
        Console.WriteLine("---------------------");

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int LengthSeconds
    {
        get { return _lengthSeconds; }
    }

    public List<Comment> Comments
    {
        get { return _comments; }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}

class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string Text
    {
        get { return _text; }
    }
}