using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private List<GameObject> _bulletPool;
    private int _poolCount = 3;
    private int _poolPosition = 0;
    [SerializeField] private string _AttackAxisName;
    // Start is called before the first frame update
    private void Start()
    {
        _bulletPool = new List<GameObject>();
        
        for (int i = 0; i < 3; i++)
        {
            _bulletPool.Add(Instantiate(_bulletPrefab, this.transform.position, Quaternion.identity));
            _bulletPool[i].SetActive(false);
        }        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetAxis(_AttackAxisName) != 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(_poolPosition < _poolCount) 
        {
            _bulletPool[_poolPosition].SetActive(true);
            _poolPosition ++;
        }
        else
        {
            _poolPosition = 0;
        }
    }
}
