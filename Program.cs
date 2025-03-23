using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Title must not be null and should be at most 100 characters long");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 10000000, "Play count increment must be between 1 and 10,000,000");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count overflow detected.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Aryoseto");
        video.PrintVideoDetails();

        video.IncreasePlayCount(10000000);
        video.PrintVideoDetails();

        for (int i = 0; i < 100; i++)
        {
            video.IncreasePlayCount(10000000);
        }
    }
}
