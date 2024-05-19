using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

[Routes]
public partial class SuikaCollisionPresenter : ICollisionCalculator
{
    [Inject] readonly SuikaContainer _container;
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
            Debug.Log($"{command.MyId.Value} hit {command.OtherId.Value} at frame {command.Frame}");
            if (_container.TryGetById(command.MyId, out var mySuika) &&
                _container.TryGetById(command.OtherId, out var otherSuika))
            {
                // 同種のスイカが書突した場合は進化する
                if (mySuika.Type == otherSuika.Type)
                {
                    Debug.Log($"進化 from {mySuika.Type}");
                }
            }
        }
        _commandList.Clear();
    }
}
