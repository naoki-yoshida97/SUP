using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{   
    //オブジェクトに対しての設定
    public Text goukei;
    GameObject sc;
    GameObject of;

    //スクリプト名と使う関係
    SelectCompany script;
    Officer2 yakuin;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの検出と変数作成 
        sc = GameObject.Find("Button");
        of = GameObject.Find("Button2");
        
        //スクリプトの読み込みと代入
        script = sc.GetComponent<SelectCompany>();
        yakuin = of.GetComponent<Officer2>();

    }

    // Update is called once per frame
    void Update()
    {   
        //各スクリプトからのデータ参照
        int gg = 0;
        int addm = script.income;
        int offm = yakuin.outcome;
        gg = addm - offm;

        //結果の出力
        goukei.text = gg.ToString()+"万円";

    }
}
