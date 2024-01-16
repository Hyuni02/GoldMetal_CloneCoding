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
        //Talk Data
        talkData.Add(1000, new string[] { 
            "안녕?:1", 
            "이 곳에 처음 왔구나?:2" 
        });
        talkData.Add(2000, new string[] {
            "안녕...:1"
        });
        talkData.Add(100, new string[] {
            "평범한 나무 상자이다."
        });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] {
            "여자애 한테 가봐:1"
        });
        talkData.Add(11 + 2000, new string[] {
            "꽃을 가져다줘:1"
        });

        talkData.Add(20 + 200, new string[] {
            "여자애에게 줄 꽃이다."
        });
        talkData.Add(21 + 2000, new string[] {
            "고마워:1"
        });

        //Portrait Data
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkidx) {
        if (!talkData.ContainsKey(id)) {
            if(!talkData.ContainsKey(id - id % 10)) {
                return GetTalk(id - id % 100, talkidx);
            }
            else {
                return GetTalk(id - id % 10, talkidx);
            }
        }
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
