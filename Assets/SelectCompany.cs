using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCompany : MonoBehaviour
{
    private Text SumCom;
    public int income = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        this.SumCom = GameObject.Find("sumcomp").GetComponent<Text>();
        SumCom.text = income.ToString()+" 万円";

    }

    public void OnClick()
    {
        // Debug.Log ("クリックされた");//push the button
        income += 50;
        SumCom.text = income.ToString() +" 万円"; // int型をstring型に変換
         
    }
}
