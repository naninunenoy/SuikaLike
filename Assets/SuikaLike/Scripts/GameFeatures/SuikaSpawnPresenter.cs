using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaSpawnPresenter
{
    [Inject] readonly ISuikaFactory _factory;

    public void __DontCallMe(PointerUpCommand command)
    {
        var (_, _) = _factory.SpawnSuika(command.Position);
    }
}
