using UnityEngine;

public class SliderToSmokeAmount : MonoBehaviour
{
    public SmokeMachineController smokeMachine;

    public float minLocalX = -0.03f;
    public float maxLocalX = 0.03f;

    void Update()
    {
        if (smokeMachine == null) return;

        float x = transform.localPosition.x;
        float normalized = Mathf.InverseLerp(minLocalX, maxLocalX, x);
        normalized = Mathf.Clamp01(normalized);

        smokeMachine.SetSmokeAmount(normalized);
    }
}