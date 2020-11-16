using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanDev : MonoBehaviour
{

    public void OnLoadScene(){
        // シーンの読み込み
        SceneManager.LoadScene("CityBoard");
    }
    // Start is called before the first frame update
    void Start () {
        Debug.Log("ロードしたよ");
        
    }
     

}
