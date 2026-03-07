using UnityEngine;

namespace Assets.Scripts.BasicLogic.View
{
    public class Panel : MonoBehaviour
    {
        public void Setup(Material texture)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = texture;
        }
    }
}