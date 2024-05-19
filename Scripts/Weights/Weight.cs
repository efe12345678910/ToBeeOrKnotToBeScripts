using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbodyWeight;
    private float _timeBeforeFalling;
    private AudioSource _audioSource;
    private bool _isfalling = false;
    private bool _isSoundPlaying=false;
    private void Awake()
    {
        _rigidbodyWeight = GetComponent<Rigidbody2D>();
        _rigidbodyWeight.gravityScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundManager.Instance.GetIsEnemysTurn())
        {
            StartCoroutine(StaySteadyForATime());
        }
        if(_isfalling)
        {
            if (!_isSoundPlaying)
            {
                _audioSource.Play();
                _isSoundPlaying = true;

            }

        }
    }
    public void SetTimeBeforeFalling(float number)
    {
        _timeBeforeFalling = number;
    }
    IEnumerator StaySteadyForATime()
    {
        yield return new WaitForSeconds(_timeBeforeFalling);
        _isfalling = true;
        _rigidbodyWeight.gravityScale = 1;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            PointManager.AddToCurrentPoints((int)(other.GetComponent<Enemy>().GetPoints() * Mathf.Round(_timeBeforeFalling*2)));
            int enemyPoints = other.GetComponent<Enemy>().GetPoints();
            VFXManager.Instance.CreateTextVFX($"{Mathf.Round(_timeBeforeFalling*2)}X{enemyPoints}", transform.position);
            SoundManager.Instance.PlaySound(1);
            Destroy(other.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
