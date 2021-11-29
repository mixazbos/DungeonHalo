using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languagesController : MonoBehaviour
{
    private string lang { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        lang = PlayerPrefs.GetString("language");
        Init(); // здесь вызов скрипта на языки
    }

    //скрипт вызова инициализации языка
}
