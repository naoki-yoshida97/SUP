using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarEnterButton : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown; //Dropdownを格納する変数
    string[] player = new string[4] {
        "mugi", //0
        "nia", //1
        "sim", //2
        "whiteMugi", //3
    };
    public void Onclick(){
        GameObject DiceButton = GameObject.Find("Button_Dice");
        DiceButton.GetComponent<Button>().interactable = true;

        Debug.Log(player[dropdown.value]);
    }
}
