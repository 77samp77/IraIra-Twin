using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    int level;

    public GameObject checkPrefab;
    public GameObject checkInstance;

    // Start is called before the first frame update
    void Start()
    {
        level = (int)transform.position.z;

        if(LevelManager.isCleared[level - 1])
        {
            checkInstance = GameObject.Instantiate(checkPrefab) as GameObject;
            checkInstance.transform.SetParent(this.transform);
            checkInstance.transform.localPosition = new Vector3(250, 60, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameManagerScript.level = level;
        SceneManager.LoadScene("Game");
    }
}
