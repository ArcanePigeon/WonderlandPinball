using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    MeshRenderer renderer;
    private GameObject bunny;
    private Vector3[] cakePositionArray = new [] { new Vector3(7.59f,18.99f,2.31f), 
                                                   new Vector3(8.9f,26.48f,2.31f),
                                                   new Vector3(13.03f,30.66f,2.31f),
                                                   new Vector3(-1.12f,33.25f,2.31f),
                                                   new Vector3(-7.16f,24.78f,2.31f),
                                                   new Vector3(-6.05f,18.83f,2.31f),
                                                   new Vector3(.14f,15.63f,2.31f)
                                                   };
    
    private IEnumerator Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        bunny = GameObject.Find("Bunny");

        // hide cake on start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // cake will appear in a random position at a random point in time
        int randIndex = Random.Range(0, 7);
        Vector3 position = cakePositionArray[randIndex];
        yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));
        this.gameObject.transform.position = position;

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Before rendering each frame..
    void Update () 
	{
         //continuously rotates cake
		transform.Rotate(new Vector3 (0, 0, 150) * Time.deltaTime);
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Bunny")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Vector3 newScale = new Vector3(1.5f, 1.5f, 1.5f);
            bunny.transform.localScale = newScale;

            yield return new WaitForSeconds(5);
            bunny.transform.localScale = new Vector3(1f, 1f, 1f);

            // cake will appear in a random position at a random point in time
        int randIndex = Random.Range(0, 7);
        Vector3 position = cakePositionArray[randIndex];
            yield return new WaitForSeconds(Random.Range(6.0f, 15.0f));
            this.gameObject.transform.position = position;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
