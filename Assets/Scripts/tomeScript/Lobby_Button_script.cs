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

        SceneManager.LoadScene ("CityBoard");
        Application.LoadLevelAdditive ("CorpCreate");
        Application.LoadLevelAdditive ("SampleScene");
        Application.LoadLevelAdditive ("kannkyou_para");
    }
}