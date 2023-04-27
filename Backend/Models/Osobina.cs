namespace Models;

public class Osobina
{
    [Key]
    public int ID { get; set; }
    public required string Naziv { get; set; }
    public required string Vrednost { get; set; }
    public required bool ViseVrednosti { get; set; }

    [JsonIgnore]
    public List<Ptica>? Ptica { get; set; }
    public List<NepoznataPtica>? Nepoznata { get; set; }
}
