using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] ui_elements;
    public GameObject cam;

    void Start()
    {
        ui_elements = GameObject.FindGameObjectsWithTag("UI");
        cam = GameObject.Find("Main Camera");
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

            case "set_rus": PlayerPrefs.SetString("language", "rus");
                cam.GetComponent<languagesController>().Start();
                break;
            case "set_eng": PlayerPrefs.SetString("language", "eng");
                cam.GetComponent<languagesController>().Start();
                break;
        }
    }

}
