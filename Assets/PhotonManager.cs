using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    void ConnectPhoton () {
        PhotonNetwork.ConnectUsingSettings ("v1.0");
    }

    void OnJoinedLobby () {
        Debug.Log ("PhotonManager OnJoinedLobby");
    }

    // Update is called once per frame
    void Update () {

    }
}