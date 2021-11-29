using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] ui_elements;

    void Start()
    {
        ui_elements = GameObject.FindGameObjectsWithTag("UI");
    }

    public void Btn(string name)
    {
        switch (name)
        {
            case "Btn_play":
                //загрузка сцены
                break;

            case "Btn_exit":
                Application.Quit();
                break;

            case "Btn_options":
                ui_elements[2].GetComponent<Animation>().Play("slide"); //подумать
                break;
        }
    }

}
