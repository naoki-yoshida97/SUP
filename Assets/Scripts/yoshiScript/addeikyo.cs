using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addeikyo : MonoBehaviour
{   
    
    //settintg Array argument
    static int pos_eix = -321;
    static int pos_eiy = -300;
    static int num_ei;

    int[] ei_cnt = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0};

    //初期値は３
    public int ei_coin = 3;

    //Game Objects name 
    public GameObject inful;

    // Start is called before the first frame update
    // void Start()
    // {  
    // }
    // Pudh Object:eip button when it starts
    public void addClick()
    {   
        // Debug.Log ("クリックされた");
        //クリックされたら増える
        ei_coin++;

        GameObject inful = new GameObject("eikyo");
        
        // inful = new GameObject
        inful.transform.parent = GameObject.Find("Canvas").transform;

        inful.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (pos_eix, pos_eiy, 0);

        inful.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);

        inful.AddComponent<Image> ().sprite = Resources.Load<Sprite> ("eikyou");

        inful.GetComponent<Image> ().preserveAspect = true;


        // xに-11移動
        pos_eix = pos_eix - 11;
        Debug.Log(pos_eix);

    }

    public void removeClick()
    {
        //クリックされたら減る
    }

}
