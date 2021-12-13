using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    /// <summary>
    /// Перевести float в понятный формат
    /// </summary>
    /// <param name="input">Входное число в неправильном формате</param>
    /// <returns>Float значение в Unity формате</returns>
    public static float translateFloat(string input)
    {
        return float.Parse(input.Replace(".", ","));
    }

    /// <summary>
    /// Получить текст с ресурсов
    /// </summary>
    /// <param name="path">Путь до текстового ресурса</param>
    /// <returns>Текстовый файл с ресурсов</returns>
    public static string getResourceText(string path)
    {
        return Resources.Load<TextAsset>(@"TextAssets/" + path); ;
    }

    /// <summary>
    /// Спрайт с ресурсов
    /// </summary>
    /// <param name="name">Имя спрайта</param>
    /// <returns>Спрайт</returns>
    public static Sprite getResourceSprite(string name)
    {
        return Resources.Load<Sprite>(@"Sprites/" + name); 
    }
}
