using MirrorShooter.Camera;
using MirrorShooter.Input;
using MirrorShooter.Input.Direction;
using MirrorShooter.Network;

using UnityEngine;

namespace MirrorShooter
{
    class Game : MonoBehaviour
    {
        [SerializeField] private PlayerNetworking _playerNetworking;
        [SerializeField] private FPSCamera _fpsCamera;
        [SerializeField] private CursorLock _cursorLock;
        [SerializeField] private UI.ValueWithLimitView _healthView;

        private Player.Player _localPlayer;

        private void Awake()
        {
            _playerNetworking.Connected += OnConnected;
            _playerNetworking.OtherConnected += OnOtherConnected;
            _playerNetworking.Disconnected += OnDisconnected;
        }

        private void OnConnected(Player.Player player)
        {
            _localPlayer = player;

            _fpsCamera.Construct(new MouseDirectionInput(), player.transform);
            
            player.Construct(new TransformForwardDirectionInput(_fpsCamera.transform));
            _healthView.Construct(player.Health);
            _healthView.Show();

            _cursorLock.Enable();
        }
        private void OnOtherConnected(Player.Player otherPlayer)
        {
            otherPlayer.ConstructHealthWorldUIFor(_localPlayer.transform);
        }

        private void OnDisconnected()
        {
            _cursorLock.Disable();
            _healthView.Hide();
        }
    }
}