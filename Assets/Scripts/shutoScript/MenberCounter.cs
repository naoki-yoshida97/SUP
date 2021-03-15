using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenberCounter : MonoBehaviour
{
    int i;
    int v;
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
       i = PhotonNetwork.countOfPlayers;
       v = PhotonNetwork.countOfPlayersInRooms;
       Debug.Log("接続している人数 :"+i);
       Debug.Log("ルームに入っている人数 :"+v);
    }
}
