using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FxInfo : ScriptableObject
{
    public AudioClip fxSound;
    public ParticleSystem fxParticle;
    public float _lifeTime;
}
