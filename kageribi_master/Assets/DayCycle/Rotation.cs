using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [System.Serializable]
    public class RotationObject
    {
        public GameObject RotationTexture;
        public Vector3 Position;
        float texture_width;

        public void SetInitialPosition()
        {
            RotationTexture.gameObject.transform.position = new Vector3(Position.x, Position.y, Position.z);
        }

        public void ObtainWidth()
        {
            texture_width = RotationTexture.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        public void RotateTexture(float speed)
        {
            RotationTexture.transform.RotateAround(new Vector3(0.0f, -5.4f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), -speed * Time.deltaTime);

            RotationTexture.transform.Rotate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
        }
    }

    public float speed;

    public RotationObject Sun = new RotationObject();
    public RotationObject Moon = new RotationObject();

    // Start is called before the first frame update
    void Start()
    {
        Sun.SetInitialPosition();
        Moon.SetInitialPosition();

        Sun.ObtainWidth();
        Moon.ObtainWidth();
    }

    // Update is called once per frame
    void Update()
    {
        Sun.RotateTexture(speed);
        Moon.RotateTexture(speed);

        /*if (Sun.transform.position.x - (sun_width / 2) >= 9.6)
        {
            Moon.gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }*/
    }
}
