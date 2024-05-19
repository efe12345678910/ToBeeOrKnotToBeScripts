using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutOnlyPointModDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _cutOnlyKnot;
    private CutOnlyKnot _cutOnlyKnotComponent;
    private void Awake()
    {
        _cutOnlyKnotComponent = _cutOnlyKnot.GetComponent<CutOnlyKnot>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        _text.text = $"X{_cutOnlyKnotComponent.GetPointMod()}";

    }
}
