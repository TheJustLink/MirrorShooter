using MirrorShooter.Camera;
using MirrorShooter.Input.Direction;

using UnityEngine;

namespace MirrorShooter
{
    class Game : MonoBehaviour
    {
        [SerializeField] private FPSCamera _fpsCamera;
        [SerializeField] private Player.Player _player;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _player.Construct();
            _fpsCamera.Construct(new MouseDirectionInput(), _player.transform);
        }
    }
}