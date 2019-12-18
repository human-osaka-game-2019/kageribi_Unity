using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera Main_camera;//カメラを格納する変数。
    [SerializeField] GameObject Main_Camera_Move;//カメラの移動に関するあれこれをやるためにGameObjectとしてカメラを格納する。
    public GameObject Player;
    public GameObject PlayerCollider;

    [SerializeField, Range(0.1f, 10.0f)] float Camera_aspet;//カメラのアスペクトの量を変更できるようにしたもの。

    bool move_side;
    bool move_height;
    bool size;
    bool camera_return;
    void Start()
    {

        Main_camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move_side != false)
        {
            if (Main_Camera_Move.transform.position.x > 55f)
            {
                move_side = true;
            }
            else
            {
                //Main_camera.orthographicSize += Camera_aspet;
                Main_Camera_Move.transform.Translate(0.1f, 0, 0);
            }
        }
        if (move_height != false)
        {
            if (Main_Camera_Move.transform.position.y > 5f)
            {
                move_height = true;
            }
            else
            {
                Main_Camera_Move.transform.Translate(0, 0.1f, 0);
            }
        }

        if (size != false)
        {
            if (Main_camera.orthographicSize >= 10)
            {
                size = true;
            }
            else
            {
                Main_camera.orthographicSize += 0.1f;

            }
        }

        if (camera_return == true)
        {
            if (Main_Camera_Move.transform.position.x <= Player.transform.position.x)
            {
                Main_Camera_Move.transform.Translate(0.1f, 0, 0);
            }
            if (Main_Camera_Move.transform.position.x >= Player.transform.position.x)
            {
                Main_Camera_Move.transform.Translate(-0.1f, 0, 0);
            }

            if (Main_Camera_Move.transform.position.y <= Player.transform.position.y + 3)
            {
                Main_Camera_Move.transform.Translate(0, 0.1f, 0);
            }
            if (Main_Camera_Move.transform.position.y >= Player.transform.position.y + 3)
            {
                Main_Camera_Move.transform.Translate(0, -0.1f, 0);
            }

            if (Main_camera.orthographicSize >= 5)
            {
                Main_camera.orthographicSize -= 0.1f;
            }
            Main_camera.transform.parent = Player.transform;
            PlayerCollider.SetActive(false);

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move_side = true;
            move_height = true;
            size = true;
            Main_camera.transform.parent = null;
            PlayerCollider.SetActive(true);
        }
    }

    public void CameraReturn()
    {
        camera_return = true;
    }
}