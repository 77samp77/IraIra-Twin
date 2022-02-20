using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointController : MonoBehaviour
{
    GameObject player1;
    GameObject borderPrefab;
    GameObject startPoint1;
    GameObject startPoint2;

    GameObject gameManager;
    GameManagerScript gms;

    GameObject tutorialManager;
    TutorialManager tms;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        borderPrefab = (GameObject)Resources.Load("Prefabs/Border");
        startPoint1 = GameObject.Find("StartPoint1");
        startPoint2 = GameObject.Find("StartPoint2");

        gameManager = GameObject.Find("GameManager");
        gms = gameManager.GetComponent<GameManagerScript>();

        if(GameManagerScript.gameMode == 2)
        {
            tutorialManager = GameObject.Find("TutorialManager");
            tms = tutorialManager.GetComponent<TutorialManager>();

            Vector3 temp = transform.position;
            temp.y = Screen.height / 2 + 100;
            transform.position = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gms.isStop) return;

        transform.Rotate(0, 0, 2);
        float alpha = GetComponent<SpriteRenderer>().color.a;

        if(this.gameObject.name == "StartPoint1")
        {
            float dist = (transform.position - player1.transform.position).sqrMagnitude;

            if(GameManagerScript.gameMode == 2)
            {
                Vector3 temp = transform.position;
                if(alpha < 0.01f)
                {
                    temp.y = 0;
                    transform.position = temp;
                }
                if(tms.progress == 1 && temp.y > 0)
                {
                    temp.y -= 3;
                    transform.position = temp;
                }
            }

            if(dist < Mathf.Pow(30, 2) && !gms.isStarted)
            {
                gms.isStarted = true;
                Instantiate(borderPrefab, new Vector3(0, Screen.height / 2, 0), Quaternion.identity);
                if(GameManagerScript.gameMode == 2)
                {
                    if(tms.progress == 1)
                    {
                        tms.progress++;
                        tms.UpdateMessage();
                    }
                }
            }
        }

        if(gms.isStarted)
        {
            alpha -= 0.05f;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

            Vector3 scl = transform.localScale;
            scl.x += 2;
            transform.localScale = new Vector3(scl.x, scl.x, scl.z);
        }

        if(this.gameObject.name == "StartPoint2") Synchronize();
    }

    void Synchronize()
    {
        GetComponent<SpriteRenderer>().color = startPoint1.GetComponent<SpriteRenderer>().color;

        Vector3 temp = transform.position;
        temp.y = startPoint1.transform.position.y;
        transform.position = temp;

        transform.localScale = startPoint1.transform.localScale;
    }

    public void Reset()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        if(GameManagerScript.gameMode == 2)
        {
            Vector3 temp = transform.position;
            temp.y = 0;
            transform.position = temp;
        }
        transform.localScale = new Vector3(40, 40, 1);
        gameObject.SetActive(true);
    }
}
