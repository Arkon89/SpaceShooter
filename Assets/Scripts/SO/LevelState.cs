using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelState : ScriptableObject
{
    public int number;
    public bool isOpened;
    public bool isCompleted;
    public float delayTime;
    public int asteroidCountToWin; //count to win
    public int asteroidsOnScreenMaxCount;

}
