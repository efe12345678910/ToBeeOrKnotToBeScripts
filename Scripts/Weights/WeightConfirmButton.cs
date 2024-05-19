using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeightConfirmButton : MonoBehaviour
{
    [SerializeField] GameObject _weightObject;
    private Weight _weightComponent;
    [SerializeField] private GameObject _sliderKnot;
    private UnityEngine.UI.Slider _slider;
    private void Awake()
    {
        _slider = _sliderKnot.GetComponent<UnityEngine.UI.Slider>();
        _weightComponent = _weightObject.GetComponent<Weight>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetIsWeightSettingInProgToFalse()
    {
        IsWeightSettingInProgress.IsWeightSettingInProgressATM = false;
    }
    public void SetTimeForWeightBeforeFall()
    {
        _weightComponent.SetTimeBeforeFalling(_slider.value);
    }
}
