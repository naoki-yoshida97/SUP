using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    int dis_x=60;
    //ボタンが押された場合、今回呼び出される関数
    public void OnClickAdd()
    {
        int pos_x=-50;
        int pos_y=350;

        Debug.Log("Add"); //ログを出力

        string name = inputField2.text;

        // CubeプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load ("Cube");
        obj.name = name;
        dis_x += 60;
        pos_x += dis_x;
	    //Cubeプレハブを元に、インスタンスを生成、
        Instantiate (obj, new Vector3(pos_x,pos_y,0.0f), Quaternion.identity);
        //obj.transform.SetParent (Canvas.transform, false);
    }   

    public void OnClickDelete()
    {   
        Debug.Log("Delete");
        string name = inputField1.text;

	    GameObject obj = GameObject.Find (name);
	    Destroy(obj);
    }   

    //InputFieldを格納するための変数
    InputField inputField1;
    InputField inputField2; 
    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField1 = GameObject.Find("InputField1").GetComponent<InputField>();
        inputField2 = GameObject.Find("InputField2").GetComponent<InputField>();
    }
 
    //入力された名前情報を読み取ってコンソールに出力する関数
 
}
