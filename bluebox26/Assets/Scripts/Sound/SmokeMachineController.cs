using UnityEngine;

public class SmokeMachineController : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem;
    public float maxEmissionRate = 100f;

    void Start()
    {
        if (smokeParticleSystem == null)
            smokeParticleSystem = GetComponent<ParticleSystem>();

        SetSmokeAmount(0f);
    }

    public void SetSmokeAmount(float normalizedValue)
    {
        if (smokeParticleSystem == null) return;

        normalizedValue = Mathf.Clamp01(normalizedValue);

        var emission = smokeParticleSystem.emission;
        emission.rateOverTime = Mathf.Lerp(0f, maxEmissionRate, normalizedValue);
    }
}