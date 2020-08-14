using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Rigidbody _rigidbody;
    private Vector3 _basePosition; 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _basePosition = transform.position;        
    }

    private void OnEnable() {
        if(!_rigidbody)
            _rigidbody = GetComponent<Rigidbody>();

        if(TryGetComponent<Health>(out Health health))
        {
            health.ZeroHP.AddListener(DestroyAsteroid);
        }     
    }

    private void OnDisable() {
        _rigidbody.velocity = Vector3.zero;
        transform.position = _basePosition;
    }

    

    private void DestroyAsteroid()
    {
        Debug.Log("Desrtroy Asteroid");
        this.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        _rigidbody.velocity = -transform.forward * _speed * Time.deltaTime;        
        
        _rigidbody.rotation *= Quaternion.Euler(transform.forward * _speed * Time.deltaTime);
        
    }


}
