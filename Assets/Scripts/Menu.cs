using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Menu : MonoBehaviour
{
    public GameObject[] ui_elements;
    public GameObject cam, cursor_light;

    void Start()
    {
        ui_elements = GameObject.FindGameObjectsWithTag("UI");
        cam = GameObject.Find("Main Camera");
        cam.GetComponent<languagesController>().Start();
    }

    public void Btn(string name)
    {
        switch (name)
        {
            case "Btn_play":
                //загрузка сцены
                break;

            case "Btn_exit":
                GameObject.Find("Dialog").GetComponent<Animation>().Play("slide");
                break;

            case "Btn_yes_exit":
                Application.Quit();
                break; 
            
            case "Btn_no_exit":
                GameObject.Find("Dialog").GetComponent<Animation>().Play("slide_out");
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

    void Update()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor_light.gameObject.transform
            .position = new Vector3(worldPosition.x, worldPosition.y, -1f);
    }

}
