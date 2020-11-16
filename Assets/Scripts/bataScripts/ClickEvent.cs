using UnityEngine;
using System;

public class ClickEvent : MonoBehaviour{

    string var = "EventView";
    public enum DialogResult
    {
        Cancel,
        Retry,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }
    
    // OKボタンが押されたとき
    public void OnCancel()
    {
        //Debug.Log("消された!");  // ログを出力
        GameObject obj = GameObject.Find(var);
        Destroy (obj);
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
    }
    
    public void Onbody()
    {
        this.FixDialog.Invoke(DialogResult.Retry);
    }
}