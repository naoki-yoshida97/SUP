using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour
{
    public enum DialogResult
    {
        OK,
        Cancel,
    }
     // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }

     public void OnOk()
    {
        this.FixDialog?.Invoke(DialogResult.OK);
        Destroy(this.gameObject);
    }
     // Cancelボタンが押されたとき
    public void OnCancel()
    {
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
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
