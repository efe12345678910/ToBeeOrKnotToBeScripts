using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _movementSpeed =85f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (RoundManager.Instance.GetIsEnemysTurn()) 
        {
            _rigidBody2D.velocity = Vector2.right * Time.deltaTime * _movementSpeed;
        }
    }
}
