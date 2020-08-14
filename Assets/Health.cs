using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 10f;    
    public UnityEvent ZeroHP = new UnityEvent();   

    
    private void OnDisable() {
        ZeroHP.RemoveAllListeners();
    }
    
    public void Hit(int hitCount)
    {
        _health -= hitCount;
        if(_health <= 0f)
            ZeroHP.Invoke();
    }


}
