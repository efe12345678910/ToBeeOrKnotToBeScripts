using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _movementSpeed = 222f;
    private bool _alreadyMovedThisTurn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RoundManager.Instance.GetIsPlayersTurn())
        {
            _alreadyMovedThisTurn = false;
        }
    }
    private void FixedUpdate()
    {
        if (!_alreadyMovedThisTurn && RoundManager.Instance.GetIsEnemysTurn())
        {
            _rigidBody2D.AddForce(Vector2.right * Time.deltaTime * _movementSpeed, ForceMode2D.Impulse);
            _alreadyMovedThisTurn = true;
        }
    }
}
