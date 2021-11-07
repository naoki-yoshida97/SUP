using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCtl : MonoBehaviour
{
    //メニューダイアログの操作↓
    public void MenuDialogShow()
    {
        GameObject menuDialog = GameObject.Find("menuDialog");
        menuDialog.transform.localScale = new Vector3(1,1,1);
    }

    public void MenuDialogHide()
    {
        GameObject menuDialog = GameObject.Find("menuDialog");
        menuDialog.transform.localScale = new Vector3(0,0,0);
    }
    //--------------------------

    //起業ダイアログ操作
    public void CompanyDialogShow()
    {
        GameObject menuDialog = GameObject.Find("CompanyDialog");
        menuDialog.transform.localScale = new Vector3(1,1,1);
    }

    public void CompanyDialogHide()
    {
        GameObject menuDialog = GameObject.Find("CompanyDialog");
        menuDialog.transform.localScale = new Vector3(0,0,0);
    }

    //--------------------------


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
