using DG.Tweening;
using UnityEngine;

public class ProjectBootstrapper : MonoBehaviour
{
    private void Awake()
    {

        DOTween.Init(true, false);
    }
}
