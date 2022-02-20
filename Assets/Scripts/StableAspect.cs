using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour
{
    private Camera cam;

    private float width = 1080f;
    private float height = 1920f;

    void Awake()
    {
        float aspect = (float)Screen.height / (float)Screen.width;
        float bgAcpect = height / width;

        cam = GetComponent<Camera>();
        if(bgAcpect > aspect)
        {
            float bgScale = height / Screen.height;
            float camWidth = width / (Screen.width * bgScale);
            cam.rect = new Rect((1f - camWidth) / 2f, 0f, camWidth, 1f);
        }
        else
        {
            float bgScale = aspect / bgAcpect;
            cam.orthographicSize *= bgScale;
            cam.rect = new Rect(0f, 0f, 1f, 1f);
        }
    }
}