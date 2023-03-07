using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerY : MonoBehaviour
{
    private Rigidbody _playerRb;
    private float _speed;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float _hMovement = Input.GetAxisRaw("Horizontal");
        float _vMovement = Input.GetAxisRaw("Vertical");
        _playerRb.AddForce(_hMovement * _speed, 0, 0);
        _playerRb.AddForce(0, 0, _vMovement * _speed);
    }
}
