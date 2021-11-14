using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CompanyList : MonoBehaviour
{
    Vector3[] cardPos = new Vector3[7];
    public static List<int> list = new List<int>();
    // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private EventShow dialog = default;
    public static int Flag = 0;
    public void ShowCompanyList(){
        Debug.Log("Flag:"+Flag);
        if(Flag==0){
            list.Clear();
            Debug.Log("空");
            Flag = 1;
        }
        // 生成してCanvasの子要素に設定
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        // ボタンが押されたときのイベント処理
        _dialog.FixDialog = result => Debug.Log(result);


        for (int i = 0; i <= 6; i++)
        {
            float initInt = 225;
            float tarInt = 0;
            if(i<4){
                tarInt = i*initInt;
                Vector3 initVector3 = new Vector3(-575,81,-6);
                Vector3 tarVector3 = new Vector3(-575+tarInt,81,-6);
                cardPos[i] = tarVector3;
            }else{
                tarInt = (i-4)*initInt;
                Vector3 initVector3 = new Vector3(-575,-232,-6);
                Vector3 tarVector3 = new Vector3(-575+tarInt,-232,-6);
                cardPos[i] = tarVector3;
            }
        }
        int[] src = new int[7]{0,1, 2, 3, 4, 5, 6};
        foreach(int str in src) {
            GameObject eve = new GameObject("EventBox"+$"{str}");
            eve.transform.position = cardPos[str];
            eve.GetComponent<Transform>().localScale = new Vector3(22,22,1);
            eve.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{str}");
            eve.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        /*
        GameObject event1 = new GameObject(var);
        GameObject event2 = new GameObject(var2);
        GameObject event3 = new GameObject(var3);
        GameObject event4 = new GameObject(var4);
        */


        // 作ったゲームオブジェクトをCanvasの子にする
        //event1.transform.parent = GameObject.Find ("Canvas").transform;
        //event2.transform.parent = GameObject.Find ("Canvas").transform;
        //event3.transform.parent = GameObject.Find ("Canvas").transform;
        //event4.transform.parent = GameObject.Find ("Canvas").transform;
        // 画像のアンカーポジションを追加
        //event1.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (-730, 270, 0);
        //event2.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (-300, 270, 0);
        //event3.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (130, 270, 0);
        /*
        event1.transform.position = new Vector3(-575,81,-6);
        event2.transform.position = new Vector3(-350,81,-6);
        event3.transform.position = new Vector3(-575,-232,-6);
        event4.transform.position = new Vector3(-125,81,-6);
        

        // 縮尺を変更
        event1.GetComponent<Transform> ().localScale = new Vector3 (22, 22, 5);
        event2.GetComponent<Transform> ().localScale = new Vector3 (22, 22, 5);
        event3.GetComponent<Transform> ().localScale = new Vector3 (22, 22, 5);
        event4.GetComponent<Transform> ().localScale = new Vector3(22,22,1;

        // スプライト画像追加
        event1.AddComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>(left.ToString());
        event2.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(center.ToString());
        //event3.AddComponent<Image> ().sprite = Resources.Load<Sprite>(right.ToString());
        event3.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(right.ToString());
        event4.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(left.ToString());
        

        // アスペクト比を元画像と同じサイズにする
        //event1.GetComponent<Image> ().preserveAspect = true;
        //event2.GetComponent<Image> ().preserveAspect = true;
        //event3.GetComponent<Image> ().preserveAspect = true;
        //event4.GetComponent<Image> ().preserveAspect = true;

        //画像のサイズを元の何倍かに調整
        //event1.transform.localScale = Vector3.one * 5;
        //event2.transform.localScale = Vector3.one * 5;
        //event3.transform.localScale = Vector3.one * 5;

        //表示レンダー
        event1.GetComponent<SpriteRenderer>().sortingOrder = 4;
        event2.GetComponent<SpriteRenderer>().sortingOrder = 4;
        event3.GetComponent<SpriteRenderer>().sortingOrder = 4;
        event4.GetComponent<SpriteRenderer>().sortingOrder = 4;
        */
        
    }
}
