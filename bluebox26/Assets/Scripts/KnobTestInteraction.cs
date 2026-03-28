using UnityEngine;

public class KnobTest : MonoBehaviour
{
    public void OnGrabStart()
    {
        Debug.Log("Knob grabbed");
    }

    public void OnGrabEnd()
    {
        Debug.Log("Knob released");
    }
}