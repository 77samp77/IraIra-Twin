using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool[] isCleared;
    public static int levelSize = 5;

    // Start is called before the first frame update
    void Awake()
    {
        isCleared = new bool[levelSize];
        string LoadClear = PlayerPrefs.GetString("ClearData", null);

        if(LoadClear != "")
        {
            string[] strClearArray = LoadClear.Split(',');
            for(int n = 0; n < levelSize; n++) isCleared[n] = System.Convert.ToBoolean(strClearArray[n]);
        }
        else
        {
            for(int n = 0; n < levelSize; n++) isCleared[n] = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
