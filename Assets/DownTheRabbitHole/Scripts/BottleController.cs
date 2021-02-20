using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    private Vector3[] bottlePositionArray = new [] {
        new Vector3(5.31f,18.3f,3.01f),
        new Vector3(6.9f,28.48f,3.01f),
        new Vector3(11.39f,32.6f,3.01f),
        new Vector3(.67f,30.45f,3.01f),
        new Vector3(-10.54f,24.23f,3.01f),
        new Vector3(-9.7f,16.57f,3.01f),
        new Vector3(.34f,21.26f,3.01f),
    };
    private IEnumerator Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");

        // hide bottle on start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // bottle will appear in a random position at a random point in time
        int randIndex = Random.Range(0, 7);
        Vector3 position = bottlePositionArray[randIndex];
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
            int randIndex = Random.Range(0, 7);
            Vector3 position = bottlePositionArray[randIndex];
            yield return new WaitForSeconds(Random.Range(6.0f, 15.0f));
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
