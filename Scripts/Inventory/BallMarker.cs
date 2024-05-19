using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMarker : MonoBehaviour
{
    private void Awake()
    {
        isThereAMarkerActive.isAMarkerActive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,4,0);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 6.75)
        {
            transform.position = new Vector3(6, 4, 0);
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= -5.5)
        {
            transform.position = new Vector3(-5.5f, 4, 0);
        }
        //Debug.Log($"{transform.position}");
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            isThereAMarkerActive.isAMarkerActive=false;
        }
    }
    private void OnDestroy()
    {
        isThereAMarkerActive.isAMarkerActive = false;
    }
}
