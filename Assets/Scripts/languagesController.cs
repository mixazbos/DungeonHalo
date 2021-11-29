using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languagesController : MonoBehaviour
{
    public string lang { get; set; }
    public GameObject[] ui_elements;

    // Start is called before the first frame update
    void Start()
    {
        lang = PlayerPrefs.GetString("language");
        Init(lang); // здесь вызов скрипта загрузки файлов языка

        //установка текста в элементы
        ui_elements = GameObject.FindGameObjectsWithTag("UI");
        foreach (var obj in ui_elements)
        {
            try
            {
                var text = obj.GetChild[0].GetComponent<Text>().text = GetText(gameObject.Name);
            }
            catch
            {
                Debug.Log("У объекта " + obj.Name + " нет текста");
            }
        }
    }

    //скрипт вызова инициализации языка
}
