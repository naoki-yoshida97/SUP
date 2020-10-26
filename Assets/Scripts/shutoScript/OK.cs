using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OK : MonoBehaviour
{
    public enum DialogResult
    {
        OK,
        Cancel,
    }

    public Action<DialogResult> FixDialog{ get; set; }

    public void OnOk()
    {
        this.FixDialog?.Invoke(DialogResult.OK);
        Destroy(this.gameObject);
    }

    public void OnCancel()
    {
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
    }
}
