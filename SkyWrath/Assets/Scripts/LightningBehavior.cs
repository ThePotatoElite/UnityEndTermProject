using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class LightningBehavior : MonoBehaviour
{
    private AudioManager audioManager;
    
    private const int ENEMIES_LAYERMASK = 6;
    
    [SerializeField] private VisualEffect lightningEffect;
    
    public GameObject Wrapper;

    [Header("Values")]
    [SerializeField] float DamageRadius;
    
    
    [Header("Particles")]

    public ParticleSystem Lightning_Explosion;
    public ParticleSystem Lightning_Residue;
    public AudioSource Lightning_SFX;
    
    
    private bool isActivated = false;

    private Vector3 lightingPos;

    /*private void OnEnable()
    {
          PlayerInputManager.Instance.OnMousePress.AddListener(LightningInit);
    }

    private void OnDisable()
    {
          PlayerInputManager.Instance.OnMousePress.RemoveListener(LightningInit);
    }*/

    public void LightningInit(Vector3 test)
    {
        if (!isActivated)
        {
            isActivated = true;
            
            lightingPos = test;

            StartCoroutine("LightningFull");
        }
    }

    IEnumerator LightningFull()
    {
        Wrapper.transform.position = lightingPos;

        lightningEffect.Play();
        Lightning_SFX.Play();
        Lightning_Residue.Play();

        Lightning_Explosion.Play();
        
        yield return new WaitForSeconds(0.5f);
        
        DestroyHitEnemies();
    
        yield return new WaitForSeconds(0.5f);

        Lightning_Explosion.Stop();

        yield return new WaitForSecondsRealtime(1);

        isActivated = false;

        yield break;
    }


    private Collider[] getHitColliders()
    {
        return Physics.OverlapSphere(lightingPos, DamageRadius);
    }

    private void DestroyHitEnemies()
    {
        var e = getHitColliders();
        
        foreach (var col in e)
        {
            if(col.CompareTag("Enemy"))
                Destroy(col.GameObject());
        }
    }
    
}
