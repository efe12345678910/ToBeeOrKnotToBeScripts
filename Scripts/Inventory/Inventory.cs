using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventory;
    [SerializeField] private GameObject _nextItemToCreate;
    [SerializeField] private GameObject _controlsPanel;
    private GameObject _currentMarker;
    public GameObject GetNextItemToCreate()
    {
        return _nextItemToCreate;
    }
    public List<GameObject> GetInventory()
    {
        return inventory;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //marker yaratır
    public void CreateItem1()
    {
        if (!isThereAMarkerActive.isAMarkerActive)
        {
            Destroy(_currentMarker);
            _currentMarker= Instantiate(inventory[0]);
            gameObject.SetActive(false);
        }
        
    }
    public void CreateCutMarker()
    {
        if (!IsThereACutMarkerActive.isACutMarkerActive)
        {
            Destroy(_currentMarker);
            _currentMarker = Instantiate(inventory[3]);
            gameObject.SetActive(false);
        }
    }
    public void SetNextItemToCreate(GameObject item)
    {
        _nextItemToCreate = item;
    }
    private void OnEnable()
    {
        _controlsPanel.SetActive(false);
    }
    private void OnDisable()
    {
        _controlsPanel.SetActive(true);
    }



}
