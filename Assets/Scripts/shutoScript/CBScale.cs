using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBScale : MonoBehaviour
{
    public Vector3 scale;

    public void ShowScale(GameObject Dlog){
        scale = new Vector3(1,1,1);
        Dlog.gameObject.transform.localScale = new Vector3(scale.x,scale.y,scale.z);
    } 
    public void hideScale(GameObject Dlog){
        scale = new Vector3(0,0,0);
        Dlog.gameObject.transform.localScale = new Vector3(scale.x,scale.y,scale.z);
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
