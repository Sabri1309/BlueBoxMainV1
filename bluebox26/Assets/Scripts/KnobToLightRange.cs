using UnityEngine;

public class KnobToLightRange : MonoBehaviour
{
    public SpotlightRig spotlightRig;

    public enum RotationAxis { X, Y, Z }
    public RotationAxis rotationAxis = RotationAxis.Z;

    public float minAngle = -135f;
    public float maxAngle = 135f;

    void Update()
    {
        if (spotlightRig == null) return;

        float currentAngle = GetLocalAngle();
        float normalized = Mathf.InverseLerp(minAngle, maxAngle, currentAngle);
        normalized = Mathf.Clamp01(normalized);

        spotlightRig.SetMoveRange(normalized);
    }

    float GetLocalAngle()
    {
        Vector3 euler = transform.localEulerAngles;

        float angle = 0f;

        switch (rotationAxis)
        {
            case RotationAxis.X:
                angle = euler.x;
                break;
            case RotationAxis.Y:
                angle = euler.y;
                break;
            case RotationAxis.Z:
                angle = euler.z;
                break;
        }

        if (angle > 180f)
            angle -= 360f;

        return angle;
    }
}