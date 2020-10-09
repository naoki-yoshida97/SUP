using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toyodome_Script : MonoBehaviour {
    int pos_x = 320; //-320
    int pos_y = -30; //150
    int num;
    public static List<string> corp_name_list = new List<string> ();
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
    //同一企業カードの数表示用
    int[] corp_cnt = new int[21] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private GameObject corp; //会社を格納する変数
    //ボタンが押された場合、今回呼び出される関数
    public void CorpClickAdd () {
        num++;
        string name;
        // listにオブジェクト名を格納
        name = dropdown.value.ToString () + "_" + corp_cnt[dropdown.value];
        corp_name_list.Add (name);
        corp_cnt[dropdown.value]++;
        // ドロップダウンに会社名を追加
        dropdown_delete.options.Add (new Dropdown.OptionData { text = corpAry[dropdown.value] + corp_cnt[dropdown.value] });
        // 器になるゲームオブジェクトを作成
        // 引数はオブジェクト名
        GameObject corp = new GameObject (corp_name_list[corp_name_list.Count - 1]);
        // 作ったゲームオブジェクトをCanvasの子にする
        corp.transform.parent = GameObject.Find ("Canvas").transform;
        // 画像のアンカーポジションを追加
        corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_x, pos_y, 0);
        // 縮尺を変更
        corp.GetComponent<RectTransform> ().localScale = new Vector3 (0.6f, 0.6f, 0.6f);
        // スプライト画像追加
        corp.AddComponent<Image> ().sprite = Resources.Load<Sprite> (dropdown.value.ToString ());
        // アスペクト比を元画像と同じサイズにする
        corp.GetComponent<Image> ().preserveAspect = true;
        // 画像のwidthとhightを変更
        //corp.sizeDelta = new Vector2 (50.0f, 50.0f);
        pos_x = pos_x + 55;
        if (num == 6) {
            pos_y = pos_y - 65;
            pos_x = 320;
        }
        dropdown_delete.RefreshShownValue ();
    }

    public void CorpClickDelete () {
        GameObject obj = GameObject.Find (corp_name_list[dropdown_delete.value]);
        Destroy (obj);
        corp_name_list.RemoveAt (dropdown_delete.value);
        dropdown_delete.options.RemoveAt (dropdown_delete.value);

        //会社カードcorp_name_listの中身を全部削除

        //削除したdropdown_delete.value以外のcorp_name_listを全部再生成
    }

}