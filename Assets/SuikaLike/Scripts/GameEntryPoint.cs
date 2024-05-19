using System.Threading;
using Cysharp.Threading.Tasks;
using SuikaLike.GameFeatures;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike
{
    public class GameEntryPoint : IAsyncStartable, ILateTickable
    {
        [Inject] readonly IObjectResolver _resolver;
        [Inject] readonly LifetimeScope _lifetimeScope;
        [Inject] readonly ICollisionCalculator _collisionCalculator;
        [Inject] readonly GameEntryPointParameter _param;
        [Inject] readonly ISuikaViewRenderer _viewRenderer;

        public UniTask StartAsync(CancellationToken cancellation)
        {
            _viewRenderer.SetScore(0);
            _ = _resolver.Instantiate(_param.MouseObserverPrefab, _lifetimeScope.transform);
            return UniTask.CompletedTask;
        }

        public void LateTick()
        {
            _collisionCalculator.NotifyFrameEnd(Time.frameCount);
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
