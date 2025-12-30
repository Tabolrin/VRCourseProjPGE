/*using UnityEngine;
using UnityEngine.InputSystem;

public class VRViewpointSwitcher : MonoBehaviour
{
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform[] viewpoints;
    [SerializeField] private InputAction input;


    private int index = 0;

    public void NextView()
    {
        if (viewpoints == null || viewpoints.Length == 0 || xrOrigin == null)
            return;

        index = (index + 1) % viewpoints.Length;
        xrOrigin.SetPositionAndRotation(
            viewpoints[index].position,
            viewpoints[index].rotation
        );
    }

    public void SwitchView(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            NextView();
            Debug.Log("pressed switch");
        }
    }
}
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class VRViewpointSwitcher : MonoBehaviour
{
    [Header("XR Origin Root")]
    [SerializeField] private Transform xrOrigin;

    [Header("Viewpoints")]
    [SerializeField] private Transform[] viewpoints;

    private InputSystem_Actions input;
    private int index = 0;

    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.Player.SwitchView.performed += OnSwitchView;
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.SwitchView.performed -= OnSwitchView;
        input.Player.Disable();
    }

    private void OnSwitchView(InputAction.CallbackContext ctx)
    {
        NextView();
    }

    public void NextView()
    {
        if (xrOrigin == null || viewpoints.Length == 0)
            return;

        index = (index + 1) % viewpoints.Length;
        xrOrigin.SetPositionAndRotation
            (
            viewpoints[index].position,
            viewpoints[index].rotation
        );
    }
}
