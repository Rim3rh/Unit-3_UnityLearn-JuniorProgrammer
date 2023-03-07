using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float _speed;
    private float _leftBoundarie = -15;

   



    private PlayerMovement _playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        
    }

    // Update is called once per frame
    void Update()
    {
       







        if (_playerMovementScript._preOver)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("naseh");
                _speed = 60;
            }
            else
            {
                _speed = 30;
            }

            if (!_playerMovementScript._gameOver)
            {
                transform.Translate(new Vector3(-1 * _speed, 0, 0) * Time.deltaTime);
            }
            if (transform.position.x < _leftBoundarie && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
        }




       

    }

   
}
