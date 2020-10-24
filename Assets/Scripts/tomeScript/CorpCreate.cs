using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorpCreate : MonoBehaviour {
    static int pos_x = 320;
    static int pos_y = -30;
    static int num;
    public static List<string> corp_name_list = new List<string> ();
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown_delete; //Dropdownを格納する変数

    // 会社名配列
    string[] corpAry = new string[21] {
        "建築会社",             //0
        "ゲストハウス",         //1
        "コンビニ",             //2
        "ファミレス",           //3
        "カフェ",               //4
        "アパレル",             //5
        "インフルエンサー",       //6
        "農業",                 //7
        "保険代理店",            //8
        "薬局",                 //9
        "新電力会社",            //10
        "製薬会社",              //11
        "不動産",               //12
        "バイオマス",            //13
        "TV局",                 //14
        "WEB製作",              //15
        "ロボティクス",          //16
        "PGスクール",           //17
        "広告代理店",           //18
        "動画制作",             //19
        "IT企業"                //20
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

        //会社番号(0,1,2...)_その枚数
        corp_name_list.Add (name);
        corp_cnt[dropdown.value]++;

        // ドロップダウンに会社名を追加
        //dropdown_delete.options.Add (new Dropdown.OptionData { text = corpAry[dropdown.value] + corp_cnt[dropdown.value] });
        dropdown_delete.options.Add (new Dropdown.OptionData { text = corpAry[dropdown.value] });

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
        num--;
        //会社カードcorp_name_listの中身を全部削除
        for (int i = 0; i < corp_name_list.Count; i++) {
            GameObject obj = GameObject.Find (corp_name_list[i]);
            Destroy (obj);
        }
        corp_name_list.RemoveAt (dropdown_delete.value);
        dropdown_delete.options.RemoveAt (dropdown_delete.value);

        //削除したdropdown_delete.value以外のcorp_name_listを全部再生成
        pos_x = 320; //-320
        pos_y = -30; //150
        for (int i = 0; i < corp_name_list.Count; i++) {
            string[] arr = corp_name_list[i].Split ('_');

            // 器になるゲームオブジェクトを作成
            // 引数はオブジェクト名
            GameObject corp = new GameObject (corp_name_list[i]);

            // 作ったゲームオブジェクトをCanvasの子にする
            corp.transform.parent = GameObject.Find ("Canvas").transform;

            // 画像のアンカーポジションを追加
            corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_x, pos_y, 0);

            // 縮尺を変更
            corp.GetComponent<RectTransform> ().localScale = new Vector3 (0.6f, 0.6f, 0.6f);

            // スプライト画像追加
            corp.AddComponent<Image> ().sprite = Resources.Load<Sprite> (arr[0]);

            // アスペクト比を元画像と同じサイズにする
            corp.GetComponent<Image> ().preserveAspect = true;

            // 画像のwidthとhightを変更
            //corp.sizeDelta = new Vector2 (50.0f, 50.0f);
            pos_x = pos_x + 55;
            if ((num % 6) == 0) {
                pos_y = pos_y - 65;
                pos_x = 320;
            }
        }
    }

}