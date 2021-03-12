using System.Collections;
using System.Collections.Generic;
//using Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlusMinusButton : MonoBehaviour {
    public static Text techText_g;
    public Text text;
    public int num = 3;

    void Start () {
        text = text.GetComponent<Text> ();
        techText_g = text;
    }

    public void OnClickPlus () {
        if (num < 7) {
            num += 1;
        }
        text.text = num.ToString ();
        Debug.Log ("プラス"); // ログを出力
        Debug.Log (techText_g.text);
    }

    public void OnClickMinus () {
        if (num > 0) {
            num -= 1;
        }
        text.text = num.ToString ();
        Debug.Log ("マイナス"); // ログを出力
    }
}