using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    private double posX;
    private double posZ;
    void Start()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        for(;;)
        {
            System.Random rnd = new System.Random();
            int signX = rnd.NextDouble() < 0.5 ? -1 : 1;
            int signZ = rnd.NextDouble() < 0.5 ? -1 : 1;

            posX = signX * 7.5 * rnd.NextDouble();
            posZ = signZ * 7.5 * rnd.NextDouble();

            transform.position = new Vector3((float)posX, transform.position.y, (float)posZ);

            yield return new WaitForSeconds(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
