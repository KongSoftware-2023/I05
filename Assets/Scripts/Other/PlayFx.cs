using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFx : MonoBehaviour
{
    protected int practicalCount=0;
    protected  ParticleSystem particleSystem;
    protected void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    public void PlayParticleEffect()
    {
           particleSystem.Play();
    }
    public void StopFx()
    {

        particleSystem.Stop();
    }
}
