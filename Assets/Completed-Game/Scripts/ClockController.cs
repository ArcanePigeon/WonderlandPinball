using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{

    MeshRenderer renderer;
    private GameObject ball;
    
    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        ball = GameObject.Find("Ball");
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates cuvbe
		transform.Rotate (new Vector3 (0, 150, 0) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Ball")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            rb.AddForce(movement * 100);
            
        }
    }
}
