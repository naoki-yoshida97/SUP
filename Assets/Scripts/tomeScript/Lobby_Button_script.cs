using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby_Button_script : MonoBehaviour {
    public void OnClickRoom1Button () {
        SceneManager.LoadScene ("CityBoard");
        Application.LoadLevelAdditive ("CorpCreate");
        Application.LoadLevelAdditive ("SampleScene");
    }
}