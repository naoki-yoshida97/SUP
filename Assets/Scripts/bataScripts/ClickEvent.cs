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
    private string eventname;
    public void OnClick(){
        eventname = "EventView"+text.text;
        //Debug.Log("eventname:"+eventname);
        GameObject eventview = GameObject.Find(eventname);
        Destroy (eventview);
        int x = int.Parse(text.text);
        list.RemoveAt(x);
        Debug.Log("カード効果発動");
        GameObject obj = GameObject.Find(var);
        Destroy (obj);
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
    }

    private Text text;
    public void SelectEvent0(){
        this.text = GameObject.Find("TextE0").GetComponent<Text>();
        Debug.Log("text:"+text.text);
    }
    public void SelectEvent1(){
        this.text = GameObject.Find("TextE1").GetComponent<Text>();
        Debug.Log("text:"+text.text);
    }
    public void SelectEvent2(){
        this.text = GameObject.Find("TextE2").GetComponent<Text>();
        Debug.Log("text:"+text.text);
    }
    public void SelectEvent3(){
        this.text = GameObject.Find("TextE3").GetComponent<Text>();
        Debug.Log("text:"+text.text);
    }
}