using Assets.Scripts.BasicLogic.Model;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.View.Cells
{
    public class Cell : MonoBehaviour
    {
        public Command SelfCommand { get; private set; }       

        private UIElement _uIElement;
        private int _countRepeats = 2;

        public void SetCommand(Command command, UIElement uIElement)
        {
            SelfCommand = command;

            if (_uIElement != null)
                Destroy(_uIElement.gameObject);

            _uIElement = uIElement;
        }

        public void DeleteElement()
        {
            _uIElement = null;
            SelfCommand = null;
        }

        public void SetCountRepeats(int count) =>
            _countRepeats = count;

        public int GetCountRepeats() =>
            _countRepeats;
    }
}