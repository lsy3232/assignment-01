using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Image portraitImg;
    public Animator portraitAnim;
    public TypeEffect talk;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public Sprite prePortrait;

    void Start() 
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GameObject<ObjData>();
        talkIndex(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow",isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim){
            talk.SetMsg("");
            return;
        }
        else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);
        }

        if(talkData == null){
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if(isNpc){
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.)) ;
            portraitImg.color = new Color(1, 1, 1, 1;);
            if(prePortrait != portraitImg.sprite){
                portraitAnim.SetTrigger("doEffect");
                prePortrait = portraitImg.sprite;
            }   
        }
        else{
            talk.SetMsg(talkData);

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
