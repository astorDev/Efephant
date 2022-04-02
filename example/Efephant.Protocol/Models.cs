namespace Efephant.Protocol;

public record About(string Description, string Version, string Environment);

public record ParkCandidate(string Name);

public record Park(string Id, string Name);