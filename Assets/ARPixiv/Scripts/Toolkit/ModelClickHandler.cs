using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModelClickHandler : MonoBehaviour
{
    public ParticleSystem TargetParticle;

    private void Start()
    {
        TargetParticle.Stop();
    }

    void OnMouseDown()
    {
        ModelTransformChange.Get().NeedChangeObject = gameObject;
        StartCoroutine(ParticleCoroutine());
    }

    private IEnumerator ParticleCoroutine()
    {

        TargetParticle.Play();

        yield return new WaitForSeconds(5.0f);

        TargetParticle.Stop();
    }
}