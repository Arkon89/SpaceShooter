using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mediator : MonoBehaviour
{
    GameObject _gameOwerPanel, _levelCompletePanel;
    void Start()
    {
        if(FindObjectOfType<ShipMover>().TryGetComponent<Health>(out Health health))
        {
            health.ZeroHP.AddListener(OnPlayerDied);
        }
        FindObjectOfType<AsteroidSpawner>().LevelComplete.AddListener(OnLevelComplete);
        _gameOwerPanel = FindObjectOfType<LoosePanel>().gameObject;
        _gameOwerPanel.SetActive(false);
        _levelCompletePanel = FindObjectOfType<LevelCompletePanel>().gameObject;
        _levelCompletePanel.SetActive(false);
    }

    

    private void OnPlayerDied(GameObject died)
    {
        _gameOwerPanel.SetActive(true);
        _levelCompletePanel.SetActive(false);
        FindObjectOfType<ShipMover>().gameObject.SetActive(false);
    }

    private void OnLevelComplete()
    {
        GameState gameState = Resources.Load<GameState>("SO_Instances/Game");
        gameState.lastLevel += 1; 
        FindObjectOfType<AsteroidSpawner>().gameObject.SetActive(false);
        FindObjectOfType<ShipMover>().gameObject.SetActive(false);
        _levelCompletePanel.SetActive(true);
        _gameOwerPanel.SetActive(false);
    }
}
