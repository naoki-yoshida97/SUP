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

    void Update(){
        if(list.Count >= 1){
            GameObject.Find("SelectEvent0").GetComponent<Button>().interactable = true;
            if(list.Count >= 2){
                GameObject.Find("SelectEvent1").GetComponent<Button>().interactable = true;
                if(list.Count >= 3){
                    GameObject.Find("SelectEvent2").GetComponent<Button>().interactable = true;
                    if(list.Count >= 4){
                        GameObject.Find("SelectEvent3").GetComponent<Button>().interactable = true;
                    }
                }

            }   
        }

    }
    
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
    private Text text = null;
    private string eventname;
    public void OnClick(){
        if(text != null ){
            eventname = "EventView"+text.text;
            if(true){
                //Debug.Log("eventname:"+eventname);
                GameObject eventview = GameObject.Find(eventname);
                Destroy (eventview);
                
                int x = int.Parse(text.text);
                list.RemoveAt(x);
                Debug.Log("カード効果発動");
                if(list.Count == 0){
                    Debug.Log("リストの中身:"+list.Count);
                    GameObject havebutton = GameObject.Find ("ButtonHaveCard");
                    GameObject.Find("ButtonHaveCard").GetComponent<Button>().interactable = false;
                }
                GameObject obj = GameObject.Find(var);
                Destroy (obj);
                // イベント通知先があれば通知してダイアログを破棄してしまう
                this.FixDialog?.Invoke(DialogResult.Cancel);
                Destroy(this.gameObject);
            }
            else{
                Onbody();
            }
        }else{
            Onbody();
        }    
    }

    //private Text text;
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