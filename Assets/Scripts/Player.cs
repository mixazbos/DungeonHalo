using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameObject cam;
    languagesController lc;

    static Dictionary<string, string> param = new Dictionary<string, string>();

    public float Speed;
    public int Health;
    public int Test;
    public bool isAlive;
    public String Name;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        lc = cam.GetComponent<languagesController>();
        lc.InitChars();
        param = lc.GetChars("Player");

        SetupPlayer();
    }

    private void SetupPlayer()
    {
        Speed = float.Parse(param["speed"].Replace(".", ","));
        Health = int.Parse(param["health"]);
        isAlive = bool.Parse(param["isAlive"]);
        Name = param["name"];
    }

    void Update()
    {
        
    }
}
