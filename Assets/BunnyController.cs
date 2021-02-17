using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class BunnyController : MonoBehaviour
{

    // Create public variables for for the Text UI game objects
	public TextMeshProUGUI countText;
	public GameObject gameOverTextObject;

    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;

    private int count;
    private int timePassed;
    private float startTime;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
		count = 0;
        timePassed = 0;

        startTime = Time.time;
    }

      void Update()
    {
        int timeCurr = (int)(Time.time - startTime);
        count = count + (timeCurr - timePassed);
        timePassed = timeCurr;
        // Run the 'SetCountText()' function (see below)
		SetCountText ();
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Clock")
        {
            // increase ball speed for 5 seconds
            // rb.velocity = new Vector3(30f, 30f, 0f);

            // Add 3 to the score variable 'count'
			count = count + 3;
            // Run the 'SetCountText()' function (see below)
			SetCountText ();
        }

        if (myCollision.gameObject.tag == "Mirror1")
        {
            // mirror 2 position
            Vector3 m2position = new Vector3(-5f, 28.28f, 3.14f);
            rb.position = m2position;
            yield return new WaitForSeconds(1f);

            // Add 3 to the score variable 'count'
			count = count + 3;
            // Run the 'SetCountText()' function (see below)
			SetCountText ();
        }

        if (myCollision.gameObject.tag == "Mirror2")
        {
            // mirror 1 position
            Vector3 m1position = new Vector3(6f, 28.39f, 3.14f);
            rb.position = m1position;
            yield return new WaitForSeconds(1f);

            // Add 3 to the score variable 'count'
			count = count + 3;
            // Run the 'SetCountText()' function (see below)
			SetCountText ();
        }
    }

    void SetCountText()
	{
		countText.text = "Score: " + count.ToString();
    }
}
