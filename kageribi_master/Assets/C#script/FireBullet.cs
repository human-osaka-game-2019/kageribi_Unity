using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FIREBULLET
{
    ANGLE,
    HOMING,
    HOMING_Z,
}

public class FireBullet : MonoBehaviour
{
    public FIREBULLET fireType = FIREBULLET.HOMING;

    public float attackDamage = 1;
    public Vector2 attackNockBackVector;

    public bool penetration = false;

    public float lifeTime = 3.0f;
    public float speedV = 10.0f;
    public float speedA = 0.0f;
    public float angle = 0.0f;

    public float homingTime = 0.0f;
    public float homingAngleV = 180.0f;
    public float homingAngleA = 20.0f;

    public Vector3 BulletScaleV = Vector3.zero;
    public Vector3 BulletScaleA = Vector3.zero;

    public Sprite hiteSprite;
    public Vector3 hitEffectScale = Vector3.one;
    public float rotateVt = 360.0f;

    [System.NonSerialized] public Transform ownwer;
    [System.NonSerialized] public GameObject targetObject;
    [System.NonSerialized] public bool attackEnabled;

    float fireTime;
    Vector3 posTarget;
    float homingAngle;
    Quaternion homingRotate;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (!ownwer)
        {
            return;
        }

        targetObject = .GetGameObject();
        posTarget = targetObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
