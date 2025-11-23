using UnityEngine;
using DG.Tweening;

public class GameBootsrapper : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init(true, false);
    }
}