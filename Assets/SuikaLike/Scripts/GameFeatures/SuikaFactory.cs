using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.GameFeatures;

public class SuikaFactory : ISuikaFactory
{
    [Inject] readonly IObjectResolver _resolver;
    [Inject] readonly GameEntryPointParameter _param;

    public (SuikaId id, GameObject suika) SpawnSuika(Vector2 position)
    {
        var suika = _resolver.Instantiate(_param.SuikaPrefab, position, Quaternion.identity, _param.BoxTransform);
        var suikaId = new SuikaId(suika.GetHashCode());
        suika.name = $"suika#{suikaId.Value:x8}";
        return (suikaId, suika);
    }
}
