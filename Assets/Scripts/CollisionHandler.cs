using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if(other.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            if(other.TryGetComponent<Health>(out Health health))
            {
                health.Hit(100);
            }
            
            //this.gameObject.SetActive(false);
            if(TryGetComponent<Health>(out Health myHealth))
            {
                myHealth.Hit(1);
            }
            transform.position = Vector3.zero;
        }
    }
}
