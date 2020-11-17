using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseChara : MonoBehaviour
{

    public void SimChose()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        /*
        GameObject nia = GameObject.Find("nia");
        GameObject mugi = GameObject.Find("mugi");
        GameObject whiteMugi = GameObject.Find("whiteMugi");
        */
        Destroy(this.gameObject);
        Showhide.transform.localScale = new Vector3(0,0,0);
        Destroy(this.gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        Showhide.transform.localScale = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
