using VitalRouter;

namespace SuikaLike.GameFeatures;

public readonly struct SuikaCollisionCommand : ICommand
{
    public required SuikaId MyId { get; init; }
    public required SuikaId OtherId { get; init; }
    public required long Frame { get; init; }
}
