using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.LifetimeScopes
{
    public class RootLifetimeScope : LifetimeScope, IApplicationStateDispatcher
    {
        [SerializeField] StartupLifetimeScope startupLifetimeScope;
        [SerializeField] TitleLifetimeScope titleLifetimeScope;
        [SerializeField] GameLifetimeScope gameLifetimeScope;

        LifetimeScope? _currentLifetimeScope;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(RootLifetimeScope)}#{GetHashCode():x8}#Configure");
            Assert.IsNotNull(startupLifetimeScope);
            Assert.IsNotNull(titleLifetimeScope);
            Assert.IsNotNull(gameLifetimeScope);

            builder.RegisterInstance<IApplicationStateDispatcher>(this);

            // startupから始まる
            ((IApplicationStateDispatcher)this).Dispatch(ApplicationState.Startup);
        }

        void IApplicationStateDispatcher.Dispatch(ApplicationState state)
        {
            var nextLifetimeScope = state switch
            {
                ApplicationState.Startup => startupLifetimeScope,
                ApplicationState.Title => titleLifetimeScope,
                ApplicationState.Game => gameLifetimeScope,
                _ => default(LifetimeScope),
            };
            Assert.IsNotNull(nextLifetimeScope);

            if (_currentLifetimeScope != null)
            {
                _currentLifetimeScope.Dispose();
            }

            var nextLifetimeScopeObject = Instantiate(nextLifetimeScope);
            nextLifetimeScopeObject.parentReference.Object = this;
            _currentLifetimeScope = nextLifetimeScopeObject;
        }
    }
}
