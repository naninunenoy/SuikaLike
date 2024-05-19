using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.GameFeatures;

public class SuikaFactory : ISuikaFactory
{
    [Inject] readonly IObjectResolver _resolver;
    [Inject] readonly GameEntryPointParameter _param;

    public SuikaObject SpawnSuikaOf(SuikaType type, Vector2 position, long currentFrame)
    {
        var suikaGa = _resolver.Instantiate(_param.SuikaPrefab, position, Quaternion.identity, _param.BoxTransform);
        var suikaCmp = suikaGa.GetComponent<SuikaComponent>();
        var suikaId = new SuikaId(suikaGa.GetHashCode());
        suikaGa.name = $"{type}#{suikaId.Value:x8}";
        suikaCmp.Text.text = type.GetEmoji();
        var size = type.GetSize();
        suikaGa.transform.localScale = new Vector3(size, size, 1.0f);
        return new SuikaObject
        {
            GameObject = suikaGa, Id = suikaId, Type = type, SpawnFrame = currentFrame,
        };
    }
}
