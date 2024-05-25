using System.Collections.Generic;
using System.Linq;
using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaCollisionPresenter
{
    [Inject] readonly ISuikaIdResolver _suikaResolver;
    [Inject] readonly ICommandPublisher _commandPublisher;
    readonly List<SuikaCollisionCommand> _commandList = new();

    public void __DontCallMe(SuikaCollisionCommand command)
    {
        // 同種の衝突が含まれないようフィルタ
        if (_commandList.Any(x => x.Frame == command.Frame && x.MyId == command.OtherId && x.OtherId == command.MyId)) return;
        _commandList.Add(command);
    }

    public void NotifyFrameEnd(long frame)
    {
        // 衝突の評価を行う
        foreach (var command in _commandList)
        {
            if (_suikaResolver.TryGetById(command.MyId, out var mySuika) &&
                _suikaResolver.TryGetById(command.OtherId, out var otherSuika))
            {
                // 同種のスイカが書突した場合は進化する
                if (mySuika.Type == otherSuika.Type)
                {
                    _commandPublisher.PublishAsync(new SameTypeSuikaCollisionCommand
                    {
                        OriginalType = mySuika.Type, Originals = new[] { mySuika, otherSuika },
                    });
                }
            }
        }
        _commandList.Clear();
    }
}
