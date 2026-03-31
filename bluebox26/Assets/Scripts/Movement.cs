using UnityEngine;

public class SimpleQuestMove : MonoBehaviour
{
    public Transform head;
    public CharacterController characterController;

    public float maxMoveSpeed = 0.8f;
    public float acceleration = 4f;

    private Vector3 currentMove = Vector3.zero;

    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 forward = head.forward;
        Vector3 right = head.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 targetMove = (forward * input.y + right * input.x) * maxMoveSpeed;

        currentMove = Vector3.Lerp(currentMove, targetMove, acceleration * Time.deltaTime);

        characterController.Move(currentMove * Time.deltaTime);
    }
}