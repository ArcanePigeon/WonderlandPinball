using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    
    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates cuvbe
		transform.Rotate (new Vector3 (0, 0, 150) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Bunny")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Vector3 newScale = new Vector3(1.5f, 1.5f, 1.5f);
            bunny.transform.localScale = newScale;
        }
    }
}
