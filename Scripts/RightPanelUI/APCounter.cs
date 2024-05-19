using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class APCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"AP: {RoundManager.Instance.GetPlayerAP()}";
    }
}
