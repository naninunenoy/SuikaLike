using UnityEngine;

namespace SuikaLike.GameFeatures;

public interface ISuikaFactory
{
    (SuikaId id, GameObject suika) SpawnSuika(Vector2 position);
}
