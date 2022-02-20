using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public GameObject tutorialManager;
    TutorialManager tms;

    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        tms = tutorialManager.GetComponent<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        tms.progress++;
        tms.UpdateMessage();
    }

    public void UpdateButton()
    {
        if(tms.progress == 1 || tms.progress == 3) nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }
}