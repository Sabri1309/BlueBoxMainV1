using UnityEngine;

public class SpotlightRig : MonoBehaviour
{
    public Light spotLight;

    [Header("Color Control")]
    [Range(0f, 1f)] public float hue = 0f;
    [Range(0f, 1f)] public float saturation = 1f;
    [Range(0f, 1f)] public float value = 1f;

    [Header("Blink Control")]
    public float baseIntensity = 5f;
    [Range(0f, 20f)] public float blinkSpeed = 0f;

    [Header("Movement Control")]
    [Range(0f, 10f)] public float moveSpeed = 1f;
    [Range(0f, 90f)] public float moveRange = 30f;

    private Quaternion startRotation;

    void Start()
    {
        if (spotLight == null)
            spotLight = GetComponentInChildren<Light>();

        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (spotLight == null) return;

        ApplyColor();
        ApplyBlink();
        ApplyMovement();
    }

    void ApplyColor()
    {
        Color newColor = Color.HSVToRGB(hue, saturation, value);
        spotLight.color = newColor;
    }

    void ApplyBlink()
    {
        if (blinkSpeed <= 0.01f)
        {
            spotLight.intensity = baseIntensity;
            return;
        }

        float t = Mathf.PingPong(Time.time * blinkSpeed, 1f);
        spotLight.intensity = Mathf.Lerp(0f, baseIntensity, t);
    }

    void ApplyMovement()
    {
        float angle = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.localRotation = startRotation * Quaternion.Euler(0f, angle, 0f);
    }

    public void SetHue(float normalizedValue)
{
    hue = Mathf.Clamp01(normalizedValue);
}

    public void SetBlinkSpeed(float newBlinkSpeed)
    {
        blinkSpeed = newBlinkSpeed;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public void SetMoveRange(float normalizedValue)
    {
        moveRange = Mathf.Lerp(0f, 150f, normalizedValue);
    }
}