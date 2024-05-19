using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaSpawnPresenter
{
    [Inject] IObjectResolver _resolver;
    [Inject] GameEntryPointParameter _param;

    public void __DontCallMe(PointerUpCommand command)
    {
        SpawnSuika(command.Position);
    }

    GameObject SpawnSuika(Vector2 position)
    {
        return _resolver.Instantiate(_param.SuikaPrefab, position, Quaternion.identity, _param.BoxTransform);
    }
}
