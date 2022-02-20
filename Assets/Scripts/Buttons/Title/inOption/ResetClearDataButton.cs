using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetClearDataButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        for(int n = 0; n < LevelManager.levelSize; n++) LevelManager.isCleared[n] = false;
        string strget = null;
        for(int n = 0; n < LevelManager.levelSize; n++) strget = strget + LevelManager.isCleared[n].ToString() + ",";
        PlayerPrefs.SetString("ClearData", strget);
    }
}
