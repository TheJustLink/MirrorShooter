using Mirror;

using UnityEngine;

namespace MirrorShooter.Network
{
    class MirrorNetwork : NetworkManager
    {
        [SerializeField] private PlayerNetworking _playerNetworking;

        private bool _initialized;
        
        public override void Update()
        {
            base.Update();

            if (NetworkClient.isConnected == false || NetworkClient.localPlayer == null || _initialized) return;

            _initialized = true;

            var player = NetworkClient.localPlayer.GetComponent<Player.Player>();

            _playerNetworking.OnConnected(player);
        }
        
        public override void OnClientDisconnect()
        {
            _initialized = false;
            
            _playerNetworking.OnDisconnected();
        }
    }
}