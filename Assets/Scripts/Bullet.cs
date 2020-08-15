using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MoveForward
{
    
    private Vector3 _basePosition; 
    [SerializeField]private int _damageCount = 1;
    public UnityEventGameObject bulletDisabled = new UnityEventGameObject();
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _basePosition = transform.position;
    }


    private void OnDisable() {
        _rigidbody.velocity = Vector3.zero;
        
        bulletDisabled.Invoke(gameObject);
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
