using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [System.Serializable]
    public class RotationObject
    {
        public GameObject RotationTexture;
        Vector3 Position;
        float width, height;
        public bool is_draw;

        public void Start(GameObject Camera, float camera_width)
        {
            ObtainWidth();

            SetupInitialPosition(Camera, camera_width);

            SetPosition();
        }

        public bool isSearchObject(GameObject Camera, float camera_width)
        {
            if (RotationTexture.transform.position.x - (width / 2) + 0.1 < Camera.transform.position.x + (camera_width / 100))
            {
                return true;
            }

            return false;
        }

        void ObtainWidth()
        {
            width = RotationTexture.GetComponent<SpriteRenderer>().bounds.size.x;
            height = RotationTexture.GetComponent<SpriteRenderer>().bounds.size.y;
        }

        void SetupInitialPosition(GameObject Camera, float camera_width)
        {
            Position = new Vector3(
            Camera.transform.position.x - (camera_width / 100) - (width / 2),
            Camera.transform.position.y - 1.0f,
            0.0f);
        }

        public void SetPosition()
        {
            RotationTexture.transform.position = new Vector3(Position.x, Position.y, Position.z);
        }

        public void RotateTexture(float seconds)
        {
            RotationTexture.transform.RotateAround(new Vector3(0.0f, -10.6f - (height / 2), 0.0f), new Vector3(0.0f, 0.0f, 1.0f), 45.0f / -seconds * Time.deltaTime);

            RotationTexture.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f / seconds * Time.deltaTime));
        }
    }

    public float seconds;

    public RotationObject Sun = new RotationObject();
    public RotationObject Moon = new RotationObject();

    public GameObject Main;
    float camera_width, camera_height;

    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.Find("Main Camera");

        camera_width = Main.GetComponent<Camera>().pixelWidth;

        Sun.Start(Main, camera_width);
        Moon.Start(Main, camera_width);
    }

    // Update is called once per frame
    void Update()
    {
        if (Sun.is_draw == true)
        {
            Sun.RotateTexture(seconds);

            if (Sun.isSearchObject(Main, camera_width) == false)
            {
                Sun.SetPosition();
                Sun.is_draw = false;
                Moon.is_draw = true;
            }
        }
        else if (Moon.is_draw == true)
        {
            Moon.RotateTexture(seconds);

            if (Moon.isSearchObject(Main, camera_width) == false)
            {
                Moon.SetPosition();
                Moon.is_draw = false;
                Sun.is_draw = true;
            }
        }
    }
}
