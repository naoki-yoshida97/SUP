using UnityEngine;
using UnityEngine.SceneManagement;
 
public class StartButton : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("CityBoard");
    }
 
}
