using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparentScript : MonoBehaviour
{
    [SerializeField] private float bufferDuration = 0.5f; //object remains visible, regardless of the conditions that might make it invisible at this time
    [SerializeField] private float invisibleDuration = 80f; // During this time, it won't become visible again even if the conditions for visibility are met
    [SerializeField] private Transform player;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = this.gameObject.transform;
    }

    private void Update()
    {
        GetAllObjectsInTheWay();
    }

    private void GetAllObjectsInTheWay()
    {
        Ray ray = new Ray(cameraTransform.position, player.position - cameraTransform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out InTheWay inTheWay))
            {
                // If the object is not visible and buffer duration has passed, make it visible
                if (!inTheWay.IsVisible() && Time.time - inTheWay.GetLastToggleTime() >= bufferDuration)
                {
                    // If the object has been invisible for at least invisibleDuration, make it visible
                    if (Time.time - inTheWay.GetLastToggleTime() >= invisibleDuration)
                    {
                        inTheWay.ToggleVisibility(true);
                    }
                }
                else if (inTheWay.IsVisible())
                {
                    // If the object is visible, make it invisible and update the last toggle time
                    inTheWay.ToggleVisibility(false);
                    inTheWay.UpdateLastToggleTime();
                }
            }
        }
    }
}