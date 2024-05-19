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
        _ = _factory.SpawnSuika(_factory.GetNextSuika(), command.Position, command.Frame);
    }
}
