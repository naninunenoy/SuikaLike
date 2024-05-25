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

        public SuikaId Id { set; get; } = SuikaId.Zero;

        void Start()
        {
            _collider.OnCollisionEnter2DAsObservable()
                .Subscribe(hit =>
                {
                    if (hit.gameObject.TryGetComponent<SuikaComponent>(out var otherSuika))
                    {
                        _commandPublisher.PublishAsync(new SuikaCollisionCommand
                        {
                            MyId = Id,
                            OtherId = otherSuika.Id,
                            Frame = Time.frameCount
                        });
                    }
                })
                .RegisterTo(destroyCancellationToken);
        }
    }
}
