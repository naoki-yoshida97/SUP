﻿using UnityEngine;
using System;

public class EventShow : MonoBehaviour
{
    string var = "EventBox";
    string var2 = "EventView";
    public enum DialogResult
    {
        Cancel2,
        Cancel,
        Retry,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }
    
    // OKボタンが押されたとき
    public void OnCancel2()
    {
        Debug.Log("消された!");  // ログを出力
        GameObject obj = GameObject.Find (var2);
        Destroy (obj);
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
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