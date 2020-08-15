using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{    
    [SerializeField] private Text _taskText; 
    private int _asteroidTask = -50;

    
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
    }


}
