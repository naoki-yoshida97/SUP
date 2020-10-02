using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{   
    public Text goukei;
    GameObject sc;

    SelectCompany script;

    // Start is called before the first frame update
    void Start()
    {
        // goukei.text = "hogehoge";
        sc = GameObject.Find("sumcomp");
        script = sc.GetComponent<SelectCompany>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
