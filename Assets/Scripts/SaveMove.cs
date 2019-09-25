using System.Collections;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

public class SaveMove : MonoBehaviour
{
    [DllImport("SAVER.dll")]
    static extern void SavePosition(float px, float py, float pz);
    [DllImport("SAVER.dll")]
    static extern void RequestPosition();
    [DllImport("SAVER.dll")]
    static extern void SetupRecieve(Action<float, float, float> action);


    public Transform playerTransform;
    public Rigidbody playerBody;

    static public Vector3 pos = new Vector3(0,0,0);
    static public bool update = false;
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.GetComponent<Transform>();
        playerBody = this.GetComponent<Rigidbody>();
        SetupRecieve(RecievePosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            playerBody.velocity += new Vector3(1 * -moveSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerBody.velocity += new Vector3(1 * moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerBody.velocity += new Vector3(0, 0,1 * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerBody.velocity += new Vector3(0,0,1 * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RequestPosition();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavePosition(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z );
        }

        if (update) {
            playerTransform.localPosition = pos;
            update = false;
        }
    }

    static void RecievePosition(float px, float py, float pz) {
        Debug.Log(px.ToString());
        Debug.Log(py.ToString());
        Debug.Log(pz.ToString());
        pos = new Vector3(px, py, pz);
        update = true;
        
    }
}
