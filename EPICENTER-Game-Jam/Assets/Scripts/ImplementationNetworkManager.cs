using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityStandardAssets.Characters.FirstPerson;

public class ImplementationNetworkManager : NetworkManager {
    private int playerCount= 0;
    private FirstPersonController fpsController;
    [SerializeField] FirstPersonController fpsControllerPrefab;

    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("<color=green>ImplementationNetworkManager::</color>On Server start");
        playerCount = 0;
        
        FirstPersonController fpsController = FindObjectOfType<FirstPersonController>();
    }


    public override void OnServerConnect(NetworkConnection conn) {
        base.OnServerConnect(conn);
        Debug.Log("<color=green>ImplementationNetworkManager::</color> A client connected to the server: " + conn);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        //base.OnServerAddPlayer(conn, playerControllerId);
        var player = (GameObject)GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        ProxyPlayerController proxyPlayerController = player.GetComponent<ProxyPlayerController>();
        
        if (playerCount == 0) {
            Debug.Log("<color=green>ImplementationNetworkManager::</color>Player 1 connected. ID:" + playerControllerId);
            //Camera.main.enabled = false;
            //Destroy(Camera.main);

            proxyPlayerController.Init(FindObjectOfType<FirstPersonController>(), PlayerIdentity.kPlayerOne);

        } else if (playerCount == 1) {
            Debug.Log("<color=green>ImplementationNetworkManager::</color>Player 2 connected. ID:" + playerControllerId);
            //Camera.main.enabled = true;
            //fpsController.GetComponent<AudioSource>().enabled = false;
            //fpsController.GetComponentInChildren<AudioListener>().enabled = false;
            proxyPlayerController.Init(FindObjectOfType<FirstPersonController>(), PlayerIdentity.kPlayerTwo);
        }
        playerCount++;

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        Debug.Log("<color=green>ImplementationNetworkManager::</color>Client has requested to get his player added to the game");
    }
}
