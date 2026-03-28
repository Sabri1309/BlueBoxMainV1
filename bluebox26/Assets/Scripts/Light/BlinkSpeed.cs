using UnityEngine;

public class SliderToBlinkSpeed : MonoBehaviour
{
    public SpotlightRig spotlightRig;

    public float minLocalX = -0.54f;
    public float maxLocalX = 0.45f;

    public float minBlinkSpeed = 0f;
    public float maxBlinkSpeed = 20f;

    void Update()
    {
        if (spotlightRig == null) return;

        float x = transform.localPosition.x;
        float t = Mathf.InverseLerp(minLocalX, maxLocalX, x);
        t = Mathf.Clamp01(t);

        float blinkSpeed = Mathf.Lerp(minBlinkSpeed, maxBlinkSpeed, t);
        spotlightRig.SetBlinkSpeed(blinkSpeed);
    }
}