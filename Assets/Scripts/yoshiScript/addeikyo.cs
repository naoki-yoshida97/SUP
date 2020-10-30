using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addeikyo : MonoBehaviour
{   
    
    //settintg Array argument
    static int pos_eix = 400;
    static int pos_eiy = 85;
    static int num_ei;
    public static List<string> eik_coins = new List<string> ();
    string hoge;
    //コインの管理
    public int ei_coin = 0;

    //Game Objects name 
    public GameObject inful;

    // Pudh Object:eip button when it starts
    public void addClick()
    {   
        // Debug.Log ("クリックされた");
        //クリックされたら増える
        ei_coin++;
        

        hoge = "eikyo_"+ ei_coin;
        //into list
        eik_coins.Add(hoge);
        Debug.Log(hoge);

        //ヒエラルキーに追加されつ名前の追加
        GameObject inful = new GameObject(hoge);

        //canvasの子に追加
        inful.transform.parent = GameObject.Find("Canvas").transform;

        //ポジション
        inful.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_eix, pos_eiy, 0);

        //倍率
        inful.GetComponent<RectTransform> ().localScale = new Vector3 (0.5f, 0.5f, 0.5f);

        //Rssourcesから"eikyou"画像の読み込み
        inful.AddComponent<Image> ().sprite = Resources.Load<Sprite> ("eikyou");
        
        //真にすることで表記
        inful.GetComponent<Image> ().preserveAspect = true;

        // xに-13移動
        pos_eix = pos_eix - 13;
        // Debug.Log(pos_eix);

    }

    public void removeClick()
    {
        //クリックされたら減る
        ei_coin--;
        hoge = "eikyo_"+ ei_coin;
        GameObject inful = GameObject.Find (hoge);
        Destroy (inful);
        Debug.Log("osita");
        // public static List<string> eik_coins = new List<string> ();
        // for (int i = 0; i < eik_coins.Count; i++) {
        // GameObject obj = GameObject.Find (eik_coins[i]);
        // Destroy (obj);
        // }
    }

}
