using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityStandardAssets.Characters.FirstPerson;

public class ImplementationNetworkManager : NetworkManager {
    private int playerCount= 0;

    public override void OnStartServer() {
        base.OnStartServer();
        playerCount = 0;
    }


    public override void OnServerConnect(NetworkConnection conn) {
        base.OnServerConnect(conn);
        Debug.Log("<color=green>ImplementationNetworkManager::</color> A client connected to the server: " + conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        //base.OnServerAddPlayer(conn, playerControllerId);
        var player = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        FirstPersonController fpsController = player.GetComponent<FirstPersonController>();
        if (playerCount == 0) {
            Camera.main.enabled = false;
            //Destroy(Camera.main);
        } else if (playerCount == 1) { 
            // TODO: Destroy audio
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        Debug.Log("<color=green>ImplementationNetworkManager::</color>Client has requested to get his player added to the game");
    }
}
