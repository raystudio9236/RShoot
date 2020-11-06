using Entitas;
using Manager;
using UnityEngine;

namespace Systems.Input
{
    public class InputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            var mouse = UnityEngine.InputSystem.Mouse.current;
            var playerInputEntity = _contexts.input.CreateEntity();
            playerInputEntity.AddInputComp(new Vector2(
                    InputManager.Instance.HorizontalValue,
                    InputManager.Instance.VerticalValue
                ),
                mouse.position.ReadValue(),
                mouse.leftButton.wasPressedThisFrame,
                mouse.leftButton.isPressed,
                mouse.rightButton.wasPressedThisFrame,
                mouse.rightButton.isPressed);
        }
    }
}