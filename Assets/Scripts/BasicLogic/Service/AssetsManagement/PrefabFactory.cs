using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.Service.AssetsManagement
{
    internal class PrefabFactory<T> : IFactory<T, Transform, T>
        where T : UnityEngine.Object
    {
        private readonly IInstantiator _instantiator;

        public PrefabFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create(T prefab, Transform parent) =>
            _instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
    }
}
