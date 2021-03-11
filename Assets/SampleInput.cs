using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;



public class SampleInput : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public Text text;

  void Start () {
        //Componentを扱えるようにする
        PhotonNetwork.ConnectUsingSettings();
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text> ();
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick(){
        Debug.Log("押された!");  // ログを出力
        text.text = inputField.text;
        GameObject target_button = GameObject.Find ("ButtonStart");
        //Debug.Log ("target_button = " + target_button);
        //Button btn = GetComponent<target_button>(target_button);
        //btn.interactable = true;
        GameObject.Find("ButtonStart").GetComponent<Button>().interactable = true;
    }

    public void OnClickStartButton () {
        //PhotonNetwork.CreateRoom("Room1", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
        //Debug.Log("Room1作成");
        //PhotonNetwork.CreateRoom("Room2", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
        //Debug.Log("Room2作成");
        //PhotonNetwork.CreateRoom("Room3", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
        //Debug.Log("Room3作成");
        //PhotonNetwork.CreateRoom("Room4", new RoomOptions() { MaxPlayers = 5 }, TypedLobby.Default);
        //Debug.Log("Room4作成");
        SceneManager.LoadScene ("Lobby");

    }

}