using UnityEngine;

namespace SuikaLike.GameFeatures;

public interface ISuikaFactory
{
    SuikaType GetNextSuika();
    SuikaObject SpawnSuika(SuikaType type, Vector2 position);
}
