using System;
using Codebase.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Codebase.Components.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public event Action OnMoving;
        public event Action OnJump;

        [SerializeField]
        private float _forwardSpeed = 5f;
        private float _maxXPosition = 6f;
        private float _minXPosition = -6f;

        private CharacterController _characterController;
        private float _currentXPosition;
        private DesktopInput _input = new();


        //[Inject]
        //private void Construct(IInputService inputService, PauseService pauseService)
        //{
        //    _input = inputService;
        //    _pause = pauseService;
        //}

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
 
        private void Update()
        {
            HandleMovement();
            MoveForward();
        }  

        private void HandleMovement()
        {
            if (_input.Left)
            {
                MoveLeft();
            }

            if (_input.Right)
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            if (_currentXPosition > _minXPosition)
            {
                _currentXPosition -= 3f;
                TeleportPlayer();
                OnMoving?.Invoke();
            }
        }

        private void MoveRight()
        {
            if (_currentXPosition < _maxXPosition)
            {
                _currentXPosition += 3f;
                TeleportPlayer();
                OnMoving?.Invoke();
            }
        }

        private void TeleportPlayer()
        {
            var targetPosition = new Vector3(_currentXPosition, transform.position.y, transform.position.z);
            var moveDirection = targetPosition - transform.position;

            _characterController.Move(moveDirection);
        }


        private void MoveForward()
        {
            Vector3 forwardMovement = Vector3.forward * (_forwardSpeed * Time.deltaTime); 
            _characterController.Move(forwardMovement); 
        }

    }
}
