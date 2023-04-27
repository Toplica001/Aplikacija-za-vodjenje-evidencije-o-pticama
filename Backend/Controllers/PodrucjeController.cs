namespace Primer.Controllers;

[ApiController]
[Route("[controller]")]
public class PodrucjeController : ControllerBase
{
    public Context Context { get; set; }

    public PodrucjeController(Context context)
    {
        Context = context;
    }

    [HttpGet("PreuzmiPodrcuja")]
    public async Task<ActionResult> PreuzmiPodrucja()
    {
        return Ok(await Context
            .Podrucja
            .Include(p => p.Vidjenja)
            /*.ThenInclude(p => p.Ptica)
            .Include(p => p.Vidjenja)
            .ThenInclude(p => p.Podrucje)*/
            .Select(p => new
            {
                PodrucjeID = p.ID,
                PodrucjeNaziv = p.Naziv,
                BrojVidjenja = p.Vidjenja!
                    .Count()
            })
            .ToListAsync());
    }

    [HttpPost("UpisiPodrucje/{nazivPodrucja}")]
    public async Task<ActionResult> UpisiPodrucje(string nazivPodrucja)
    {
        try
        {
            var podrucje = new Podrucje
            {
                Naziv = nazivPodrucja
            };
            await Context.Podrucja.AddAsync(podrucje);
            await Context.SaveChangesAsync();
            return Ok($"Podrucje sa ID: {podrucje.ID} je upisano.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
