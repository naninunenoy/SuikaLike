using R3;
using R3.Triggers;
using SuikaLike.GameFeatures;
using TMPro;
using UnityEngine;
using VContainer;
using VitalRouter;

namespace SuikaLike
{
    public class SuikaComponent : MonoBehaviour
    {
        [SerializeField] TextMeshPro _text = default;
        [SerializeField] CapsuleCollider2D _collider = default;
        [Inject] readonly ICommandPublisher _commandPublisher;

        public TextMeshPro Text => _text;
        public CapsuleCollider2D Collider => _collider;

        void Start()
        {
            _collider.OnCollisionEnter2DAsObservable()
                .Subscribe(hit =>
                {
                    if (hit.gameObject.TryGetComponent<SuikaComponent>(out var otherSuika))
                    {
                        var otherId = new SuikaId(otherSuika.gameObject.GetHashCode());
                        var myId = new SuikaId(gameObject.GetHashCode());
                        _commandPublisher.PublishAsync(new SuikaCollisionCommand
                        {
                            MyId = myId,
                            OtherId = otherId,
                            Frame = Time.frameCount
                        });
                    }
                })
                .RegisterTo(destroyCancellationToken);
        }
    }
}
