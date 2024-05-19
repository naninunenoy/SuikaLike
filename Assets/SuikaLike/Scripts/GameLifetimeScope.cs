using SuikaLike.GameFeatures;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;
using VitalRouter.VContainer;

namespace SuikaLike
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] GameObject boxPrefab;
        [SerializeField] GameObject suikaPrefab;
        [SerializeField] GameObject mouseObserverPrefab;
        [SerializeField] GameObject suikaViewPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(GameLifetimeScope)}#{GetHashCode():x8}#Configure");
            Assert.IsNotNull(boxPrefab);
            Assert.IsNotNull(boxPrefab);
            Assert.IsNotNull(mouseObserverPrefab);
            Assert.IsNotNull(suikaViewPrefab);
            var mainCamera = Camera.main;
            Assert.IsNotNull(mainCamera);
            var canvas = Object.FindAnyObjectByType<Canvas>();
            Assert.IsNotNull(canvas);

            builder.RegisterVitalRouter(routing =>
            {
                routing.Map<SuikaSpawnPresenter>();
                routing.Map<SuikaCollisionPresenter>().AsSelf().AsImplementedInterfaces();
                routing.Map<SuikaScorePresenter>();
            });

            var box = Object.Instantiate(boxPrefab, transform);
            builder.RegisterInstance(new GameEntryPointParameter
            {
                MainCamera = mainCamera,
                SuikaPrefab = suikaPrefab,
                MouseObserverPrefab = mouseObserverPrefab,
                BoxTransform = box.transform,
            });

            var view = Object.Instantiate(suikaViewPrefab, canvas.transform);
            builder.RegisterInstance<ISuikaViewRenderer>(view.GetComponentInChildren<SuikaView>());

            builder.Register<IPointerCommandPublisher, SuikaController>(Lifetime.Scoped);
            builder.Register<ISuikaFactory, SuikaFactory>(Lifetime.Scoped);
            builder.Register<SuikaContainer>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();

            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
