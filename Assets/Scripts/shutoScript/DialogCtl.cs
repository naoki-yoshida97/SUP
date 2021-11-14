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
        int[] src = new int[7]{ 0,1, 2, 3, 4, 5, 6};
        foreach(int inte in src) {
            GameObject obj = GameObject.Find("EventBox"+$"{inte}");
            Destroy(obj);
        }
        Destroy(terget);
    }
}
