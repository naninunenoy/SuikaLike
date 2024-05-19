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

    public void __DontCallMe(SameTypeSuikaCollisionCommand command)
    {
        // 削除する前に衝突したスイカの位置だけ持っておく
        var position1 = command.Originals[0].GameObject.transform.position;
        var position2 = command.Originals[1].GameObject.transform.position;
        // 旧スイカの削除
        foreach (var suika in command.Originals)
        {
            _container.Remove(suika.Id);
        }
        // 進化先を判定
        if (command.OriginalType.TryGetNextEvolution(out var nextType))
        {
            // 進化したスイカを生み出す
            var centerOfPositions = (position1 + position2) / 2.0F;
            var suika = _factory.SpawnSuika(nextType, centerOfPositions);
            _container.Add(suika);
        }
    }
}
