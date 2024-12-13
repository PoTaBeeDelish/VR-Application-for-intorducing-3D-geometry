using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TesCoding : XRBaseInteractable
{
    [Tooltip("The transform of the visual component of the knob")]
    public Transform knobTransform;

    public IXRSelectInteractor selectInteractor;
    private Vector3 prevInteractorPos = Vector3.zero;
    private Vector3 posDelta = Vector3.zero;
    private Quaternion selectRotation = Quaternion.identity;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(StartTurn);
        selectExited.AddListener(EndTurn);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(StartTurn);
        selectExited.RemoveListener(EndTurn);
    }

    private void StartTurn(SelectEnterEventArgs eventArgs)
    {
        selectInteractor = eventArgs.interactorObject;
        selectRotation = selectInteractor.transform.rotation;
    }

    private void EndTurn(SelectExitEventArgs eventArgs)
    {
        selectInteractor = null;
        selectRotation = Quaternion.identity;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic && isSelected)
        {
            Debug.Log("aaaaaa");
            RotateKnob();
            selectRotation = selectInteractor.transform.rotation;
        }
    }

    private void RotateKnob()
    {
        // Calculate positional delta

        posDelta = selectInteractor.transform.position - prevInteractorPos;

        // Apply rotation based on positional delta and camera's direction
        if (Vector3.Dot(knobTransform.up, Vector3.up) >= 0)
        {
            knobTransform.Rotate(knobTransform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
        }
        else
        {
            knobTransform.Rotate(knobTransform.up, Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
        }
        knobTransform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
    }
}
/*
public class SteeringWheel : XRBaseInteractable
{
    [SerializeField] private Transform wheelTransform;

    public UnityEvent<float> OnWheelRotated;

    private float currentAngle = 0.0f;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        currentAngle = FindWheelAngle();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        currentAngle = FindWheelAngle();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
                RotateWheel();
        }
    }

    private void RotateWheel()
    {
        // Convert that direction to an angle, then rotation
        float totalAngle = FindWheelAngle();

        // Apply difference in angle to wheel
        float angleDifference = currentAngle - totalAngle;
        wheelTransform.Rotate(transform.forward, -angleDifference, Space.World);

        // Store angle for next process
        currentAngle = totalAngle;
        OnWheelRotated?.Invoke(angleDifference);
    }

    private float FindWheelAngle()
    {
        float totalAngle = 0;

        // Combine directions of current interactors
        foreach (IXRSelectInteractor interactor in interactorsSelecting)
        {
            Vector2 direction = FindLocalPoint(interactor.transform.position);
            totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
        }

        return totalAngle;
    }

    private Vector2 FindLocalPoint(Vector3 position)
    {
        // Convert the hand positions to local, so we can find the angle easier
        return transform.InverseTransformPoint(position).normalized;
    }

    private float ConvertToAngle(Vector2 direction)
    {
        // Use a consistent up direction to find the angle
        return Vector2.SignedAngle(Vector2.up, direction);
    }

    private float FindRotationSensitivity()
    {
        // Use a smaller rotation sensitivity with two hands
        return 1.0f / interactorsSelecting.Count;
    }
}
*/