using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    public GameObject handObject = null;

    private HandPhysics handPhysics = null;
    private XRDirectInteractor interactor = null;

    private void Awake()
    {
        handPhysics = handObject.GetComponent<HandPhysics>();
        interactor = GetComponent<XRDirectInteractor>();
    }

    private void OnEnable()
    {
        interactor.onSelectEnter.AddListener(Hide);
        interactor.onSelectExit.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.onSelectEnter.RemoveListener(Hide);
        interactor.onSelectExit.RemoveListener(Show);
    }

    private void Show(XRBaseInteractable interactable)
    {
        handPhysics.TeleportToTarget();
        handObject.SetActive(true);
    }

    private void Hide(XRBaseInteractable interactable)
    {
        handObject.SetActive(false);
    }
}
