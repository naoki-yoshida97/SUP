using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenberCounter : MonoBehaviour
{
    int i;
    int v;
    int r;
    int u;
    public void Awake(){
        
    }    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1");
    }

    // Update is called once per frame
    void Update()
    {
       r = PhotonNetwork.countOfRooms;
       u = PhotonNetwork.countOfPlayersOnMaster;
       i = PhotonNetwork.countOfPlayers;
       v = PhotonNetwork.countOfPlayersInRooms;
       Debug.Log("稼働しているルーム数 :"+r);
       Debug.Log("ルームに参加していないプレイヤー数 :"+u);
       Debug.Log("接続している人数 :"+i);
       Debug.Log("ルームに入っている人数 :"+v);
    }
}
