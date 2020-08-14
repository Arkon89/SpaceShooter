using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    private Rigidbody _rigidbody;
    private Vector3 _basePosition; 
    [SerializeField]private int _damageCount = 1;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _basePosition = transform.position;
    }

    private void OnEnable() {
        if(!_rigidbody)
            _rigidbody = GetComponent<Rigidbody>(); 
    }

    private void OnDisable() {
        _rigidbody.velocity = Vector3.zero;
        transform.position = _basePosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            if(other.TryGetComponent<Health>(out Health health))
            {
                health.Hit(_damageCount);
            }
            
            this.gameObject.SetActive(false);
        }
    }
}
