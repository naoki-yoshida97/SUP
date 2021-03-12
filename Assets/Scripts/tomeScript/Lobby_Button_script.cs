using System.Collections;
using System.Collections.Generic;
//using Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby_Button_script : MonoBehaviour {
    public void OnClickRoom1Button () {
        //PhotonNetwork.JoinRoom("Room1");
        PhotonNetwork.CreateRoom("Room1", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
        Debug.Log("Room1作成&入室");
        SceneManager.LoadScene ("turn_manager");
        Application.LoadLevelAdditive ("conin&calcutor");
        Application.LoadLevelAdditive ("CorpCreate");
        Application.LoadLevelAdditive ("kannkyou_para");
        Application.LoadLevelAdditive ("CityBoard");
    }
}