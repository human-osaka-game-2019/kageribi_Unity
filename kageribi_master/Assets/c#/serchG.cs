using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serchG : MonoBehaviour
{
    public GameObject chocin;
    EnemyChoChiGreen enemy;
    // Start is called before the first frame update
    void Start()
    {
        chocin = transform.parent.gameObject;
        enemy = chocin.GetComponent<EnemyChoChiGreen>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.player = other.gameObject;

            StopCoroutine(enemy.E_Movement());

            StartCoroutine(enemy.E_Attack());
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.tracking();

            enemy.MoveRoutine();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.Nottracking();

            StopCoroutine(enemy.E_Attack());

            StartCoroutine(enemy.E_Movement());
        }
    }
}
