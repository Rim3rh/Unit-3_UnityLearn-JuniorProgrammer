using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;
    public GameObject _point1, _point2;


    // Start is called before the first frame update
    void Start()
    {

        gameOver = false;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > _point1.transform.position.y)
        {
            transform.position = new Vector3(0,_point1.transform.position.y,0);
            playerRb.velocity = Vector3.zero;
        }


        if (transform.position.y < _point2.transform.position.y)
        {
            // transform.position = new Vector3(0, _point2.transform.position.y, 0);
            //   playerRb.velocity = Vector3.zero;
            if (!gameOver)
            {
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                playerRb.velocity = Vector3.zero;
                playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }
         
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
