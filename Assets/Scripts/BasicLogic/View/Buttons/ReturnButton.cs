using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.BasicLogic.View.Buttons
{
    public class ReturnButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}