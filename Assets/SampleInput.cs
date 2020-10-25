using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleInput : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;
  public Text text;

  void Start () {
        //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text> ();
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick(){
        ///Debug.Log("押された!");  // ログを出力
        text.text = inputField.text;
    }

    public void InputText(){
        //テキストにinputFieldの内容を反映
        ///text.text = inputField.text;
    }

}