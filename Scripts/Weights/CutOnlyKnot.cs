using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CutOnlyKnot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool _knotStillTied = true;
    private bool _gravityAlreadyHasBeenChanged=false;
    private float _pointModifier;
    private AudioSource _audioSource;
    private bool _isSoundPlaying = false;
    private void Awake()
    {
        _pointModifier = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gravityAlreadyHasBeenChanged && !_knotStillTied)
        {
            rb.gravityScale = 1;
            _gravityAlreadyHasBeenChanged = true;
            if(!_isSoundPlaying)
            {
                _audioSource.Play();
                _isSoundPlaying = true;
            }

        }
    }
    private void OnEnable()
    {
        RaisePointModForCutOnly.RaisePointModForCut += IncreasePointModifier;
    }
    private void OnDisable()
    {
        RaisePointModForCutOnly.RaisePointModForCut -= IncreasePointModifier;

    }
    public void IncreasePointModifier()
    {
        _pointModifier += 1 ;
        Debug.Log($"{_pointModifier}");
    }
    public float GetPointMod()
    {
        return _pointModifier;
    }
    private void OnMouseOver()
    {
        if(IsThereACutMarkerActive.isACutMarkerActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                _knotStillTied = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            PointManager.AddToCurrentPoints((int)(other.GetComponent<Enemy>().GetPoints()*_pointModifier));
            int enemyPoints = other.GetComponent<Enemy>().GetPoints();
            VFXManager.Instance.CreateTextVFX($"{_pointModifier}X{enemyPoints}", transform.position);
            SoundManager.Instance.PlaySound(2);

            Destroy(other.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
