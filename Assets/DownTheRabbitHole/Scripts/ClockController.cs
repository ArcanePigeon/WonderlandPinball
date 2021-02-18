using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    
    private IEnumerator Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");

        // hide cake on start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // cake will appear in a random position at a random point in time
        Vector3 position = new Vector3(Random.Range(-6.0f, 8.0f), Random.Range(15.0f, 24.0f), 2.31f);
        yield return new WaitForSeconds(Random.Range(8.0f, 45.0f));
        this.gameObject.transform.position = position;

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates clock
		transform.Rotate (new Vector3 (0, 150, 0) * Time.deltaTime);
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Bunny")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            // need to edit speed here -- maybe in bunny controller

            // cake will appear in a random position at a random point in time
            Vector3 position = new Vector3(Random.Range(-6.0f, 8.0f), Random.Range(15.0f, 24.0f), 2.31f);
            yield return new WaitForSeconds(Random.Range(7.0f, 32.0f));
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
