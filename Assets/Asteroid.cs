using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Hit(float hitCount)
    {
        _health -= hitCount;
        if(_health <= 0f)
            DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Debug.Log("Desrtroy Asteroid");
    }


}
