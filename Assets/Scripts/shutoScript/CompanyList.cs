using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CompanyList : MonoBehaviour
{
    int left = 0;
    int center = 1;
    int right =2;
    string var = "EventBox";
    string var2 = "EventBox2";
    string var3 = "EventBox3";
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

        
        GameObject event1 = new GameObject(var);
        GameObject event2 = new GameObject(var2);
        GameObject event3 = new GameObject(var3);


        // 作ったゲームオブジェクトをCanvasの子にする
        event1.transform.parent = GameObject.Find ("Canvas").transform;
        event2.transform.parent = GameObject.Find ("Canvas").transform;
        event3.transform.parent = GameObject.Find ("Canvas").transform;

        // 画像のアンカーポジションを追加
        event1.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (-730, 270, 0);
        event2.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (-300, 270, 0);
        event3.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (130, 270, 0);

        // 縮尺を変更
        event1.GetComponent<RectTransform> ().localScale = new Vector3 (5, 5, 5);
        event2.GetComponent<RectTransform> ().localScale = new Vector3 (5, 5, 5);
        event3.GetComponent<RectTransform> ().localScale = new Vector3 (5, 5, 5);

        // スプライト画像追加
        event1.AddComponent<Image> ().sprite = Resources.Load<Sprite>(left.ToString());
        event2.AddComponent<Image> ().sprite = Resources.Load<Sprite>(center.ToString());
        event3.AddComponent<Image> ().sprite = Resources.Load<Sprite>(right.ToString());

        // アスペクト比を元画像と同じサイズにする
        event1.GetComponent<Image> ().preserveAspect = true;
        event2.GetComponent<Image> ().preserveAspect = true;
        event3.GetComponent<Image> ().preserveAspect = true;

        //画像のサイズを元の何倍かに調整
        event1.transform.localScale = Vector3.one * 5;
        event2.transform.localScale = Vector3.one * 5;
        event3.transform.localScale = Vector3.one * 5;
        
    }
}
