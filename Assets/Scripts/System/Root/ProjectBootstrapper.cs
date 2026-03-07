using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.System.Root
{
    public class ProjectBootstrapper : MonoBehaviour
    {
        private void Awake()
        { 
            DOTween.Init(true, false);
        }
    }
}