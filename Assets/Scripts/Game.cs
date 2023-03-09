using MirrorShooter.Camera;
using MirrorShooter.Input;
using MirrorShooter.Input.Direction;
using MirrorShooter.Network;

using UnityEngine;

namespace MirrorShooter
{
    class Game : MonoBehaviour
    {
        [SerializeField] private MirrorNetwork _mirrorNetwork;
        [SerializeField] private FPSCamera _fpsCamera;
        [SerializeField] private CursorLock _cursorLock;

        private void Awake()
        {
            _mirrorNetwork.Connected += OnConnected;
            _mirrorNetwork.Disconnected += OnDisconnected;
        }

        private void OnConnected(Player.Player player)
        {
            _fpsCamera.Construct(new MouseDirectionInput(), player.transform);
            player.Construct(new LookTransformForwardDirectionInput(_fpsCamera.transform));
            
            _cursorLock.Enable();
        }

        private void OnDisconnected()
        {
            _cursorLock.Disable();
        }
    }
}