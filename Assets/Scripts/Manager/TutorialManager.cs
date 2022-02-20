using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public int progress;
    
    public GameObject message;
    Text mt;

    public GameObject nextButton;
    NextButton nbs;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManagerScript.gameMode != 2)
        {
            Destroy(gameObject);
            return;
        }
        progress = 0;

        mt = message.GetComponent<Text>();

        nbs = nextButton.GetComponent<NextButton>();

        UpdateMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMessage()
    {
        switch(progress)
        {
            case 0:
                mt.text = "これはチュートリアルです。\n画面をスワイプすることで2つの黒丸を操作できます。\n(右下のボタンで次へ)";
                break;
            case 1:
                mt.text = "点線の円に黒丸を合わせるとゲームが始まります。";
                break;
            case 2:
                mt.text = "上から迫ってくる壁を避けましょう。\nぶつかるとゲームオーバーです。\n(右下のボタンで次へ)";
                break;
            case 3:
                mt.text = "緑色の線がゴールです。";
                break;
        }
        nbs.UpdateButton();
    }
}
