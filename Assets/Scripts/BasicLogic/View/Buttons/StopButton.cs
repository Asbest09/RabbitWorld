using System;
using Assets.Scripts.BasicLogic.Model;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.View.Buttons
{
    public class StopButton : MonoBehaviour
    {
        public event Action Close;

        private PlayerModel _playerModel;

        public void Init(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void OnClick()
        {
            _playerModel.MoveToStart();
            Close?.Invoke();
        }
    }
}