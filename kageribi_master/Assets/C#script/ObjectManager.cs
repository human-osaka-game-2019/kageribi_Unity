using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public static ObjectManager instance;
    public GameObject firePrefab;

    List<GameObject> bullets = new List<GameObject>();

    private void Awake()
    {
        if(ObjectManager.instance == null)
        {
            ObjectManager.instance = this;
        }
    }

    void Start()
    {
        CreateBullets(5);
    }
    
    void CreateBullets(int bulletCount)
    {
        for(int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(firePrefab) as GameObject;

            bullet.transform.parent = transform;
            bullet.SetActive(false);

            bullets.Add(bullet);
        }
    }

    public GameObject GetBullet(Vector3 pos)
    {
        GameObject reqBullet = null;
        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i].activeSelf == false)
            {
                reqBullet = bullets[i];

                break;
            }
        }

        if(reqBullet == null)
        {
            GameObject newBullet = Instantiate(firePrefab) as GameObject;
            newBullet.transform.parent = transform;

            bullets.Add(newBullet);
            reqBullet = newBullet;
        }

        reqBullet.SetActive(true);

        reqBullet.transform.position = pos;

        return reqBullet;
    }

    void Update()
    {
        
    }
}
