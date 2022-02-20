using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject optionUIPrefab;
    public GameObject optionUIInstance;

    public GameObject titleManager;
    TitleManager tms;

    // Start is called before the first frame update
    void Start()
    {
        tms = titleManager.GetComponent<TitleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        optionUIInstance = GameObject.Instantiate(optionUIPrefab) as GameObject;
        tms.isOption = true;
    }
}
