using System;

using Mirror;

namespace MirrorShooter
{
    class MirrorNetwork : NetworkManager
    {
        public event Action<Player.Player> Connected;
        public event Action Disconnected;

        public override void Awake()
        {
            NetworkClient.PlayerAdded += OnPlayerAdded;
        }
        
        private void OnPlayerAdded(NetworkIdentity identity)
        {
            if (identity.isLocalPlayer == false) return;

            Connected?.Invoke(identity.GetComponent<Player.Player>());
        }
        public override void OnClientDisconnect()
        {
            Disconnected?.Invoke();
        }
    }
}