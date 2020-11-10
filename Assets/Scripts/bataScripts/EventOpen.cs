using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventOpen : MonoBehaviour
{
    int num = 0;
    string var = "EventBox";
    public static List<int> list = new List<int>();
    // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private EventShow dialog = default;

    public void ShowDialog(){
        // 生成してCanvasの子要素に設定
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        // ボタンが押されたときのイベント処理
        _dialog.FixDialog = result => Debug.Log(result);


        Debug.Log("押された!");  // ログを出力
        GameObject corp = new GameObject(var);

        // 作ったゲームオブジェクトをCanvasの子にする
        corp.transform.parent = GameObject.Find ("Canvas_1").transform;

        // 画像のアンカーポジションを追加
        corp.AddComponent<RectTransform> ().anchoredPosition = new Vector3 (0, 0, 0);

        // 縮尺を変更
        corp.GetComponent<RectTransform> ().localScale = new Vector3 (5, 5, 5);

        // イベントをランダムで1枚選択
        num = UnityEngine.Random.Range(89,92); //69から92
        Debug.Log(num); 
        if(num==89 || num==90 || num==91 || num==92){
            list.Add(num);
            Debug.Log(list.ToString());
        }
        // スプライト画像追加
        corp.AddComponent<Image> ().sprite = Resources.Load<Sprite>(num.ToString());

        // アスペクト比を元画像と同じサイズにする
        corp.GetComponent<Image> ().preserveAspect = true;
        Debug.Log("表示された");
    }
}