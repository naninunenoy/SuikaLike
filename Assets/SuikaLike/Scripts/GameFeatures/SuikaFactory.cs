using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.GameFeatures;

public class SuikaFactory : ISuikaFactory
{
    const int NormalValue = (int)SuikaType.Normal;
    [Inject] readonly IRandomValueProvider _random;
    [Inject] readonly IObjectResolver _resolver;
    [Inject] readonly GameEntryPointParameter _param;

    public SuikaType GetNextSuika()
    {
        return (SuikaType)_random.GetRange(0, NormalValue + 1);
    }

    public SuikaObject SpawnSuika(SuikaType type, Vector2 position)
    {
        var suikaGo = _resolver.Instantiate(_param.SuikaPrefab, position, Quaternion.identity, _param.BoxTransform);
        var suikaCmp = suikaGo.GetComponent<SuikaComponent>();
        var suikaId = new SuikaId(suikaGo.GetHashCode());
        suikaCmp.Id = suikaId;
        var emoji = type.GetEmoji();
        suikaCmp.Text.text = emoji;
        var size = type.GetSize();
        suikaGo.transform.localScale = new Vector3(size, size, 1.0f);
        suikaGo.name = $"{emoji}#{suikaId.Value:x8}";
        return new SuikaObject
        {
            GameObject = suikaGo, Id = suikaId, Type = type
        };
    }
}
