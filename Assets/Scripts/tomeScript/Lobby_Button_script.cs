using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby_Button_script : MonoBehaviour {
    public void OnClickRoom1Button () {
        PhotonNetwork.JoinRoom ("Room1");

        SceneManager.LoadScene ("turn_manager");
        Application.LoadLevelAdditive ("conin&calcutor");
        Application.LoadLevelAdditive ("CorpCreate");
        Application.LoadLevelAdditive ("kannkyou_para");
        Application.LoadLevelAdditive ("CityBoard");
    }
}