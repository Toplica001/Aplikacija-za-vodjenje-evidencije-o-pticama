namespace Models;

public class NepoznataPtica
{
    [Key]
    public int ID { get; set; }
    public List<Osobina>? Osobine { get; set; }
}
