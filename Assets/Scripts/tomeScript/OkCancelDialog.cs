using System;
using UnityEngine;

public class OkCancelDialog : MonoBehaviour {
    public enum DialogResult {
        OK,
        Cancel,
    }

    // ダイアログが操作されたときに発生するイベント
    public Action<DialogResult> FixDialog { get; }

    // Cancelボタンが押されたとき
    public void OnCancel () {
        // イベント通知先があれば通知してダイアログを破棄してしまう
        this.FixDialog?.Invoke (DialogResult.Cancel);
        Destroy (this.gameObject);
    }
}