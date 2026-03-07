using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.BasicLogic.View
{
    public class VictoryParent : MonoBehaviour
    {
        [SerializeField] private float _duration;

        public void Complete()
        {
            transform.DOScale(1, _duration);
        }

        public void Close()
        {
            transform.DOScale(0, _duration / 4);
        }
    }
}