using UnityEngine;

public class VRViewpointSwitcher : MonoBehaviour
{
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform[] viewpoints;

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
}
