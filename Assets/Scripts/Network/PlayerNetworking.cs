using System;
using System.Collections.Generic;

using Mirror;

namespace MirrorShooter.Network
{
    class PlayerNetworking : NetworkBehaviour
    {
        public event Action<Player.Player> Connected;
        public event Action<Player.Player> OtherConnected;
        public event Action Disconnected;

        public void OnConnected(Player.Player player)
        {
            Connected?.Invoke(player);

            CmdConnectedEvent(player);
        }
        public void OnDisconnected()
        {
            Disconnected?.Invoke();
        }
        

        [Command(requiresAuthority = false)]
        private void CmdConnectedEvent(Player.Player player)
        {
            var otherPlayers = new List<Player.Player>(NetworkServer.connections.Count - 1);

            foreach (var connection in NetworkServer.connections.Values)
            {
                if (connection.identity == null) continue;
                if (connection.identity == player.netIdentity) continue;

                otherPlayers.Add(connection.identity.GetComponent<Player.Player>());
            }

            RpcShareConnectedEvent(player, otherPlayers);
        }
        [ClientRpc, Client]
        private void RpcShareConnectedEvent(Player.Player player, List<Player.Player> otherPlayers)
        {
            var localIdentity = NetworkClient.localPlayer;
            
            if (localIdentity == null) return;

            if (localIdentity == player.netIdentity)
            {
                foreach (var otherPlayer in otherPlayers)
                    OtherConnected?.Invoke(otherPlayer);
            }
            else
            {
                OtherConnected?.Invoke(player);
            }
        }
    }
}