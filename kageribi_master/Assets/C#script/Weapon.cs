using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }

    }
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            Transform shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            EnemyBullet tempShot = shotTransform.gameObject.GetComponent<EnemyBullet>();
            if (tempShot != null)
            {
                tempShot.isEnemyShot = isEnemy;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other);
        }
        else if(other.tag == "floor")
        {
            Destroy(other);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnBecameVisible()
    {
        
    }
}
