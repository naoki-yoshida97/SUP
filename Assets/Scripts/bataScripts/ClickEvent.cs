using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour{

    string var = "EventView";
    List<int> list = EventOpen.list;

    public enum DialogResult{
        Cancel,
        Retry,
    }
    
    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; set; }

    
    // OKボタンが押されたとき
    public void OnCancel(){
        //Debug.Log("消された!");  // ログを出力
        GameObject obj = GameObject.Find(var);
        Destroy (obj);
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
    }
    
    public void Onbody(){
        this.FixDialog.Invoke(DialogResult.Retry);
    }
    
    public void OnClick(){
        GameObject eventview = GameObject.Find("EventView0");
        Destroy (eventview);
        list.RemoveAt(0);
        Debug.Log("カード効果発動");
    }
}