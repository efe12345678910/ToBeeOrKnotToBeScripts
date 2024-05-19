using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class RoundManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _levelEnded;
    [SerializeField] private UnityEvent PlayersTurnStarted;
    [SerializeField] private UnityEvent EnemysTurnStarted;
    private bool _isPlayersTurn = true;
    private bool _isEnemysTurn = false;
    public bool EnemiesCanMove = false;
    private bool _isPlayEnemyTurnAlreadyActive = false;
    private static RoundManager _instance;
    private int _playerStartingAP=1;
    private int _playerCurrentAP;
    [SerializeField] private int _currentTurn =0;
    private int _maxTurns =20;
    private bool _isGameOver = false;
    
    public static RoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance= FindAnyObjectByType<RoundManager>();
            }
            if(_instance == null)
            {
                _instance = new GameObject("RoundManager").AddComponent<RoundManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    private void Start()
    {
        SetPlayersTurn();
    }
    private void Awake()
    {
        _isGameOver = false;
        if(_instance != null && _instance!=this) { Destroy(gameObject); }
        _currentTurn = 0;
        _playerCurrentAP = _playerStartingAP;
    }
    IEnumerator EnemyPlaysTurn()
    {
        _isPlayEnemyTurnAlreadyActive=true;
        EnemiesCanMove=true;
        yield return new WaitForSeconds(3);
        EnemiesCanMove=false;
        _isPlayEnemyTurnAlreadyActive = false;
        SetPlayersTurn();
    }
    private void Update()
    {
        if (_isEnemysTurn && !_isPlayEnemyTurnAlreadyActive)
        {
            StartCoroutine(EnemyPlaysTurn());
        }
        if(_currentTurn>_maxTurns)
        {
            _levelEnded.Invoke();
        }
    }
    public bool GetIsPlayersTurn()
    {
        return _isPlayersTurn;
    }
    public bool GetIsEnemysTurn()
    {
        return _isEnemysTurn;
    }
    public void SetEnemysTurn()
    {
        _isEnemysTurn = true;
        _isPlayersTurn = false;
        if (EnemysTurnStarted != null)
        {
            EnemysTurnStarted.Invoke();
        }
    }
    public void SetPlayersTurn()
    {
        _isPlayersTurn=true;
        _isEnemysTurn=false;
        if(PlayersTurnStarted != null)
        {
            PlayersTurnStarted.Invoke();
            NextTurn();
            ResetSpawnPointsEveryTurn.OnResetSpawnPoints();
            IsWeightSettingInProgress.IsWeightSettingInProgressATM = false;
        }
    }
    public void ChangePlayerAP(int amount)
    {
        _playerCurrentAP += amount;
    }
    public int GetPlayerAP()
    {
        return _playerCurrentAP;
    }
    public void ResetTurnNumber()
    {
        _currentTurn = 1;
    }
    public int GetTurnNumber()
    {
        return _currentTurn;
    }
    public void NextTurn()
    {
        _currentTurn++;
        _playerCurrentAP += 2;
        RaisePointModForCutOnly.OnRaisePointModForCut();
    }
    public int GetMaxTurns()
    {
        return _maxTurns;
    }
    public void GoToEndingScreen()
    {
        StartCoroutine(StartEndingProgress());
    }
    IEnumerator StartEndingProgress()
    {
        DisableAllAnimals();
        yield return new WaitForSeconds(2);
        SceneManagerController.Instance.ChangeScene("LevelCompleted");


    }
    public void DisableAllAnimals()
    {
        GameObject[] stillActiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in  stillActiveEnemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(false);
            }
        }

    }
    public void SetIsGameOver(bool value)
    {
        _isGameOver = value;
    }
    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
    
    
    
    
}
