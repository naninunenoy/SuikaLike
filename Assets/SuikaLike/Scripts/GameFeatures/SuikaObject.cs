using UnityEngine;

namespace SuikaLike.GameFeatures;

public class SuikaObject
{
    public required SuikaId Id { get; init; }
    public required SuikaType Type { get; init; }
    public required long SpawnFrame { get; init; }
    public required GameObject GameObject { get; init; }
}
