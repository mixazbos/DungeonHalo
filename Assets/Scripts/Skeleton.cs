using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Versioning;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
        static Dictionary<string, string> param = new Dictionary<string, string>();

        public float Speed;
        public float Distance;
        public int Health;
        public int Damage;

        private GameObject playerReference;
        private Prefab bullet;

        private Vector2 direction;

        void Start()
        {
            var lc = GameObject.Find("Main Camera")
                .GetComponent<languagesController>();

            lc.InitChars();
            param = lc.GetChars("Skeleton");
            SetupSelf();

            playerReference = GameObject.Find("Player"); //тэг
        }

        private void SetupSelf()
        {
            Speed = Utils.translateFloat(param["speed"]);
            Health = int.Parse(param["health"]);
            Distance = Utils.translateFloat(param["distance"]);
            Damage = int.Parse(param["damage"]);

            bullet = Resources.Load();// пуля
        }

        void Update()
        {
            gameObject.GetComponent<RigidBody2D>().addForce(direction,Speed); //()..........;
                //или translate
            if (Vector2.Distance(playerReference, gameObject) < Distance)
            {
                gameObject.GetComponent<RigidBody2D>().Translate(playerReference, Speed);
                AttackPly();
            }
        }

        private void AttackPly()
        {
            StartCoroutine(delayShoot());
            var shoot = Instantiate(bullet); //quaternion
        }

        void newVector()
        {
            direction = new Vector2(Random.Range(0,180), Random.Range(0, 180));
            StartCoroutine(changeDirection());
        }

        IEnumerator changeDirection()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            newVector();
        }

        IEnumerator delayShoot()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            AttackPly();
        }
}
