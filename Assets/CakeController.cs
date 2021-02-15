using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    Rigidbody renderer;
    private GameObject bunny;
    
    private void Start()
    {
        renderer = gameObject.GetComponent<Rigidbody>();
        bunny = GameObject.Find("Bunny");
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates cuvbe
		transform.Rotate (new Vector3 (0, 150, 0) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Bunny")
        {
            Destroy (gameObject.FindWithTag("cake"));
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            // Vector3 newScale = new Vector3(1.5f, 1.5f, 1.5f);
            // bunny.transform.localScale = newScale;
        }
    }
}
