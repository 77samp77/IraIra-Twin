using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptionButton : MonoBehaviour
{
    GameObject optionButton;
    OptionButton obs;

    GameObject titleManager;
    TitleManager tms;

    // Start is called before the first frame update
    void Start()
    {
        optionButton = GameObject.Find("OptionButton");
        obs = optionButton.GetComponent<OptionButton>();

        titleManager = GameObject.Find("TitleManager");
        tms = titleManager.GetComponent<TitleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(tms.isOption && Input.GetKey(KeyCode.Escape)) OnClick();
        }
    }

    public void OnClick()
    {
        tms.isOption = false;
        Destroy(obs.optionUIInstance);
    }
}
