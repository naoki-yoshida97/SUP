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
        
        inful = new GameObject



    }

    public void removeClick()
    {
        //クリックされたら減る
    }

}
