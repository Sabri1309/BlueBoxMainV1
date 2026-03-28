using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class VRKnob : MonoBehaviour
{
    [Header("References")]
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    public Transform knobVisual;

    [Header("Knob Range")]
    [Range(0f, 1f)] public float value = 0.5f;
    public float minAngle = -135f;
    public float maxAngle = 135f;
    public float dragSensitivity = 1.5f;

    [Header("Output")]
    public UnityEvent<float> onValueChanged;

    private Transform interactorTransform;
    private float startInteractorY;
    private float startValue;
    private bool isHeld;

    void Reset()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (knobVisual == null)
            knobVisual = transform;
    }

    void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
            interactable.selectExited.AddListener(OnSelectExited);
        }
    }

    void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
            interactable.selectExited.RemoveListener(OnSelectExited);
        }
    }

    void Start()
    {
        UpdateVisual();
    }

    void Update()
    {
        if (!isHeld || interactorTransform == null)
            return;

        float deltaY = interactorTransform.position.y - startInteractorY;
        value = Mathf.Clamp01(startValue + deltaY * dragSensitivity);

        UpdateVisual();
        onValueChanged?.Invoke(value);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        isHeld = true;
        interactorTransform = args.interactorObject.transform;
        startInteractorY = interactorTransform.position.y;
        startValue = value;
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        isHeld = false;
        interactorTransform = null;
    }

    void UpdateVisual()
    {
        if (knobVisual == null) return;

        float angle = Mathf.Lerp(minAngle, maxAngle, value);
        knobVisual.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}