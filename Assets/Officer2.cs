using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Officer2 : MonoBehaviour
{   
    public int outcome = 0;
    private Text SumOut; 

    // Start is called before the first frame update
    void Start()
    {
        this.SumOut = GameObject.Find("sumout").GetComponent<Text>();
        SumOut.text = outcome.ToString()+" 万円";
    }

    public void OnClick(){
        Debug.Log ("クリックされた");//push the button
        outcome += 50;
        SumOut.text = outcome.ToString() +" 万円"; // int型をstring型に変換
    }
}
