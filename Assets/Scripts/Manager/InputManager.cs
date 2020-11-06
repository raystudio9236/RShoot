using RFramework.Common.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private PlayerInput _playerInput;

        private float _horizontalValue;

        public float HorizontalValue => _horizontalValue;

        private float _verticalValue;

        public float VerticalValue => _verticalValue;

        protected override void OnInit()
        {
            base.OnInit();

            _playerInput = GetComponent<PlayerInput>();
            var currentActionMap = _playerInput.currentActionMap;
            currentActionMap["Horizontal"].performed += context => { _horizontalValue = context.ReadValue<float>(); };
            currentActionMap["Horizontal"].canceled += context => { _horizontalValue = 0f; };
            currentActionMap["Vertical"].performed += context => { _verticalValue = context.ReadValue<float>(); };
            currentActionMap["Vertical"].canceled += context => { _verticalValue = 0f; };
        }
    }
}