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
        Speed = Utils.translateFloat(param["speed"]);
        Health = int.Parse(param["health"]);
        isAlive = bool.Parse(param["isAlive"]);
        Name = param["name"];
    }

    void Update()
    {
        var Move = Input.GetAxis("Horizontal") * speed; // кроссплатформенное управление
        rb.velocity = new Vector2(Move, rb.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
            horz = 1;
            transform.GetChild(0).localPosition = new Vector2(0.234f, -0.039f);//объект из
                                                                                //которого идет
                                                                                //атака
            animation.Play("run");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
            horz = -1;
            transform.GetChild(0).localPosition = new Vector2(-0.234f, -0.039f);
            animation.Play("run");
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            sprite.flipX = false;
            horz = 1;
            transform.GetChild(0).localPosition = new Vector2(0.234f, -0.039f);
            animation.Play("run");
        } else if (Input.GetAxis("Vertical") < 0)
        {
            sprite.flipX = true;
            horz = -1;
            transform.GetChild(0).localPosition = new Vector2(-0.234f, -0.039f);
            animation.Play("run");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animation.Play("attack");
            /*GameObject gm = Instantiate(bang,
                new Vector2(transform.GetChild(0).position.x,
                    transform.GetChild(0).position.y), Quaternion.identity);
            gm.GetComponent<Rigidbody2D>().velocity = new Vector2(bang_force * horz, 0);*/

        }
    }

    public void takeDamage(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            //death screen
            // visual fx
            Health = 0;
            // set health bar
        }
    }
}
