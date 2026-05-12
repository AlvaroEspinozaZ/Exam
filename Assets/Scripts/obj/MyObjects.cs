using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MyObjects : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Renderer rend;
    private Color originalColor;
    SelectEnterEventArgs args;
    public Color colorAlAgarrar = Color.green;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        rend.material.color = colorAlAgarrar;
        VibrationCamera();
    }

    void OnRelease(SelectExitEventArgs args)
    {
        rend.material.color = originalColor;
    }
    void VibrationCamera()
    {
        var interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null)
        {
            var controllerInteractor = interactor as XRBaseInputInteractor;

            if (controllerInteractor != null)
            {
                controllerInteractor.SendHapticImpulse(0.5f, 0.2f);
            }
        }
    }
}
