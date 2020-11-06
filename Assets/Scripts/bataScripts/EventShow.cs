using UnityEngine;
using System;

public class EventShow : MonoBehaviour
{
    string var = "EventBox";
    public enum DialogResult
    {
        OK,
        Cancel,
        Retry,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }
    
    // OKボタンが押されたとき
    public void OnOk()
    {
        this.FixDialog?.Invoke(DialogResult.OK);
        Destroy(this.gameObject);
    }
    
    // Cancelボタンが押されたとき
    public void OnCancel()
    {
        Debug.Log("消された!");  // ログを出力
        GameObject obj = GameObject.Find (var);
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