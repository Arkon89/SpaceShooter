using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSyze : MonoBehaviour
{
    private Vector3 _screenMin, _screenMax;
    private float _zOffset = 2f;
     
    void Start()
    {
        _screenMin = Camera.main.ViewportToWorldPoint(new Vector2(0f,0f));
        _screenMax = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f));        
    }

    public bool CheckPlayerPosition(Vector3 position)
    {
        if(position.x > _screenMin.x &&
            position.x < _screenMax.x &&
                position.z > _screenMin.z &&
                    position.z < _screenMax.z)
                    return true;
                            else 
                            return false;
    }

    public bool CheckPosition(Vector3 position)
    {
        if(position.x > _screenMin.x &&
            position.x < _screenMax.x &&                
                position.z > _screenMin.z - _zOffset &&
                    position.z < _screenMax.z + _zOffset)
                    return true;
                            else 
                            return false;
    }

    public Vector3 GetScreenMin()
    {
        return _screenMin;
    }
    public Vector3 GetScreenMax()
    {
        return _screenMax;
    }
}
