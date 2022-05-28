using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Variables
{
    public static int ScoreCount;

    public static Dictionary<string, int> Rating = new Dictionary<string, int>();

    public static void UpdateRating()
    {
        Rating.Clear();
        
        using (var sr = new StreamReader("rating.txt"))
        {
            while (!sr.EndOfStream)
            {
                var splitLine = sr.ReadLine()?.Split(',');
                if (splitLine != null)
                { 
                    Rating.Add(splitLine[0], Convert.ToInt32(splitLine[1]));
                }
            }
        }

        Rating = Rating.OrderByDescending(pair => pair.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}