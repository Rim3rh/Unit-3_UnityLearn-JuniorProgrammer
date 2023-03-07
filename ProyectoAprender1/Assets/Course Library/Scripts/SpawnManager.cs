using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25,1,0);

    private float _startDelay = 2, _repeatRate = 3;

    private PlayerMovement _playerMovementScript;
    void Start()
    {
        _playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!_playerMovementScript._gameOver)
        {
            int index = Random.Range(0, _obstaclePrefab.Length);
            Instantiate(_obstaclePrefab[index], _spawnPos, _obstaclePrefab[index].transform.rotation);
        }
        
    }
}
