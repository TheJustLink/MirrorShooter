using MirrorShooter.Camera;
using MirrorShooter.Input.Direction;

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
            player.Construct();
            
            _fpsCamera.Construct(new MouseDirectionInput(), player.transform);
            _cursorLock.Enable();
        }
        private void OnDisconnected()
        {
            _cursorLock.Disable();
        }
    }
}