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
        lightingPos = test;
        StartCoroutine("LightningFull");
    }

    IEnumerator LightningFull()
    {
        print("Hello2");

        while (true)
        {
            print(lightingPos);
            print("Hello3");
            Wrapper.transform.position = lightingPos;// POSITION HERE FROM ROTEM

            yield return new WaitForSeconds(5.3f);

            lightningEffect.Play();
            Lightning_SFX.Play();
            Lightning_Residue.Play();

            Lightning_Explosion.Play();

            yield return new WaitForSeconds(1f);

            Lightning_Explosion.Stop();

            yield return new WaitForSecondsRealtime(1);
        }
    }
}
