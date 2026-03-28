using UnityEngine;

public class SliderToMoveSpeed : MonoBehaviour
{
    public SpotlightRig spotlightRig;

    public float minLocalX = -0.55f;
    public float maxLocalX = 0.02f;

    public float minMoveSpeed = 0f;
    public float maxMoveSpeed = 10f;

    void Update()
    {
        if (spotlightRig == null) return;

        float x = transform.localPosition.x;
        float t = Mathf.InverseLerp(minLocalX, maxLocalX, x);
        t = Mathf.Clamp01(t);

        float moveSpeed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, t);
        spotlightRig.SetMoveSpeed(moveSpeed);
    }
}