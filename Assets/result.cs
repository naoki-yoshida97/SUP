using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{   
    public Text goukei;
    GameObject sc;
    GameObject of ;

    SelectCompany script;
    Officer2 yakuin;

    // Start is called before the first frame update
    void Start()
    {
        // goukei.text = "hogehoge"; 
        sc = GameObject.Find("Button");
        of = GameObject.Find("Button2");

        script = sc.GetComponent<SelectCompany>();
        yakuin = of.GetComponent<Officer2>();

    }

    // Update is called once per frame
    void Update()
    {   
        int gg = 0;
        int addm = script.income;
        int offm = yakuin.outcome;
        gg = addm - offm;

        goukei.text = gg.ToString()+"万円";

    }
}
