using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    public GameObject[] questObjects;
    Dictionary<int, QuestData> questList;

    private void Awake() {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData() {
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("ȣ�����ϱ�", new int[] { 200, 2000 }));
        questList.Add(30, new QuestData("Ʃ�丮�� ����", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id) {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id) {
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex]) {
            questActionIndex++;
        }

        //Control Quest Object
        ControlObject();

        //Talk Complete & Next Quest
        if(questActionIndex == questList[questId].npcId.Length) {
            NextQuest();
        }

        //Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest() {
        //Quest Name
        return questList[questId].questName;
    }

    void NextQuest() {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject() {
        switch(questId){
            case 10:
                if(questActionIndex == 2) {
                    questObjects[0].SetActive(true);
                }
                break;
            case 20:
                if(questActionIndex == 1) {
                    questObjects[0].SetActive(false);
                }
                break;
        }
    }
}

