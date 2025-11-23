using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
