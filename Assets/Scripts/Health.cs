using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth = 3; 
    [SerializeField] private int _currentHealth;

    
    [SerializeField] private AudioClip _hitSound, _diedSound;
    AudioSource _audioSource;
    

    public UnityEventGameObject ZeroHP = new UnityEventGameObject();   
    public UnityEvent MinusOneHealth = new UnityEvent();
    
    private void OnEnable() {
        _currentHealth = _startHealth;
        if(TryGetComponent<AudioSource>(out AudioSource audioSource))
        {
            _audioSource = audioSource;            
        }
    }
    private void OnDisable() {
        ZeroHP.RemoveAllListeners();
    }
    
    public void Hit(int hitCount)
    {
        if(_audioSource)
        {            
            _audioSource.PlayOneShot(_hitSound);
        }
        _currentHealth -= hitCount;
        MinusOneHealth.Invoke();
        if(_currentHealth <= 0f)
            {
                ZeroHP.Invoke(gameObject);                
            }
    }

    public int GetHealthCount()
    {
        return _currentHealth;
    }




}
