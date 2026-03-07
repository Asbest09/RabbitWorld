using UnityEngine;

namespace Assets.Scripts.BasicLogic.View.Buttons
{
    public class NextLevelButton : MonoBehaviour
    {
        private LevelLoader _levelLoader;

        public void OnClick()
        {
            _levelLoader.LoadLevel(-1);
        }

        public void Init(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
    }
}