using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelupdown : MonoBehaviour{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;

    void Start(){

    }

    public void OnClick_PanelOff(){
        Panel1.SetActive(false);
        Panel2.SetActive(false);
    }

    public void OnClick_PanelOn(){
        Panel1.SetActive(true);
        Panel2.SetActive(true);
    }

}
