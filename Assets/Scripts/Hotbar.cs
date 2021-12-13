using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private float axis;
    public int selectedSlot;
    public GameObject[] slots;

    void Update()
    {
        axis += Input.GetAxis("Mouse ScrollWheel");
        axis = Mathf.Clamp(axis, 0, 6); // слотов
        Debug.Log(axis);

        selectedSlot = (int)axis;

    }

}

