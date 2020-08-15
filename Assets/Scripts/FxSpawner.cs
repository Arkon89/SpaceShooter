using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _defaultFxPrefab;
    [SerializeField] private FxInfo _fxInfo;

    private void OnEnable() {
        if(TryGetComponent<Health>(out Health health))
        {
            health.ZeroHP.AddListener(SpawnFX);
        }
    }

    public void SpawnFX(GameObject target)
    {
        GameObject fx = Instantiate(_defaultFxPrefab, target.transform.position, Quaternion.identity);
        if(fx.TryGetComponent<AudioSource>(out AudioSource audioSource))
        {
            audioSource.PlayOneShot(_fxInfo.fxSound);
        }
        if(fx.TryGetComponent<ParticleSystem>(out ParticleSystem particleSystem))
        {
            particleSystem = _fxInfo.fxParticle;
        }
        Destroy(fx, _fxInfo._lifeTime);
    }

    private void OnDisable() {
        if(TryGetComponent<Health>(out Health health))
        {
            health.ZeroHP.RemoveListener(SpawnFX);
        }
    }
}
