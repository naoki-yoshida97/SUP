// OkCancelDialogTest.cs

using UnityEngine;

public class CoopListButton : MonoBehaviour {
    public void ShowDialog () {
        GameObject Dialog = Instantiate ((GameObject) Resources.Load ("ShowCorpDialog")) as GameObject;
        Dialog.transform.parent = GameObject.Find ("Canvas").transform;
        Dialog.transform.position = new Vector3 (450, 250, 0);
    }
}