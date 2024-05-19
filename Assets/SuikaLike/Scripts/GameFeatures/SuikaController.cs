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
        _publisher.PublishAsync(new PointerMoveCommand { Frame = frame, Position = ToWorldPosition(position) });
    }

    public void NotifyPointerDown(long frame, Vector2 position)
    {
        _publisher.PublishAsync(new PointerDownCommand { Frame = frame, Position = ToWorldPosition(position) });
    }

    public void NotifyPointerUp(long frame, Vector2 position)
    {
        _publisher.PublishAsync(new PointerUpCommand { Frame = frame, Position = ToWorldPosition(position) });
    }

    Vector2 ToWorldPosition(Vector2 position) => _param.MainCamera.ScreenToWorldPoint(position);
}
