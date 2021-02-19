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
    public GameObject newGameTextObject;

    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;
    public GameObject mirror1;
    public GameObject mirror2;

    // values for score calculation
    private int count;
    private int timePassed;
    private float startTime;

    // flag for game over
    private int gameOver = 0;

    // At the start of the game..
    void Start()
    {
        // Set game over flag to O, false
        gameOver = 0;
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set game over screen off 
        gameOverTextObject.SetActive(false);
        newGameTextObject.SetActive(false);

        // Set the count to zero, timePassed to 0, set start time
		count = 0;
        timePassed = 0;
        startTime = Time.time;
    }

    void Update()
    {
        // If the game is still running
        if (gameOver == 0)
        {
            // update the score based on time ( 1 second = 1 point)
            int timeCurr = (int)(Time.time - startTime);
            count = count + (timeCurr - timePassed);
            timePassed = timeCurr;
            // Run the 'SetCountText()' function (see below)
            SetCountText ();
        }

        if (Input.GetKeyDown("space"))
        {
            gameOverTextObject.SetActive(false);
            newGameTextObject.SetActive(false);
            gameOver = 0;
            // Set the count to zero, timePassed to 0, set start time
		    count = 0;
            timePassed = 0;
            Vector3 startBunnyPosition = new Vector3(-.13f, 43.41f, 3.1545f);
            rb.position = startBunnyPosition;
            startTime = Time.time;
        }
    }

    IEnumerator OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Finish")
        {
            // set game over flag to true, 1
            gameOver = 1;
            // Display Game over screen
            gameOverTextObject.SetActive(true);
            newGameTextObject.SetActive(true);
        }

        // if bunny collides with bonus object, increase score by 3
        if (myCollision.gameObject.tag == "Clock" ||
            myCollision.gameObject.tag == "Cake" ||
            myCollision.gameObject.tag == "Bottle") 
        {
            // Add 3 to the score variable 'count'
			count = count + 3;
            // Run the 'SetCountText()' function (see below)
			SetCountText ();
        }
        
        if (myCollision.gameObject.tag == "Clock")
        {
            Vector3 oldVel = rb.velocity;
            rb.velocity += transform.forward*80;
            yield return new WaitForSeconds(5f);
            rb.velocity = oldVel;
        }

        if (myCollision.gameObject.tag == "Mirror1")
        {
            // mirror 2 position
            Vector3 m2position = new Vector3(-10.45f, 31.19f, 1.95f);
            mirror2.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(.5f);
            rb.position = m2position;
            yield return new WaitForSeconds(4f);
            mirror2.GetComponent<BoxCollider>().enabled = true;

            // Add 3 to the score variable 'count'
			count = count + 3;
            // Run the 'SetCountText()' function (see below)
			SetCountText ();
        }

        if (myCollision.gameObject.tag == "Mirror2")
        {
            // mirror 1 position
            Vector3 m1position = new Vector3(10.39f, 38.89f, 2.39f);
            mirror1.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(.5f);
            rb.position = m1position;
            yield return new WaitForSeconds(4f);
            mirror1.GetComponent<BoxCollider>().enabled = true;

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
