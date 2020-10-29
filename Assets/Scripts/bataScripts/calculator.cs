using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class calculator : MonoBehaviour{
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Text text2;
    public int x = 0;

    void Start(){
        text = text.GetComponent<Text> ();
        text2 = text2.GetComponent<Text> ();
    }

    public void OnClickCalculator(){
        int num1 = int.Parse(text.text);
        int num2 = int.Parse(text2.text);
        x = num1 + num2;
        text.text = x.ToString();
        Debug.Log("計算終了"); 
    }
}
