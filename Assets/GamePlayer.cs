using Photon.Pun;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承すると、photonViewプロパティが使えるようになる
public class GamePlayer : MonoBehaviourPunCallbacks {
    private void Update () {
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine) {
            var dx = 0.1f * Input.GetAxis ("Horizontal");
            var dy = 0.1f * Input.GetAxis ("Vertical");
            transform.Translate (dx, dy, 0f);
        }
    }
}