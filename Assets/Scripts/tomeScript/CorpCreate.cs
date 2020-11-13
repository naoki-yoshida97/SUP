using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorpCreate : MonoBehaviour {
    static int pos_x = 320;
    static int pos_y = -30;
    static int num;
    public int income = 0;
    private Text SumCom;
    static string[] c;
    
    // drop down 
    public static List<string> corp_name_list = new List<string> ();
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown_delete; //Dropdownを格納する変数
    //drop down

    //あとで
    // int zzuuuuu = 3;
 
    // Start is called before the first frame update
    void Start()
    {
        //ここでオブジェクトの指定と表記
        //増える方
        this.SumCom = GameObject.Find("sumcomp").GetComponent<Text>();
        SumCom.text = income.ToString()+" 万円";
        
    }
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

    //収入配列
    int[,] zero　=new int[,]{{1000,4600},{1300,5600},{1600,6600},{2000,7600},{2400,8600}};//建築会社
    int[,] one　=new int[,]{{1100,4800},{1500,5800},{1800,6800},{2200,7800},{2700,8800}};//ゲストハウス
    int[,] two　=new int[,]{{600,4000},{800,5000},{1000,6000},{1200,7000},{1500,8000}};//コンビニ
    int[,] three　=new int[,]{{800,4200},{1000,5200},{1200,6200},{1500,7200},{1800,8200}};//ファミレス
    int[,] four　=new int[,]{{900,4500},{1200,5500},{1500,6500},{1800,7500},{2300,8500}};//カフェ
    int[,] five　=new int[,]{{1500,5500},{2000,6500},{2500,7500},{3000,8500},{3800,9500}};//アパレル
    int[,] six　=new int[,]{{1400,5200},{1800,6200},{2200,7200},{2700,8200},{3300,9200}};//インフルエンサー
    int[,] seven　=new int[,]{{1000,4600},{1300,5600},{1600,6600},{2000,7600},{2400,8600}};//農業
    int[,] eight　=new int[,]{{800,4200},{1000,5200},{1200,6200},{1500,7200},{1800,8200}};//保険代理店
    int[,] nine　=new int[,]{{900,4500},{1200,5500},{1500,6500},{1800,7500},{2300,8500}};//薬局
    int[,] ten =new int[,]{{1400,5200},{1300,5600},{1600,6600},{2000,7600},{2400,8600}};//新電力会社
    int[,] eleven =new int[,]{{1500,5500},{2000,6500},{2500,7500},{3000,8500},{3800,9500}};//製薬会社
    int[,] twelve =new int[,]{{600,4000},{800,5000},{1000,6000},{1200,7000},{1500,8000}};//不動産
    int[,] thirteen =new int[,]{{1100,4800},{1500,5800},{1800,6800},{2200,7800},{2700,8800}};//バイオマス
    int[,] fourteen =new int[,]{{1000,4600},{1300,5600},{1600,6600},{2000,7600},{2400,8600}};//TV局
    int[,] fivteen =new int[,]{{900,4500},{1200,5500},{1500,6500},{1800,7500},{2300,8500}};//WEB制作
    int[,] sixteen =new int[,]{{1500,5500},{2000,6500},{2500,7500},{3000,8500},{3800,9500}};//ロボティクス
    int[,] seventeen =new int[,]{{700,4100},{900,5100},{1100,6100},{1400,7100},{1700,8100}};//PGスクール
    int[,] eighteen =new int[,]{{1400,5200},{1800,6200},{2200,7200},{2700,8200},{3300,9200}};//広告代理店
    int[,] nineteen =new int[,]{{1100,4800},{1500,5800},{1800,6800},{2200,7800},{2700,8800}};//動画制作
    int[,] twenty =new int[,]{{800,4200},{1000,5200},{1200,6200},{1500,7200},{1800,8200}};//IT企業

    private GameObject corp; //会社を格納する変数

    //ボタンが押された場合、今回呼び出される関数
    public void CorpClickAdd () {
        if (num == 12) {
            Debug.Log ("CorpCreate: これ以上生成できません");
        } else {
            num++;
            string name;
            
            
            //呼び出された番号を元に引っ張っってくる
            

            //delete drop down~~~~~~
            // listにオブジェクト名を格納 num_cnt
            name = dropdown.value.ToString () + "_" + corp_cnt[dropdown.value];

            //会社番号(0,1,2...)_その枚数
            corp_name_list.Add (name);
            corp_cnt[dropdown.value]++;
            Debug.Log(num-1);
            c = corp_name_list[num-1].Split('_');
            //moziretuwosansyounisurumonowotukeru
            Debug.Log(c[num-1]);

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

            // 画像のwidthとhightを変更
            //corp.sizeDelta = new Vector2 (50.0f, 50.0f);
            pos_x = pos_x + 55;
            if (num == 6) {
                pos_y = pos_y - 65;
                pos_x = 320;
            }
            dropdown_delete.RefreshShownValue ();

            income += 50;
            SumCom.text = income.ToString() +" 万円"; // int型をstring型に変換
        }
    }

    //削除---------------------------------------------------------------------------------------
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
    // ------------------------------------------------------------------------------------
}