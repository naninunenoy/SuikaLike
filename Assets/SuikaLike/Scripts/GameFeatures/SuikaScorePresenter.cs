using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaScorePresenter
{
    [Inject] readonly ISuikaViewRenderer _renderer;
    int _totalScore = 0;

    public void __DontCallMe(SameTypeSuikaCollisionCommand command)
    {
        // 衝突の進化により生み出されたスイカにより得点が決まる
        if (command.OriginalType.TryGetNextEvolution(out var nextType))
        {
            _totalScore += nextType.GetScore();
        }
        _renderer.SetScore(_totalScore);
    }
}
