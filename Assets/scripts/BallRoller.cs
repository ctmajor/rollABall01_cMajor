using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallRoller : MonoBehaviour
{
    public float speed;
    private float r = 8f;
    private float x;
    private float z;
    private float theta = 0f;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        // Increment theta but keep it below 2pi
        theta += 0.05f * speed * Time.deltaTime;
        if (theta > 2f * Mathf.PI)
        {
            theta -= 2f * Mathf.PI;
        }

        // Change r but keep it between -8 and 8
        r += 0.0001f * speed * direction;
        if (Mathf.Abs(r) > 8f)
        {
            r = 8f * direction;
            direction *= -1;
        }

        x = r * Mathf.Cos(theta);
        z = r * Mathf.Sin(theta);

        transform.position = new Vector3(x, 0.5f, z);
    }
}
