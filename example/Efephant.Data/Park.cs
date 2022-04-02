using Efephant.Protocol;

namespace Efephant.Data;

public class Park
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public static Park FromCandidate(ParkCandidate candidate)
    {
        return new Park
        {
            Name = candidate.Name
        };
    }

    public Protocol.Park ToProtocol()
    {
        return new (this.Id.ToString(), this.Name);
    }
}