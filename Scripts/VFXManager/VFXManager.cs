using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameObject[] _explosionFX;
    [SerializeField] GameObject[] _textFX;
    private static VFXManager _instance;
    public static VFXManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance= FindAnyObjectByType<VFXManager>();  
                
            }
            if (_instance == null)
            {
                _instance = new GameObject("VFXManager").AddComponent<VFXManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;

        }
    }
    private void Awake()
    {
        if(_instance != null &&_instance!=this)
        {
            Destroy(gameObject);
        }
    }
    public void CreateExplosionVFX(int index,Vector3 position)
    {      
            Instantiate(_explosionFX[index], position, Quaternion.identity);      
    }
    public void CreateTextVFX(string text, Vector3 position)
    {
        GameObject textObject =Instantiate(_textFX[0], position, Quaternion.identity);
        textObject.GetComponent<CFXR_ParticleText>().UpdateText(text);
    }
}
