using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.LifetimeScopes
{
    public class TitleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(TitleLifetimeScope)}#{GetHashCode():x8}#Configure");
        }
    }
}
