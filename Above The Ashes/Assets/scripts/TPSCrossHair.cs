using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCrossHair : MonoBehaviour
{
    public float width;
    public float length;
    public float distance;
    public Texture2D crosshair;
    public TPSCamera tPSCamera;
    private GUIStyle lineStyle;
    private Texture tex;
    private bool isAiming = false;//是否正在瞄准

    // Use this for initialization
    void Start()
    {
        lineStyle = new GUIStyle();
        lineStyle.normal.background = crosshair;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (tPSCamera.isAiming) {
            GUI.Box(new Rect((Screen.width - distance) / 2 - length, (Screen.height - width) / 2, length, width), tex, lineStyle);
            GUI.Box(new Rect((Screen.width + distance) / 2, (Screen.height - width) / 2, length, width), tex, lineStyle);
            GUI.Box(new Rect((Screen.width - width) / 2, (Screen.height - distance) / 2 - length, width, length), tex, lineStyle);
            GUI.Box(new Rect((Screen.width - width) / 2, (Screen.height + distance) / 2, width, length), tex, lineStyle);
        }
        
    }
}
