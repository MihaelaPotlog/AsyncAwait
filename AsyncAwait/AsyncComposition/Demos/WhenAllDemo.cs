using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsyncAwait.AsyncComposition.Demos;

class WhenAllDemo
{
  private static readonly HttpClient _httpClient;

  static WhenAllDemo()
  {
    _httpClient = new HttpClient();
    _httpClient.BaseAddress = new Uri("https://uselessfacts.jsph.pl/api/v2/facts/random");
  }

  public async static Task GetRandomFactsAsync()
  {
    var getFactTasks = new List<Task<Fact>>();

    string[] languages = ["en", "de"];
    
    try
    {
      foreach (var language in languages)
      {
        getFactTasks.Add(GetRandomFactAsync(language));
      }

      var activities = await Task.WhenAll(getFactTasks);

      activities.ToList().ForEach(fact => Console.WriteLine(fact));
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error retrieving fact: " + ex.Message);
    }
  }

  private static async Task<Fact> GetRandomFactAsync(string language)
  {
    var response = await _httpClient.GetAsync($"?language={language}");
    response.EnsureSuccessStatusCode();

    var fact = await response.Content.ReadAsStringAsync();

    return JsonSerializer.Deserialize<Fact>(fact);
  }
}

public class Fact
{
  [JsonPropertyName("text")]
  public string Text { get; set; }

  [JsonPropertyName("language")]
  public string Language { get; set; }

  public override string ToString()
  {
    return $"Fact in {Language}: {Text}";
  }
}


