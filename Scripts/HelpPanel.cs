using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        IsThereAMenuActive.SetIsThereAMenuActive(true);
    }
    private void OnDisable()
    {
        IsThereAMenuActive.SetIsThereAMenuActive(false);

    }
}
