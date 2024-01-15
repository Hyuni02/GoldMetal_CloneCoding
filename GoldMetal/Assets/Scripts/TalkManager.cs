using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private void Awake() {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData() {
        talkData.Add(1000, new string[] { 
            "안녕?:1", 
            "이 곳에 처음 왔구나?:2" 
        });
        talkData.Add(2000, new string[] {
            "안녕...:5"
        });
        talkData.Add(100, new string[] {
            "평범한 나무 상자이다."
        });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 4, portraitArr[4]);
        portraitData.Add(2000 + 5, portraitArr[5]);
        portraitData.Add(2000 + 6, portraitArr[6]);
        portraitData.Add(2000 + 7, portraitArr[7]);
    }

    public string GetTalk(int id, int talkidx) {
        if (talkidx == talkData[id].Length) {
            return null;
        }
        else {
            return talkData[id][talkidx];
        }
    }

    public Sprite GetPortrait(int id, int portidx) {
        return portraitData[id + portidx];
    }
}
