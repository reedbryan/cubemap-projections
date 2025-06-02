using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnv : MonoBehaviour
{
    public Transform envTransform;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            envTransform.position += Vector3.forward * Time.deltaTime * moveSpeed; // move forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            envTransform.position += Vector3.back * Time.deltaTime * moveSpeed; // move backward
        }
        if (Input.GetKey(KeyCode.A))
        {
            envTransform.position += Vector3.left * Time.deltaTime * moveSpeed; // move left
        }
        if (Input.GetKey(KeyCode.D))
        {
            envTransform.position += Vector3.right * Time.deltaTime * moveSpeed; // move right
        }
    }
}
