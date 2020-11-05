// OkCancelDialogTest.cs

using UnityEngine;

public class OfficerListButton : MonoBehaviour {
    public void ShowDialog () {
        GameObject Dialog = Instantiate ((GameObject) Resources.Load ("ShowOfficerDialog")) as GameObject;
        Dialog.transform.parent = GameObject.Find ("Canvas").transform;
        Dialog.transform.position = new Vector3 (450, 250, 0);
    }
}