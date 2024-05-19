using System;
using VContainer;
using VitalRouter;
using Random = UnityEngine.Random;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaSpawnPresenter
{
    [Inject] readonly ISuikaFactory _factory;

    public void __DontCallMe(PointerUpCommand command)
    {
        var randomType = (SuikaType)Random.Range(0, Enum.GetNames(typeof(SuikaType)).Length);
        _ = _factory.SpawnSuikaOf(randomType, command.Position, command.Frame);
    }
}
