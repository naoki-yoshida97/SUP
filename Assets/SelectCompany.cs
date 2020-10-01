using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCompany : MonoBehaviour
{
    private Text SumCom;
    private int income = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        // int a = 1;
        // int b = 2;
        // int c = a + b;
        // Debug.Log("text");
        // Debug.Log(c);
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    public void OnClick()
    {
        Debug.Log ("クリックされた");//push the button
        this.SumCom = GameObject.Find("sumcomp").GetComponent<Text>();
         // this.C_text = GameObject.Find("Text").GetComponent<Text>(); // textコンポーネントを取得
        SumCom.text = income.ToString() +" 万円"; // int型をstring型に変換
        income += 50; 
        
    }
}
