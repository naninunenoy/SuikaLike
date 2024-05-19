using UnityEngine;

namespace SuikaLike.GameFeatures;

public interface IPointerCommandPublisher
{
    void NotifyPointerMove(long frame, Vector2 position);
    void NotifyPointerDown(long frame, Vector2 position);
    void NotifyPointerUp(long frame, Vector2 position);
}
