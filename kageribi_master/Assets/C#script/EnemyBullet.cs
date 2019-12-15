using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBullet : MonoBehaviour
{
    ChouChinAI chouchinAI;

    public GameObject bulletShot;
    public Transform bulletFireLine;
    public float fireDelay;
    public bool fireState;

    public float bulletSpeed = 3.0f;

    public int MaxBulletPool;
    private MemoryPool MPool;
    private GameObject[] BulletArray;

    private void OnApplicationQuit()
    {
        MPool.Dispose();
    }

    void Start()
    {
        chouchinAI = new ChouChinAI();
        MPool = new MemoryPool();
        MPool.Create(bulletShot, MaxBulletPool);
        BulletArray = new GameObject[MaxBulletPool];
    }

    //transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    //transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.left * MoveSpeed * Time.deltaTime);
    //GetComponent<Rigidbody2D>().AddForce(Vector2.down * MoveSpeed * Time.deltaTime);

    void FixedUpdate()
    {
        if (chouchinAI.Fireball == true)
        {

            fireState = true;

            BulletFire();

        }

        transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
        transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);
    }

    void BulletFire()
    {

        if(fireState)
        {
            for (int i = 0; i < MaxBulletPool; i++ )
            {
                StartCoroutine(FireCoroutine());

                if (BulletArray[i] == null)
                {
                    BulletArray[i] = MPool.NewItem();
                    BulletArray[i].transform.position = bulletFireLine.transform.position;
                    
                    break;
                }
            }
        }

        for (int i = 0; i < MaxBulletPool; i++)
        {

            if (BulletArray[i])
            {
                if (BulletArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    BulletArray[i].GetComponent<Collider2D>().enabled = true;
                    MPool.RemoveItem(BulletArray[i]);
                    BulletArray[i] = null;
                }
            }
        }
    }

    IEnumerator FireCoroutine()
    {
        fireState = false;
        yield return new WaitForSeconds(fireDelay);
        fireState = true;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "floor")
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);
    }
}

