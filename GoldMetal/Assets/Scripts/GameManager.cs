using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TextPanel;
    public Text TalkText;
    public GameObject scanObject;

    public bool isAction;

    public void Start() {
        TextPanel.gameObject.SetActive(false);
    }

    public void Action(GameObject scanObj) {
        if(isAction) {
            isAction = false;
        }
        else {
            isAction = true;
            scanObject = scanObj;
            TalkText.text = scanObj.name;
        }
        TextPanel.gameObject.SetActive(isAction);
    }
}
