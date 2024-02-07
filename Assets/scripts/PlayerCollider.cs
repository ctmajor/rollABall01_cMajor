using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private ScreenScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScreenScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered 1" + other + ", " + other.gameObject.tag);
        if (other.gameObject.tag.Equals("Ball"))
        {
            Debug.Log("entered 2");
            logic.gameOver();
        }
    }
}
