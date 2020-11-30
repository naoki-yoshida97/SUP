using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinPlusMinus2 : MonoBehaviour {
    public static Text kankyouText_g;
    public Text text;
    public int num = 0;

    void Start () {
        text = text.GetComponent<Text> ();
        kankyouText_g = text;
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