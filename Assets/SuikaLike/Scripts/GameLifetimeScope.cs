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

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(GameLifetimeScope)}#{GetHashCode():x8}#Configure");
            Assert.IsNotNull(boxPrefab);
            Assert.IsNotNull(boxPrefab);
            Assert.IsNotNull(mouseObserverPrefab);
            var mainCamera = Camera.main;
            Assert.IsNotNull(mainCamera);

            builder.RegisterVitalRouter(routing =>
            {
                routing.Map<SuikaSpawnPresenter>();
            });

            var box = Container.Instantiate(boxPrefab, transform);
            builder.RegisterInstance(new GameEntryPointParameter
            {
                MainCamera = mainCamera,
                SuikaPrefab = suikaPrefab,
                MouseObserverPrefab = mouseObserverPrefab,
                BoxTransform = box.transform,
            });

            builder.Register<IPointerCommandPublisher, SuikaController>(Lifetime.Scoped);

            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
