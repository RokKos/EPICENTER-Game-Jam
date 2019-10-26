using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class ImplementationNetworkManager : NetworkManager {
    public override void OnServerConnect(NetworkConnection conn) {
        base.OnServerConnect(conn);
        Debug.Log("<color=green>ImplementationNetworkManager::</color> A client connected to the server: " + conn);
    }
}
