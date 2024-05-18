using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.LifetimeScopes
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] GameObject boxPrefab;
        [SerializeField] GameObject suikaPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(GameLifetimeScope)}#{GetHashCode():x8}#Configure");
            Assert.IsNotNull(boxPrefab);
            Assert.IsNotNull(suikaPrefab);
        }
    }
}
