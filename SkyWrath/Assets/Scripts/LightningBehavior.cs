using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class LightningBehavior : MonoBehaviour
{
    [SerializeField] private VisualEffect lightningEffect;

    public GameObject Wrapper;

    [Header("Values")]
    [SerializeField] private float damageRadius;
    
    [Header("Particles")]

    public ParticleSystem Lightning_Explosion;
    public ParticleSystem Lightning_Residue;
    public AudioSource Lightning_SFX;

    private SphereCollider _collider;
    
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

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = damageRadius;
        _collider.enabled = false;
    }

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
        _collider.enabled = true;

        yield return new WaitForSeconds(1f);

        Lightning_Explosion.Stop();
        _collider.enabled = false;

        yield return new WaitForSecondsRealtime(1);

        isActivated = false;

        yield break;
    }

    
}
