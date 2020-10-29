using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKCancelDialogTest : MonoBehaviour
{
     // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private OK dialog = default;

    public void ShowDialog()
    {
        // 生成してCanvasの子要素に設定
        var _dialog = Instantiate(dialog);
        _dialog.transform.SetParent(parent.transform, false);
        // ボタンが押されたときのイベント処理
        _dialog.FixDialog = result => Debug.Log(result);
    }
}
