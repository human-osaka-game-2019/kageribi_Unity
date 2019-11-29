using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenternType : MonoBehaviour
{
    public GameObject[] fireObjectList;
    public void ActionFire()
    {
        Transform goFire = transform.Find("");
        foreach(GameObject fireObject in fireObjectList)
        {
            GameObject go = Instantiate(fireObject, goFire.position, Quaternion.identity)
                as GameObject;
            go.GetComponent<FireBullet>().ownwer = transform;
        }
    }
}
