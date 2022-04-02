using Efephant.Data;
using Microsoft.EntityFrameworkCore;

[Route(Uris.Parks)]
public class ParkController
{
    public Context Context { get; }

    public ParkController(Context context)
    {
        Context = context;
    }

    [HttpPost]
    public async Task<Efephant.Protocol.Park> Post([FromBody] ParkCandidate candidate)
    {        
        var added = this.Context.Parks.Add(Efephant.Data.Park.FromCandidate(candidate));
        await this.Context.SaveChangesAsync();

        return added.Entity.ToProtocol();
    }

    [HttpGet]
    public async Task<IEnumerable<Efephant.Protocol.Park>> Get()
    {
        var records = await this.Context.Parks.ToListAsync();
        return records.Select(e => e.ToProtocol());
    }
}