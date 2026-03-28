using UnityEngine;

public class LightSweeper : MonoBehaviour
{
    public SpotlightRig spotlightRig;

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (spotlightRig == null) return;

        float angle = Mathf.Sin(Time.time * spotlightRig.moveSpeed) * spotlightRig.moveRange;
        transform.localRotation = startRotation * Quaternion.Euler(0f, angle, 0f);
    }
}