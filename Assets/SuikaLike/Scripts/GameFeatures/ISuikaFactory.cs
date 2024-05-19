using UnityEngine;

namespace SuikaLike.GameFeatures;

public interface ISuikaFactory
{
    SuikaObject SpawnSuikaOf(SuikaType type, Vector2 position, long currentFrame);
}
