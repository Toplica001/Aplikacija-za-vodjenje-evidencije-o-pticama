namespace Models;

public class Vidjenje
{
    [Key]
    public int ID { get; set; }
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
    public required DateTime Vreme { get; set; }

    [JsonIgnore]
    public Ptica? Ptica { get; set; }
    public Podrucje? Podrucje { get; set; }
}
