using System.Collections;
using System.Collections.Generic;
//using Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class calculator : MonoBehaviour {
    public static UnityEngine.UI.Text text_g;
    public UnityEngine.UI.Text text;
    public UnityEngine.UI.Text text2;
    public int x = 0;

    void Start () {
        text = text.GetComponent<Text> ();
        text2 = text2.GetComponent<Text> ();
        text_g = text;
    }

    public void OnClickCalculator () {
        int i;
        bool flg1 = int.TryParse (text.text, out i);
        bool flg2 = int.TryParse (text2.text, out i);
        if (flg1) {
            if (flg2) {
                int num1 = int.Parse (text.text);
                int num2 = int.Parse (text2.text);
                x = 0;
                x = num1 + num2;
                text.text = x.ToString ();
                Debug.Log ("計算終了");
            }
        } else {
            Debug.Log ("数字じゃないよ.");
        }
        //int num1 = int.Parse (text.text);
        //int num2 = int.Parse (text2.text);
        //x = 0;
        //x = num1 + num2;
        //text.text = x.ToString ();
        //Debug.Log ("計算終了");
    }
}