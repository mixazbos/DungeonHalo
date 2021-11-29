using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class languagesController : MonoBehaviour
{
    public String lang { get; set; }
    public String lang_pkg { get; set; }
    public String characters { get; set; }
    public GameObject[] ui_elements;

    static Dictionary<string, string> _langs = new Dictionary<string, string>();
    static Dictionary<string, string> _characters = new Dictionary<string, string>();

    public void Start()
    {
        Begin();
    }

 
    private void Begin()
    {
        _langs.Clear();
        InitLang(PlayerPrefs.GetString("language")); // здесь вызов скрипта загрузки файлов языка

        ui_elements = GameObject.FindGameObjectsWithTag("UI");
        foreach (var obj in ui_elements)
        {
            try
            {
                obj.gameObject.transform.GetChild(0).GetComponent<Text>().text = GetText(obj.gameObject.name);
            }
            catch
            {
                Debug.Log("У объекта " + obj.gameObject.name + " нет текста");
            }
        }
    }

    private void InitLang(string lang)
    {
        lang_pkg = File.ReadAllText(@"language_" + lang + ".lng");
        characters = File.ReadAllText(@"characters.asset");

        var text = lang_pkg.Split('\n');
        foreach (var c in text)
        {
            var t = c.Split(':');
            _langs.Add(t[0].Trim(), @t[1].Trim().Trim(';'));
        }
        
    }

    static String GetText(string key)
    {
        return _langs[key];
    }


    static Dictionary<string, string> GetChars(string key)
    {
        Dictionary<string, string> chars = new Dictionary<string, string>();

        var hero = _characters[key]
            .Replace("{", String.Empty)
            .Replace("}", String.Empty)
            .Split(',');

        foreach (var c in hero)
        {
            var ret = c.Split('=');

            chars.Add(ret[0], ret[1]);
        }

        return chars;
    }

    private void InitChars()
    {
        var text = characters.Replace(" ", string.Empty).Split('\n');

        foreach (var c in text)
        {
            var t = c.Split(':');

            _characters.Add(t[0], t[1]);

        }
    }
}
