using UnityEngine;
using VContainer;
using VitalRouter;

namespace SuikaLike.GameFeatures;

public class SuikaController : IPointerCommandPublisher
{
    [Inject] readonly GameEntryPointParameter _param;
    [Inject] readonly ICommandPublisher _publisher;

    public void NotifyPointerMove(long frame, Vector2 position)
    {
        var worldPosition = _param.MainCamera.ScreenToWorldPoint(position);
        _publisher.PublishAsync(new PointerMoveCommand { Frame = frame, Position = worldPosition });
    }

    public void NotifyPointerDown(long frame, Vector2 position)
    {
        var worldPosition = _param.MainCamera.ScreenToWorldPoint(position);
        _publisher.PublishAsync(new PointerDownCommand { Frame = frame, Position = worldPosition });
    }

    public void NotifyPointerUp(long frame, Vector2 position)
    {
        var worldPosition = _param.MainCamera.ScreenToWorldPoint(position);
        _publisher.PublishAsync(new PointerUpCommand { Frame = frame, Position = worldPosition });
    }
}
