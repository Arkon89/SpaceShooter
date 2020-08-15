using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    
    [SerializeField] private float _delayTime;
    [SerializeField] private int _asteroidCount; //count to win
    [SerializeField] private int _asteroidsOnScreenMaxCount;
    [SerializeField] private GameObject _asteroidPrefab;

    private List<GameObject> _asteroidsOnBase = new List<GameObject>();
    private List<GameObject> _asteroidsOnScreen = new List<GameObject>();
    
    private void Start()
    {
        
        for (int i = 0; i < _asteroidsOnScreenMaxCount; i++)
        {
            _asteroidsOnBase.Add( Instantiate(_asteroidPrefab, transform));
            _asteroidsOnBase[i].SetActive(false);
        }

        StartCoroutine(Spawner());
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
}
