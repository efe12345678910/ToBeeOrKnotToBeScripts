using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GradeCalculator : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _score;
    private void Awake()
    {
        _score = PointManager.GetCurrentPoints();
        _text = GetComponent<TextMeshProUGUI>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _text.text = $"Grade: {CalculateLetterGrade()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string CalculateLetterGrade()
    {
        if (_score >= 25000)
        {
            return "S";
        }
        else if (_score < 2500 && _score >= 15000)
        {
            return "A";
        }
        else if (_score < 15000 && _score >= 10000)
        {
            return "B";
        }
        else if (_score < 10000 && _score >= 8000)
        {
            return "C";
        }
        else if (_score < 8000 && _score >= 6000)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}
