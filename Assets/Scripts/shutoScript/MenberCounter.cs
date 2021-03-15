using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenberCounter : MonoBehaviour
{
    public void Awake(){
        
    }    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RoomInfo []roomInfo = PhotonNetwork.GetRoomList();
        if(roomInfo == null || roomInfo.Length == 0) return;

        for(int i=0; i<roomInfo.Length; i++){
            if(roomInfo[i].name=="RoomName"){
                Debug.Log((i).ToString() + ":" + roomInfo[i].name +"-"+roomInfo[i].PlayerCount);
            }
        }
    }
}
