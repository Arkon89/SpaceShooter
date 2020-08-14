using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Rigidbody _rigidbody;
    private Vector3 _basePosition; 
    private float _damageCount;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _basePosition = transform.position;
    }

    private void OnEnable() {
        _rigidbody.AddForce(transform.forward * _speed);
    }

    private void OnDisable() {
        _rigidbody.velocity = Vector3.zero;
        transform.position = _basePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            asteroid.Hit(_damageCount);
            this.gameObject.SetActive(false);
        }
    }
}
