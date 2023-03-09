using System;
using System.Security.Principal;

using Mirror;

using MirrorShooter.Camera;

using UnityEngine;

namespace MirrorShooter.Network
{
    class MirrorNetwork : NetworkManager
    {
        public event Action<Player.Player> Connected;
        public event Action Disconnected;

        private bool _initialized;
        
        public override void OnClientDisconnect()
        {
            _initialized = false;
            Disconnected?.Invoke();
        }

        public override void Update()
        {
            base.Update();

            if (NetworkClient.isConnected == false || NetworkClient.localPlayer == null || _initialized) return;

            _initialized = true;

            var player = NetworkClient.localPlayer.GetComponent<Player.Player>();
            Connected?.Invoke(player);
        }
    }
}