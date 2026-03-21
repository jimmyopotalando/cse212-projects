using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find all symmetric pairs of two-character words
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip same-character words
            var reversed = new string(new[] { word[1], word[0] });

            if (wordSet.Contains(reversed))
            {
                if (string.Compare(word, reversed) < 0)
                    result.Add($"{word} & {reversed}");
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from census file
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Check if two words are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = new string(word1.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
        word2 = new string(word2.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());

        if (word1.Length != word2.Length) return false;

        var count = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (count.ContainsKey(c)) count[c]++;
            else count[c] = 1;
        }

        foreach (var c in word2)
        {
            if (!count.ContainsKey(c)) return false;
            count[c]--;
            if (count[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Fetch daily earthquake data from USGS
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag ?? 0.0;
            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}