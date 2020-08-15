using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AsteroidSpawner : MonoBehaviour
{
    
    [SerializeField] private LevelState[] _levelStates;
    private float _delayTime;
    private int _asteroidCountToWin;
    private int _asteroidCurrentCollectedCount; 
    private int _asteroidsOnScreenMaxCount;
    [SerializeField] private GameObject _asteroidPrefab;

    private List<GameObject> _asteroidsOnBase = new List<GameObject>();
    private List<GameObject> _asteroidsOnScreen = new List<GameObject>();

    
    
    private void Start()
    {
        SetLevelState();
        
        for (int i = 0; i < _asteroidsOnScreenMaxCount; i++)
        {
            _asteroidsOnBase.Add( Instantiate(_asteroidPrefab, transform));
            _asteroidsOnBase[i].SetActive(false);
        }

        StartCoroutine(Spawner());
    }

    private void SetLevelState()
    {
        GameState gameState = Resources.Load<GameState>("SO_Instances/Game");
        int lastCompletedLevel = gameState.lastLevel;

        if(lastCompletedLevel >= _levelStates.Length)
            {
                lastCompletedLevel = 0;  // КОСТЫЛЬ
                gameState.lastLevel = lastCompletedLevel; // КОСТЫЛЬ
            }

        _delayTime = _levelStates[lastCompletedLevel].delayTime;
        _asteroidsOnScreenMaxCount = _levelStates[lastCompletedLevel].asteroidsOnScreenMaxCount;
        _asteroidCountToWin = _levelStates[lastCompletedLevel].asteroidCountToWin;

        FindObjectOfType<TaskPanel>().SetAsteroidTask(_asteroidCountToWin);        
    }

    

    IEnumerator Spawner()
    {
        GameObject nextAsteroid;
        while (true)
        {
            if(_asteroidsOnBase.Count >0)
            {
                nextAsteroid = _asteroidsOnBase[0];
                Vector3 newPosition = nextAsteroid.transform.position;
                ScreenSyze screenSyze = FindObjectOfType<ScreenSyze>();
                newPosition.x = Random.Range(screenSyze.GetScreenMin().x, screenSyze.GetScreenMax().x);
                nextAsteroid.transform.position = newPosition;
                nextAsteroid.SetActive(true);
                _asteroidsOnScreen.Add(nextAsteroid);
                _asteroidsOnBase.Remove(nextAsteroid);
                if(nextAsteroid.TryGetComponent<Health>(out Health health))
                {
                    health.ZeroHP.AddListener(ReturnToBase);
                    health.ZeroHP.AddListener(FindObjectOfType<TaskPanel>().OnAsteroidDied);
                }
                if(nextAsteroid.TryGetComponent<Asteroid>(out Asteroid asteroid))
                {
                    asteroid.OutOfScreen.AddListener(ReturnToBase);
                }                
            } 
            yield return new WaitForSeconds(_delayTime);
        }        
    }

    private void ReturnToBase(GameObject asteroid)
    {
        _asteroidsOnScreen.Remove(asteroid);
        _asteroidsOnBase.Add(asteroid);
        asteroid.transform.position = transform.position;
        if(asteroid.activeSelf)
            asteroid.SetActive(false);

        
    }

    public int GetAsteroidTask()
    {
        return _asteroidCountToWin; 
    }
}
