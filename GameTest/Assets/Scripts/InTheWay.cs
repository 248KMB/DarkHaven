/* Libraries*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* declares public class InTheWay , MonoBehavoir is just base class for unity scripts */
public class InTheWay : MonoBehaviour
{
    private bool isVisible = true;
    private float invisibilityDuration = 3f;
    private float invisibleTimer = 0f;

    private Renderer objectRenderer;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        ShowSolid();
    }

    private void Update()
    {
        if (!isVisible && Time.time - invisibleTimer >= invisibilityDuration)
        {
            ToggleVisibility(true);
        }
    }

    public void ToggleVisibility(bool visible)
    {
        isVisible = visible;
        objectRenderer.enabled = isVisible;

        if (!isVisible)
        {
            invisibleTimer = Time.time;
        }
    }

    public bool IsVisible()
    {
        return isVisible;
    }

    public void ShowSolid()
    {
        ToggleVisibility(true);
    }

    // New methods for managing toggle time
    private float lastToggleTime;

    public void UpdateLastToggleTime()
    {
        lastToggleTime = Time.time;
    }

    public float GetLastToggleTime()
    {
        return lastToggleTime;
    }
}