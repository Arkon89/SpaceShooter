using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour
{    
    [SerializeField] protected int _speed;
    private ScreenSyze _screenSize;
    protected Rigidbody _rigidbody;
    public UnityEventGameObject OutOfScreen = new UnityEventGameObject();
    
    protected virtual void OnEnable() {
        if(!_rigidbody)
            _rigidbody = GetComponent<Rigidbody>();
        _screenSize = FindObjectOfType<ScreenSyze>();             
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();              
    }


    void FixedUpdate()
    {
        if(_screenSize.CheckPosition(transform.position))
        {
            _rigidbody.velocity = transform.forward * _speed * Time.deltaTime;
            _rigidbody.rotation *= Quaternion.Euler(transform.forward * _speed * Time.deltaTime);
        }
        else
        {
            OutOfScreen.Invoke(gameObject);
        }                
    }

    private void OnDisable() {
        OutOfScreen.RemoveAllListeners();
    }
}
