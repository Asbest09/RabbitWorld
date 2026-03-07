using Assets.Scripts.BasicLogic.View.Cells;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.View.Buttons
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private CellParent _cellParent;

        public void OnClick()
        {
            _cellParent.ExecuteCommands();
        }
    }
}