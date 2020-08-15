using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField]private float _attackDelay = 0.5f;
    private List<GameObject> _bulletPool;
    private int _poolCount = 30;
    private int _poolPosition = 0;
    private float _attackTimerCount;
    
    [SerializeField] private string _AttackAxisName;
    // Start is called before the first frame update
    private void Start()
    {
        
        _bulletPool = new List<GameObject>();
        
        for (int i = 0; i < _poolCount; i++)
        {
            _bulletPool.Add(Instantiate(_bulletPrefab, this.transform.position, Quaternion.identity));
            _bulletPool[i].SetActive(false);
            if(_bulletPool[i].TryGetComponent<Bullet>(out Bullet bullet))
            {
                bullet.bulletDisabled.AddListener(BackToBasePosition);
                bullet.OutOfScreen.AddListener(BackToBasePosition);
            }
        }        
    }

    // Update is called once per frame
    private void Update()
    {
        _attackTimerCount += Time.deltaTime;
        if(Input.GetAxis(_AttackAxisName) != 0f && _attackTimerCount > _attackDelay)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _attackTimerCount = 0f;
        if(_poolPosition < _poolCount && !_bulletPool[_poolPosition].activeSelf) 
        {            
            _bulletPool[_poolPosition].transform.position = transform.position;
            _bulletPool[_poolPosition].SetActive(true);            
            _poolPosition ++;
        }
        else
        {
            _poolPosition = 0;
        }
    }

    private void BackToBasePosition(GameObject bullet)
    {
        bullet.transform.position = transform.position;
        if(bullet.activeSelf)
            bullet.SetActive(false);
    }
}
