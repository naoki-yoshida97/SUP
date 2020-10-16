using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCompany : MonoBehaviour
{   
    //定義
    private Text SumCom;
    public int income = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        //ここでオブジェクトの指定と表記
        this.SumCom = GameObject.Find("sumcomp").GetComponent<Text>();
        SumCom.text = income.ToString()+" 万円";

    }

    public void OnClick()
    {
        //ボタンを押した時の処理
        income += 50;
        SumCom.text = income.ToString() +" 万円"; // int型をstring型に変換
         
    }
}
