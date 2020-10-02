using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toyodome_Script : MonoBehaviour {
    int pos_x = -320;
    int pos_y = 150;
    int num = -1;
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    private GameObject corp; //会社を格納する変数
    //ボタンが押された場合、今回呼び出される関数
    public void OnClickAdd () {
        string corp_name = "";
        num++;
        Debug.Log ("Add"); //ログを出力
        // 器になるゲームオブジェクトを作成
        // 引数はオブジェクト名
        corp_name = "corp_" + dropdown.value;
        GameObject corp = new GameObject (corp_name);
        // 作ったゲームオブジェクトをCanvasの子にする
        corp.transform.parent = GameObject.Find ("Canvas").transform;
        // 画像のアンカーポジションを追加して画面の真ん中に
        corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_x, pos_y, 0);
        // 縮尺を糖倍にする
        corp.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
        // スプライト画像追加
        string corp_num = dropdown.value.ToString ("00");
        corp.AddComponent<Image> ().sprite = Resources.Load<Sprite> (corp_num);
        // アスペクト比を元画像と同じサイズにする
        corp.GetComponent<Image> ().preserveAspect = true;
        // 画像のwidthとhightを変更
        //corp.sizeDelta = new Vector2 (50.0f, 50.0f);
        pos_x = pos_x + 80;
        if (num == 8) {
            pos_y = pos_y - 120;
            pos_x = -320;
        }
    }
    /*
        public void OnClickDelete()
        {   
            Debug.Log("Delete");
            string name = inputField1.text;

    	    GameObject obj = GameObject.Find (name);
    	    Destroy(obj);
        }   

        //InputFieldを格納するための変数
        InputField inputField1;
        InputField inputField2; 
        // Start is called before the first frame update
        void Start()
        {
            //InputFieldコンポーネントを取得
            inputField1 = GameObject.Find("InputField1").GetComponent<InputField>();
            inputField2 = GameObject.Find("InputField2").GetComponent<InputField>();
        }
     
        //入力された名前情報を読み取ってコンソールに出力する関数
    */
}