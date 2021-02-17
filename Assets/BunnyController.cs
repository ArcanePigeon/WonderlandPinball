using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{

    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Clock")
        {
            // increase ball speed for 5 seconds
            // rb.velocity = new Vector3(30f, 30f, 0f);
        }

        if (myCollision.gameObject.tag == "Mirror1")
        {
            // mirror 2 position
            Vector3 m2position = new Vector3(-5f, 28.28f, 3.14f);
            rb.position = m2position;
            yield return new WaitForSeconds(1f);
        }

        if (myCollision.gameObject.tag == "Mirror2")
        {
            // mirror 1 position
            Vector3 m1position = new Vector3(6f, 28.39f, 3.14f);
            rb.position = m1position;
            yield return new WaitForSeconds(1f);
        }
    }
}
