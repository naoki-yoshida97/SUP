using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CorpCreate : MonoBehaviour {
    static int pos_x = 320;
    static int pos_y = 15;
    static int pos_x_toggle = 680;
    static int pos_y_toggle = 240;
    static int num = 0;

    // drop down 
    public static List<string> corp_name_list = new List<string> ();
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown_delete; //Dropdownを格納する変数
    //drop down

    // 会社名配列
    string[] corpAry = new string[21] {
        "建築会社", //0
        "ゲストハウス", //1
        "コンビニ", //2
        "ファミレス", //3
        "カフェ", //4
        "アパレル", //5
        "インフルエンサー", //6
        "農業", //7
        "保険代理店", //8
        "薬局", //9
        "新電力会社", //10
        "製薬会社", //11
        "不動産", //12
        "バイオマス", //13
        "TV局", //14
        "WEB製作", //15
        "ロボティクス", //16
        "PGスクール", //17
        "広告代理店", //18
        "動画制作", //19
        "IT企業" //20
    };
    //同一企業カードの数表示用
    int[] corp_cnt = new int[21] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private GameObject corp; //会社を格納する変数

    //ボタンが押された場合、今回呼び出される関数
    public void CorpClickAdd () {
        if (num == 12) {
            Debug.Log ("CorpCreate: これ以上生成できません");
        } else {
            num++;
            string name;

            //delete drop down~~~~~~
            // listにオブジェクト名を格納 num_cnt
            name = dropdown.value.ToString () + "_" + corp_cnt[dropdown.value];

            //会社番号(0,1,2...)_その枚数
            corp_name_list.Add (name);
            corp_cnt[dropdown.value]++;

            // ドロップダウンに会社名を追加
            //dropdown_delete.options.Add (new Dropdown.OptionData { text = corpAry[dropdown.value] + corp_cnt[dropdown.value] });
            dropdown_delete.options.Add (new Dropdown.OptionData { text = corpAry[dropdown.value] });
            //~~~~dellete drop down

            //add column
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

            // 上場/非上場選択の為のToggle作成
            //GameObject prefab = (GameObject) Resources.Load ("ToggleGroup");
            //GameObject gameObj = Instantiate (prefab) as GameObject;
            //GameObject cloneObject = Instantiate (gameObj, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
            GameObject Toggle = Instantiate ((GameObject) Resources.Load ("ToggleGroup")) as GameObject;
            Toggle.transform.parent = GameObject.Find ("Canvas").transform;
            // ToggleGroupの位置変更
            Toggle.transform.position = new Vector3 (pos_x_toggle, pos_y_toggle, 0);
            // ToggleGroupのrename
            Toggle.name = "ToggleGroup_" + num;

            pos_x = pos_x + 55;
            pos_x_toggle = pos_x_toggle + 40;
            if (num == 6) {
                pos_y = pos_y - 87;
                pos_x = 320;

                pos_y_toggle = pos_y_toggle - 62;
                pos_x_toggle = 680;
            }
            dropdown_delete.RefreshShownValue ();

        }
    }

    //削除---------------------------------------------------------------------------------------
    public void CorpClickDelete () {
        if (num < 1) {;
        } else {
            num--;
            //会社カードcorp_name_listの中身を全部削除
            for (int i = 0; i < corp_name_list.Count; i++) {
                GameObject obj = GameObject.Find (corp_name_list[i]);
                Destroy (obj);
            }
            for (int i = 1; i < corp_name_list.Count + 1; i++) {
                GameObject obj = GameObject.Find ("ToggleGroup_" + i);
                Destroy (obj);
            }
            corp_name_list.RemoveAt (dropdown_delete.value);
            dropdown_delete.options.RemoveAt (dropdown_delete.value);

            //削除したdropdown_delete.value以外のcorp_name_listを全部再生成
            pos_x = 320; //-320
            pos_y = 15; //150
            pos_x_toggle = 680;
            pos_y_toggle = 240;
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

                GameObject Toggle = Instantiate ((GameObject) Resources.Load ("ToggleGroup")) as GameObject;
                Toggle.transform.parent = GameObject.Find ("Canvas").transform;
                // ToggleGroupの位置変更
                Toggle.transform.position = new Vector3 (pos_x_toggle, pos_y_toggle, 0);
                // ToggleGroupのrename
                Toggle.name = "ToggleGroup_" + (i + 1);

                pos_x = pos_x + 55;
                pos_x_toggle = pos_x_toggle + 40;
                if (i == 5) {
                    pos_y = pos_y - 87;
                    pos_x = 320;

                    pos_y_toggle = pos_y_toggle - 62;
                    pos_x_toggle = 680;
                }
            }
        }
    }

    //以下Toggleの処理と未上場 or 上場のFlg---------------------------------------------------------------------------
    private Toggle toggle1;
    private ToggleGroup toggleGroup1;

    public static int[] Listed_flg = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    //未上場にチェックされたとき
    public void onClick_Nonlisted () {
        //Debug.Log ("Nonlisted: " + num);
        // 親のオブジェクト名を取得
        GameObject parent = this.transform.parent.gameObject;

        // ToggleGroup_XのXを切り出し
        string str = parent.name;
        string[] arr = str.Split ('_');

        // nはListed_flgの要素番号
        int n;
        n = Convert.ToInt32 (arr[1]);

        // nの要素番号のListed_flgを0に
        Listed_flg[n] = 0;
        Debug.Log ("Nonlisted! : " + str + ": 0: " + Listed_flg[n]);
    }

    //上場にチェックされたとき
    public void onClick_Listed () {
        //Debug.Log ("Nonlisted: " + num);
        // 親のオブジェクト名を取得
        GameObject parent = this.transform.parent.gameObject;

        // ToggleGroup_XのXを切り出し
        string str = parent.name;
        string[] arr = str.Split ('_');

        // nはListed_flgの要素番号
        int n;
        n = Convert.ToInt32 (arr[1]);

        // nの要素番号のListed_flgを1に
        Listed_flg[n] = 1;

        Debug.Log ("Listed! : " + str + ": 1: " + Listed_flg[n]);

    }

}