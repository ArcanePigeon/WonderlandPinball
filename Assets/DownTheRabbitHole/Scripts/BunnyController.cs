using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class BunnyController : MonoBehaviour
{
    // Sound player and files.
    public AudioSource audioPlayer;
    public AudioClip bounceClip;
    public AudioClip mushroomHit;
    public AudioClip crystalHit;
    private AudioClip prioritySound;
    public AudioClip cakeHit;
    public AudioClip clockHit;
    public AudioClip bottleHit;
    public AudioClip mirrorHit;

    // Create public variables for for the Text UI game objects
	public TextMeshProUGUI countText;
	public GameObject gameOverTextObject;
    public GameObject newGameTextObject;

    // Adjust the drag for clock object to edit the slowness of bunny
    public float bunnyDrag;

    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;
    public GameObject mirror1;
    public GameObject mirror2;
    public GameObject bkgdMusic;

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
        switch(myCollision.gameObject.tag) 
        {
        case "Finish":
            // set game over flag to true, 1
            gameOver = 1;
            // Display Game over screen
            gameOverTextObject.SetActive(true);
            newGameTextObject.SetActive(true);
            break;
        case "Bottle":
            IncreaseItemCount();
            PlaySound(bottleHit);
            break;
        case "Cake":
            IncreaseItemCount();
            PlaySound(cakeHit);
            break;
        case "Clock":
            // add drag on bunny ball for 5 seconds to create slowness
            IncreaseItemCount();
            PlaySound(clockHit);
            Time.timeScale = 0.6f;
            AudioSource backgroundMusic = bkgdMusic.GetComponent<AudioSource>();
            backgroundMusic.pitch = .5f;
            yield return new WaitForSeconds(5f);
            backgroundMusic.pitch = 1f;
            Time.timeScale = 1.0f;
            break;
        case "Mirror1":
            IncreaseItemCount();
            PlaySound(mirrorHit);
            // mirror 2 position
            Vector3 m2position = new Vector3(-10.45f, 31.19f, 1.95f);
            mirror2.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(.5f);
            rb.position = m2position;
            PlaySound(mirrorHit);
            yield return new WaitForSeconds(4f);
            mirror2.GetComponent<BoxCollider>().enabled = true;
            break;
        case "Mirror2":
            IncreaseItemCount();
            PlaySound(mirrorHit);
            // mirror 1 position
            Vector3 m1position = new Vector3(10.39f, 38.89f, 2.39f);
            mirror1.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(.5f);
            rb.position = m1position;
            PlaySound(mirrorHit);
            yield return new WaitForSeconds(4f);
            mirror1.GetComponent<BoxCollider>().enabled = true;
            break;
        case "Mushroom":
            PlaySound(mushroomHit);
            break;
        case "Crystal":
            PlaySound(crystalHit);
            break;        
        default:
            PlaySound(bounceClip);
            break;
        }
    }

    void PlaySound(AudioClip prioritySound)
    {
        audioPlayer.PlayOneShot(prioritySound);
        audioPlayer.SetScheduledEndTime(AudioSettings.dspTime+(1));        
    }

    void SetCountText()
	{
		countText.text = "Score: " + count.ToString();
    }

    void IncreaseItemCount()
    {
        // Add 3 to the score variable 'count'
        count = count + 3;
        // Run the 'SetCountText()' function (see below)
        SetCountText();
    }
}
