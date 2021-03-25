using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationName : MonoBehaviour
{
    private GameObject namePlate; //名前を表示しているプレート
    public Text nameText;   //名前を表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        namePlate = nameText.transform.parent.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        namePlate.transform.rotation = Camera.main.transform.rotation; //まぁ2Dだからいらないけどね
        nameText.text = name;
    }
}
