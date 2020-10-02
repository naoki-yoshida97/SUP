using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toyodome_Script : MonoBehaviour {
    int pos_x = -200; //-320
    int pos_y = 80; //150
    int num;
    List<string> corp_name = new List<string> ();
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown_delete; //Dropdownを格納する変数

    // 会社名配列
    string[] corpAry = new string[21] {
        "建築会社",
        "ゲストハウス",
        "コンビニ",
        "ファミレス",
        "カフェ",
        "アパレル",
        "インフルエンサー",
        "農業",
        "保険代理店",
        "薬局",
        "新電力会社",
        "製薬会社",
        "不動産",
        "バイオマス",
        "TV局",
        "WEB製作",
        "ロボティクス",
        "PGスクール",
        "広告代理店",
        "動画制作",
        "IT企業"
    };

    private GameObject corp; //会社を格納する変数
    //ボタンが押された場合、今回呼び出される関数
    public void OnClickAdd () {
        num++;
        Debug.Log ("Add"); //ログを出力
        string corp_num = dropdown.value.ToString ();
        // listにオブジェクト名を格納
        corp_name.Add (corp_num);
        // ドロップダウンに会社名を追加
        //        dropdown_delete.options.Add (new Dropdown.OptionData { text = "item" });
        // 器になるゲームオブジェクトを作成
        // 引数はオブジェクト名
        GameObject corp = new GameObject (corp_name[corp_name.Count - 1]);
        // 作ったゲームオブジェクトをCanvasの子にする
        corp.transform.parent = GameObject.Find ("Canvas").transform;
        // 画像のアンカーポジションを追加して画面の真ん中に
        corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_x, pos_y, 0);
        // 縮尺を糖倍にする
        corp.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
        // スプライト画像追加
        corp.AddComponent<Image> ().sprite = Resources.Load<Sprite> (corp_num);
        // アスペクト比を元画像と同じサイズにする
        corp.GetComponent<Image> ().preserveAspect = true;
        // 画像のwidthとhightを変更
        //corp.sizeDelta = new Vector2 (50.0f, 50.0f);
        pos_x = pos_x + 80;
        if (num == 5) {
            pos_y = pos_y - 120;
            pos_x = -200;
        }
        //        dropdown_delete.RefreshShownValue ();
    }

}