using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaSpawnPresenter
{
    [Inject] readonly ISuikaFactory _factory;
    [Inject] readonly SuikaContainer _container;

    public void __DontCallMe(PointerUpCommand command)
    {
        var suika = _factory.SpawnSuika(_factory.GetNextSuika(), command.Position);
        _container.Add(suika);
    }
}
