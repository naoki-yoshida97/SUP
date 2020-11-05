using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlusMinusButton2 : MonoBehaviour
{
    public Text text;
    public int num = 0;

    void Start(){
        text = text.GetComponent<Text> ();
    }

    public void OnClickPlus(){
        if(num < 7){
            num+=1;
        }
        text.text = num.ToString();
        Debug.Log("プラス");  // ログを出力
    }

    public void OnClickMinus(){
        if(num > 0){
            num-=1;
        }
        text.text = num.ToString();
        Debug.Log("マイナス");  // ログを出力
    }
}
