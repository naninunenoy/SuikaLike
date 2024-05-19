using VitalRouter;

namespace SuikaLike.GameFeatures;

public class SameTypeSuikaCollisionCommand : ICommand
{
    public required SuikaType OriginalType { get; init; }
    public required SuikaObject[] Originals { get; init; }
}
