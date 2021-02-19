using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    private Vector3[] clockPositionArray = new [] { new Vector3(6.87f,22.02f,3.16f), 
                                                   new Vector3(4.64f,28.03f,3.16f),
                                                   new Vector3(12.31f,28.88f,3.16f),
                                                   new Vector3(2.87f,33.84f,3.16f),
                                                   new Vector3(-8.92f,27.62f,3.16f),
                                                   new Vector3(-4.87f,22.04f,3.16f),
                                                   new Vector3(-.55f,18.85f,3.16f)
                                                   };
    
    private IEnumerator Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");

        // hide clock on start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // clock will appear in a random position at a random point in time
        int randIndex = Random.Range(0, 7);
        Vector3 position = clockPositionArray[randIndex];
        yield return new WaitForSeconds(Random.Range(5.0f, 25.0f));
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

            // clock will appear in a random position at a random point in time
            int randIndex = Random.Range(0, 7);
            Vector3 position = clockPositionArray[randIndex];
            yield return new WaitForSeconds(Random.Range(7.0f, 32.0f));
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
