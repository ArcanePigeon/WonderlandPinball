using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    
    private IEnumerator Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");

        // hide bottle on start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // bottle will appear in a random position at a random point in time
        Vector3 position = new Vector3(Random.Range(-6.0f, 8.0f), Random.Range(15.0f, 24.0f), 2.31f);
        yield return new WaitForSeconds(Random.Range(3.0f, 20.0f));
        this.gameObject.transform.position = position;

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates bottle
		transform.Rotate (new Vector3 (0, 150, 0) * Time.deltaTime, Space.World);
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Bunny")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Vector3 newScale = new Vector3(.75f, .75f, .75f);
            bunny.transform.localScale = newScale;

            yield return new WaitForSeconds(5.0f);
            bunny.transform.localScale = new Vector3(1f, 1f, 1f);

            // bottle will appear in a random position at a random point in time
            Vector3 position = new Vector3(Random.Range(-6.0f, 8.0f), Random.Range(15.0f, 24.0f), 2.31f);
            yield return new WaitForSeconds(Random.Range(6.0f, 15.0f));
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
