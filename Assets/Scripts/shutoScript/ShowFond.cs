using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFond : MonoBehaviour
{
     [SerializeField] private Canvas par = default;
        // 表示するダイアログ
        [SerializeField] private OK dial = default;
    public void ShowF()
    {
        GameObject SampleDia = Instantiate ((GameObject) Resources.Load ("KeisanDia-dev")) as GameObject;
        
       
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
