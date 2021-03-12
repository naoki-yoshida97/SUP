using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


// MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする
public class SampleScene : Photon.PunBehaviour{

    //InputFieldを格納するための変数
    //InputField inputField;

    private void Start() {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings("v1.0");
        //InputFieldコンポーネントを取得
        ///inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
        //PhotonNetwork.JoinRoom("room");
    }



    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        //var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        //PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);
    }
}