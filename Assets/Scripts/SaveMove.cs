using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System;
using System.Collections.Generic;

public class SaveMove : MonoBehaviour
{
    [DllImport("CNET.dll")]
    static extern void SavePosition(float px, float py, float pz);
    [DllImport("CNET.dll")]
    static extern void GetPosition(Action<float, float, float> action);

    private Transform playerTransform;
    private Rigidbody playerBody;

    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.GetComponent<Transform>();
        playerBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            playerBody.velocity += new Vector3(1 * -moveSpeed,0,0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerBody.velocity += new Vector3(1 * moveSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerBody.velocity += new Vector3(0, 0,1 * -moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerBody.velocity += new Vector3(0,0,-1 * moveSpeed);
        }

    }

    void RecievePosition(float px, float py, float pz) {

    }
}
