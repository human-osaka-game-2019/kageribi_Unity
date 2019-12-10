using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Right : MonoBehaviour
{
    public float speed;
    public float Counts;
    public float MaxCount;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0.0f, 0.0f);
        Counts += Time.deltaTime;
        if (MaxCount <= Counts)
        {
            Destroy(this.gameObject);
        }

    }
}
