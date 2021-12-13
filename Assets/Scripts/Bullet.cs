using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject cam;
    languagesController lc;
    private GameObject playerReference;
    private Vector2 pos;

    static Dictionary<string, string> param = new Dictionary<string, string>();

    public float Speed;
    public int Damage;
    public string Type;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        lc = cam.GetComponent<languagesController>();
        lc.InitChars();
        param = lc.GetChars(Type);

        SetupSelf();
        playerReference = GameObject.Find("Player"); //тег
        pos = playerReference.gameObject.transform.position;
    }

    private void SetupSelf()
    {
        Speed = Utils.translateFloat(param["speed"]);
        Damage = int.Parse(param["damage"]);
    }

    void Update()
    {
        gameObject.GetComponent<RigidBody2D>().Translate(pos, Speed);
    }

    void OnCollisionEnter(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerReference.GetComponent<Player>().takeDamage(Damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            // destroy fx
        }
    }
}
