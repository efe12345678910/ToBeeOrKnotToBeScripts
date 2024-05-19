using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutMarker : MonoBehaviour
{
    private void Awake()
    {
        IsThereACutMarkerActive.isACutMarkerActive = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 6.75)
        {
            transform.position = new Vector3(6, 4, 0);
        }
        //Debug.Log($"{transform.position}");
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            IsThereACutMarkerActive.isACutMarkerActive = false;
        }
    }
    private void OnDestroy()
    {
        IsThereACutMarkerActive.isACutMarkerActive= false;
    }
}
