using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class ProxyPlayerController : NetworkBehaviour
{
    public PlayerIdentity playerIdentity = PlayerIdentity.kNone;
    private FirstPersonController firstPersonController = null;

    public void Init(FirstPersonController _firstPersonController, PlayerIdentity _playerIdentity) {
        firstPersonController = _firstPersonController;
        playerIdentity = _playerIdentity;
    }

    // Update is called once per frame
    private void Update() {
        if (!isLocalPlayer) {
            firstPersonController.Update_(playerIdentity);
        }
    }

    private void FixedUpdate() {
        if (!isLocalPlayer) {
            firstPersonController.FixedUpdate_(playerIdentity);
        }
    }
}
