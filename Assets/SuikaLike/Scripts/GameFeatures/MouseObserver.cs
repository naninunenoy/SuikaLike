using UnityEngine;
using VContainer;

namespace SuikaLike.GameFeatures
{
    public class MouseObserver : MonoBehaviour
    {
        [Inject] IPointerCommandPublisher _publisher;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _publisher.NotifyPointerDown(Time.frameCount, Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _publisher.NotifyPointerUp(Time.frameCount, Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                _publisher.NotifyPointerMove(Time.frameCount, Input.mousePosition);
            }
        }
    }
}
