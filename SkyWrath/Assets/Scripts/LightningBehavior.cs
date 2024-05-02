using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class LightningBehavior : MonoBehaviour
{
    [SerializeField] private VisualEffect lightningEffect;

    public GameObject Wrapper;

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

        yield return new WaitForSeconds(1f);

        Lightning_Explosion.Stop();

        yield return new WaitForSecondsRealtime(1);

        isActivated = false;

        yield break;
    }
}
