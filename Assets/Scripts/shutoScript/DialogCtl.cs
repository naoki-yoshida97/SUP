using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCtl : MonoBehaviour
{
    [SerializeField] private GameObject terget = default;
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

    public void tergetDialogDestroy()
    {
        GameObject obj = GameObject.Find ("EventBox");
        GameObject obj2 = GameObject.Find ("EventBox2");
        GameObject obj3 = GameObject.Find ("EventBox3");
        Destroy (obj);
        Destroy (obj2);
        Destroy (obj3);
        Destroy(terget);
    }
}
