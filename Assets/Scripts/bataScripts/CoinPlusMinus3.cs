using System.Collections;
using System.Collections.Generic;
//using Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinPlusMinus3 : MonoBehaviour {
    public static Text syouhinText_g;
    public Text text;
    public int num = 0;

    void Start () {
        text = text.GetComponent<Text> ();
        syouhinText_g = text;
    }

    public void OnClickPlus () {
        if (num < 12) {
            num += 1;
        }
        text.text = num.ToString ();
        Debug.Log ("プラス"); // ログを出力
    }

    public void OnClickMinus () {
        if (num > 0) {
            num -= 1;
        }
        text.text = num.ToString ();
        Debug.Log ("マイナス"); // ログを出力
    }
}