using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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
        Debug.Log("押された!");  // ログを出力
        text.text = inputField.text;
        GameObject target_button = GameObject.Find ("ButtonStart");
        //Debug.Log ("target_button = " + target_button);
        //Button btn = GetComponent<target_button>(target_button);
        //btn.interactable = true;
        GameObject.Find("ButtonStart").GetComponent<Button>().interactable = true;
    }

    public void OnClickStartButton () {
        SceneManager.LoadScene ("Lobby");
    }

}