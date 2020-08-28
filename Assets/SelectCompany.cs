using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCompany : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 1;
        int b = 2;
        int c = a + b;
        Debug.Log("text");
        Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Debug.Log ("クリックされた");
    }
}
