using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool _preOver;


    public GameObject _scoreManager;
    private Rigidbody _playerRb;
    private Animator _anim;
    private AudioSource _playerAudio;
    public ParticleSystem _explosionParticle, _dirtParticle;
    public AudioClip _jumpSound, _crashSound;

    public float _jumpForce = 10;

    public float _gravityModifier;

    public bool _isGrounded = true;
    public bool _gameOver;

    
    bool jumpCont;
    
    void Start()
    {
        _preOver = false;
        
        _anim = GetComponent<Animator>(); 
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

         if(!_preOver)
        {

            _playerRb.transform.Translate(0, 0, 0.2f);
        }



        if (_preOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
       
    }


    private void Jump()
    {
        
        if (_isGrounded && !_gameOver)
        {
            _anim.SetTrigger("Jump_trig");
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _playerAudio.PlayOneShot(_jumpSound, 1.0f);
            jumpCont = false;
        }else if (Input.GetKeyDown(KeyCode.Space) && !_gameOver && !_isGrounded && !jumpCont )
        {
            _playerRb.velocity = Vector3.zero;
            _anim.Play("Running_Jump", 3, 0f);
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _playerAudio.PlayOneShot(_jumpSound, 1.0f);
            jumpCont = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_preOver)
        {
            if (collision.gameObject.CompareTag("Ground") && !_gameOver)
            {
                _isGrounded = true;
                _dirtParticle.Play();
            }
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                _dirtParticle.Stop();
                _playerAudio.PlayOneShot(_crashSound, 1.0f);
                _explosionParticle.Play();
                _gameOver = true;
                _anim.SetBool("Death_b", true);
                _anim.SetInteger("DeathType_int", 1);


            }
        }


     


    }


    private void OnCollisionExit(Collision collision)
    {

        if (_preOver)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;

                _dirtParticle.Stop();
            }
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_preOver)
        {
            if (other.CompareTag("Score"))
            {
                _scoreManager.GetComponent<ScoreManager>()._score++;


            }
        }

        if (other.CompareTag("Start"))
        {
            _preOver = true;


        }

    }

}
