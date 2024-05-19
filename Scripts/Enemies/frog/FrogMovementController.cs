using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovementController : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _movementSpeed =222f;
    private bool _alreadyMovedOnceThisTurn = false;
    private bool _alreadyMovedTwiceThisTurn= false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RoundManager.Instance.GetIsPlayersTurn())
        {
            _alreadyMovedOnceThisTurn=false;
            _alreadyMovedTwiceThisTurn = false;
        }
    }
    private void FixedUpdate()
    {
        if (!_alreadyMovedOnceThisTurn&& RoundManager.Instance.GetIsEnemysTurn())
        {
            _rigidBody2D.AddForce(new Vector2(2,1).normalized*Time.deltaTime*_movementSpeed,ForceMode2D.Impulse);
            _alreadyMovedOnceThisTurn=true;
        }
        if (_alreadyMovedOnceThisTurn && !_alreadyMovedTwiceThisTurn)
        {
            StartCoroutine(Wait1SecAndJumpAgain());
            _alreadyMovedTwiceThisTurn = true;

        }
    }
    IEnumerator Wait1SecAndJumpAgain()
    {
        yield return new WaitForSeconds(1.1f);
        _rigidBody2D.AddForce(new Vector2(2, 1).normalized * Time.deltaTime * _movementSpeed, ForceMode2D.Impulse);
    }
    
}
