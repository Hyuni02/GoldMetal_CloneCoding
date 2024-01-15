using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;

    public GameObject TextPanel;
    public Text TalkText;
    public Image portrait;
    public GameObject scanObject;

    public bool isAction;
    public int talkidx;

    public void Start() {
        TextPanel.gameObject.SetActive(false);
    }

    public void Action(GameObject scanObj) {

        isAction = true;
        scanObject = scanObj;
        ObjectData data = scanObj.GetComponent<ObjectData>();
        Talk(data.id, data.isNPC);

        TextPanel.gameObject.SetActive(isAction);
    }

    void Talk(int id, bool isnpc) {
        string talkData = talkManager.GetTalk(id, talkidx);

        if (talkData == null) {
            isAction = false;
            talkidx = 0;
            return;
        }

        if(isnpc) {
            TalkText.text = talkData.Split(':')[0];

            portrait.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portrait.color = new Color(1,1,1,1);
        }
        else {
            TalkText.text = talkData;
            portrait.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkidx++;
    }
}
