using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    [SerializeField] GameObject _image;
    private PlayStartButtonSound _component;
    private void Awake()
    {
        _component = _image.GetComponent<PlayStartButtonSound>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlaySound()
    {
        _component.PlayStartSound();
    }
    public void StartGame()
    {
        StartCoroutine(StartGameCorout());
    }
    IEnumerator StartGameCorout()
    {
        PlaySound();
        yield return new WaitForSeconds(3);
        SceneManagerController.Instance.ChangeScene("level1");
    }
}
