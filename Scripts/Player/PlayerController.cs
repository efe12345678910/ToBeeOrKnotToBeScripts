using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _inventoryPanel;  
    private static PlayerController _instance;
    private Vector3 _mousePosition;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PlayerController>();
                if(_instance != null)
                {
                    _instance= new GameObject("PlayerController").AddComponent<PlayerController>();
                    DontDestroyOnLoad( _instance );
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if ( _instance != null && _instance !=this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_inventoryPanel.activeSelf)
            {
                _inventoryPanel.SetActive(false);

            }
            else
            {
                _inventoryPanel.SetActive(true);
            }
        }
        CreateAWeight();
        if(Input.GetKeyDown(KeyCode.Space) && RoundManager.Instance.GetIsPlayersTurn() && !IsThereAMenuActive.GetIsThereAMenuActive())
        {
            RoundManager.Instance.SetEnemysTurn();
        }
    }
    void CreateAWeight()
    {
        if (isThereAMarkerActive.isAMarkerActive&&!_inventoryPanel.activeSelf)
        {
            if(Input.GetMouseButtonDown(0) && !IsWeightSettingInProgress.IsWeightSettingInProgressATM && RoundManager.Instance.GetIsPlayersTurn()&&_mousePosition.x<6&&_mousePosition.x>-5.5&&!IsThereAMenuActive.GetIsThereAMenuActive())
            {
                //yeterli AP varsa
                if (RoundManager.Instance.GetPlayerAP() > 0)
                {
                    Instantiate(_inventory.GetNextItemToCreate(), new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 4, 0)
                    , Quaternion.identity);
                    //bi ara switch case e cevir buraları
                    //Timed Knot
                    if (_inventory.GetNextItemToCreate() == _inventory.GetInventory()[1])
                    {
                        IsWeightSettingInProgress.IsWeightSettingInProgressATM = true;
                        RoundManager.Instance.ChangePlayerAP(-1);
                    }
                    //Cut only knot
                    else if (_inventory.GetNextItemToCreate() == _inventory.GetInventory()[2])
                    {
                        RoundManager.Instance.ChangePlayerAP(-1);
                    }
                    else if (_inventory.GetNextItemToCreate() == _inventory.GetInventory()[3])
                    {
                        IsWeightSettingInProgress.IsWeightSettingInProgressATM = true;
                        RoundManager.Instance.ChangePlayerAP(-1);
                    }
                }
                //yeterli AP yok
                else
                {

                }
                


            }
        }
    }
}
