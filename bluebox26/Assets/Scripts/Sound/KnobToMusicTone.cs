using UnityEngine;

public class KnobToMusicTone : MonoBehaviour
{
    public VenueMusicManager musicManager;

    public enum RotationAxis { X, Y, Z }
    public RotationAxis rotationAxis = RotationAxis.Z;

    public float minAngle = -135f;
    public float maxAngle = 135f;

    void Update()
    {
        if (musicManager == null) return;

        float currentAngle = GetLocalAngle();
        float normalized = Mathf.InverseLerp(minAngle, maxAngle, currentAngle);
        normalized = Mathf.Clamp01(normalized);

        musicManager.SetTone(normalized);
    }

    float GetLocalAngle()
    {
        Vector3 euler = transform.localEulerAngles;
        float angle = 0f;

        switch (rotationAxis)
        {
            case RotationAxis.X: angle = euler.x; break;
            case RotationAxis.Y: angle = euler.y; break;
            case RotationAxis.Z: angle = euler.z; break;
        }

        if (angle > 180f)
            angle -= 360f;

        return angle;
    }
}