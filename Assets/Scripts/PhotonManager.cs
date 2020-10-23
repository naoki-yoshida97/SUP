using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour {
    static int num = 0;

    public void ConnectPhoton () {
        PhotonNetwork.ConnectUsingSettings ("v1.0");
    }

    void OnJoinedLobby () {
        Debug.Log ("PhotonManager OnjoinedLobby");
        //ボタンを押せるようにする
        GameObject.Find ("CreateRoomB").GetComponent<Button> ().interactable = true;
    }

    void OnReceivedRoomListUpdate () {
        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList ();
        if (rooms.Length == 0) {
            Debug.Log ("ルームが一つもありません");
        } else {
            //ルームが1件以上ある時ループでRoomInfo情報をログ出力
            for (int i = 0; i < rooms.Length; i++) {
                Debug.Log ("RoomName:" + rooms[i].Name);
                Debug.Log ("userName:" + rooms[i].CustomProperties["userName"]);
                Debug.Log ("userId:" + rooms[i].CustomProperties["userId"]);
                GameObject.Find ("StatusText").GetComponent<Text> ().text = rooms[i].Name;
            }
        }
    }

    public void CreateRoom () {
        num++;
        string userName = "ユーザ" + num;
        string userId = "user";
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable ();
        customProp.Add ("userName", userName); //ユーザ名
        customProp.Add ("userId", userId); //ユーザID
        PhotonNetwork.SetPlayerCustomProperties (customProp);

        RoomOptions roomOptions = new RoomOptions ();
        roomOptions.CustomRoomProperties = customProp;
        //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "userName", "userId" };
        roomOptions.MaxPlayers = 2; //部屋の最大人数
        roomOptions.IsOpen = true; //入室許可する
        roomOptions.IsVisible = true; //ロビーから見えるようにする
        //userIdが名前のルームがなければ作って入室、あれば普通に入室する。
        PhotonNetwork.JoinOrCreateRoom (userId, roomOptions, null);

        GameObject.Find ("JoinRoom").GetComponent<Button> ().interactable = true;
    }

    public void JoinRoom () {
        PhotonNetwork.JoinRoom ("user" + num);
    }

    void OnJoinedRoom () {
        Debug.Log ("PhotonManager OnJoinedRoom");
        GameObject.Find ("StatusText").GetComponent<Text> ().text = "OnJoinedRoom";
    }
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}