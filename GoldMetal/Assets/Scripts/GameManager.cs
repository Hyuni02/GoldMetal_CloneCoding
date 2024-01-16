using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;

    public GameObject TextPanel;
    public Text TalkText;
    public Image portrait;
    public GameObject scanObject;

    public bool isAction;
    public int talkidx;

    public void Start() {
        TextPanel.gameObject.SetActive(false);

        print(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj) {
        //Get Current Object
        scanObject = scanObj;
        ObjectData data = scanObj.GetComponent<ObjectData>();
        Talk(data.id, data.isNPC);

        //Visible Talk for Action
        TextPanel.gameObject.SetActive(isAction);
    }

    void Talk(int id, bool isnpc) {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkidx);

        //End Talk
        if (talkData == null) {
            isAction = false;
            talkidx = 0;
            print(questManager.CheckQuest(id));
            return;
        }

        //Continue Talk
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
