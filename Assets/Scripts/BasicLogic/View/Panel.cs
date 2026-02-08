using UnityEngine;

public class Panel : MonoBehaviour
{
    public void Setup(Material texture)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = texture;
    }
}
