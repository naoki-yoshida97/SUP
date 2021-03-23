using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseChara : MonoBehaviour
{

    public void SimChose()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        
        GameObject nia = GameObject.Find("nia");
        GameObject mugi = GameObject.Find("mugi");
        GameObject whiteMugi = GameObject.Find("whiteMugi");
        
        Destroy(nia);
        Destroy(mugi);
        Destroy(whiteMugi);
        Showhide.transform.localScale = new Vector3(0,0,0);  
    }
    public void niaChose()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        /*
        GameObject sim = GameObject.Find("sim");
        GameObject mugi = GameObject.Find("mugi");
        GameObject whiteMugi = GameObject.Find("whiteMugi");
        Destroy(sim);
        Destroy(mugi);
        Destroy(whiteMugi);
        */
        Showhide.transform.localScale = new Vector3(0,0,0);  
    }
    public void mugiChose()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        
        GameObject nia = GameObject.Find("nia");
        GameObject sim = GameObject.Find("sim");
        GameObject whiteMugi = GameObject.Find("whiteMugi");
        Destroy(nia);
        Destroy(sim);
        Destroy(whiteMugi);
        Showhide.transform.localScale = new Vector3(0,0,0);  
    }
    public void whiteMugiChose()
    {
        GameObject Showhide = GameObject.Find("ChoseChara");
        
        GameObject nia = GameObject.Find("nia");
        GameObject mugi = GameObject.Find("mugi");
        GameObject whiteMugi = GameObject.Find("sim");
        
        Destroy(nia);
        Destroy(mugi);
        Destroy(whiteMugi);
        Showhide.transform.localScale = new Vector3(0,0,0);  
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
