using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _lifePrefab;
    [SerializeField] private List<GameObject> _lifes;
    
    

    private void Start() {
        if(FindObjectOfType<ShipMover>().gameObject.TryGetComponent<Health>(out Health health))
        {
            SetLifesCount(health.GetHealthCount());
            health.MinusOneHealth.AddListener(RemoveLife);
        }
    }
    private void RemoveLife()
    {
        if(_lifes.Count > 0)
        {
            _lifes[0].SetActive(false);
            _lifes.Remove(_lifes[0]);
        }        
    }

    private void SetLifesCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _lifes.Add(Instantiate(_lifePrefab, transform));
        }
    }

    
    
}
