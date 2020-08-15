using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskPanel : MonoBehaviour
{    
    [SerializeField] private Text _taskText; 
    private int _asteroidTask = -50;
    public UnityEvent LevelComplete = new UnityEvent();

    
    public void SetAsteroidTask(int taskCount)
    {
        if(_asteroidTask == -50)
            _asteroidTask = taskCount;

        _taskText.text = taskCount.ToString();
    }

    public void OnAsteroidDied(GameObject asteroid)
    {
        _asteroidTask --;
        SetAsteroidTask(_asteroidTask);
        
        if(_asteroidTask <= 0)
        {
            LevelComplete.Invoke();
        }
    }


}
