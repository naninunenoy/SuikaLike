using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using SuikaLike.GameFeatures;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike
{
    public partial class GameEntryPoint : IAsyncStartable, ILateTickable
    {
        [Inject] readonly IObjectResolver _resolver;
        [Inject] readonly LifetimeScope _lifetimeScope;
        [Inject] readonly GameEntryPointParameter _param;
        [Inject] readonly ISuikaViewRenderer _viewRenderer;
        [Inject] readonly ISuikaFactory _factory;
        [Inject] readonly SuikaCollisionPresenter _collisionPresenter;
        [Inject] readonly SuikaSpawnPresenter _spawnPresenter;

        public UniTask StartAsync(CancellationToken cancellation)
        {
            _viewRenderer.SetScore(0);
            UpdateNextSuika();
            _ = _resolver.Instantiate(_param.MouseObserverPrefab, _lifetimeScope.transform);

            // 次のスイカはここで決める
            _spawnPresenter.SpawnByClick
                .Subscribe(_ => UpdateNextSuika())
                .RegisterTo(cancellation);

            return UniTask.CompletedTask;
        }

        public void LateTick()
        {
            _collisionPresenter.NotifyFrameEnd(Time.frameCount);
        }

        void UpdateNextSuika()
        {
            var next = _factory.GetNextSuika();
            _spawnPresenter.NotifyNextSpawnType(next);
            _viewRenderer.SetNextEmoji(next.GetEmoji());
        }
    }

    public class GameEntryPointParameter
    {
        public required Camera MainCamera { get; init; }
        public required GameObject SuikaPrefab { get; init; }
        public required GameObject MouseObserverPrefab { get; init; }
        public required Transform BoxTransform { get; init; }
    }
}
