using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 5;
    public Vector3 offset;
    public bool lockCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
        }

        

        Vector3 temp = transform.eulerAngles;
        if(temp.x > 180)
        {
            temp.x -= 360;
            print(temp.x);
        }
        temp.x = Mathf.Clamp(temp.x, -10, 80);
        transform.eulerAngles = temp;

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speed, Vector3.right) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;

        transform.position = player.position + offset;

        //transform.RotateAround(player.position, Vector3.left, Input.GetAxis("Mouse Y") * speed);
        Vector3 rotations = transform.localEulerAngles;
        rotations.z = 0;
        transform.localEulerAngles = rotations;
        transform.LookAt(player.position);
    }
}