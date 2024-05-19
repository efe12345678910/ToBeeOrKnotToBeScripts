using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            PointManager.AddToCurrentPoints(-100);
            VFXManager.Instance.CreateTextVFX($"-100", new Vector3(transform.position.x-1,transform.position.y+1,0));
            SoundManager.Instance.PlaySound(0);
            //VFXManager.Instance.CreateExplosionVFX(1, new Vector3(transform.position.x,transform.position.y+2,0));
            Destroy(other.gameObject);
        }
    }
}
