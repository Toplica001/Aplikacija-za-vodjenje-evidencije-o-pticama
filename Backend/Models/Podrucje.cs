namespace Models;

public class Podrucje
{
    [Key]
    public int ID { get; set; }
    public required string Naziv { get; set; }

    //[JsonIgnore]
    public List<Vidjenje>? Vidjenja { get; set; }
}
