using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput
{
    /// <summary>
    /// Sets cursor to confined(only game window) and if mouse should be visible or not
    /// </summary>
    /// <param name="showMouse">Show Mouse</param>
    public void SetMouseConfined(bool showMouse = false)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = showMouse;
    }

    /// <summary>
    /// Sets cursor to locked and visibility to false
    /// </summary>
    public void SetMouseLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}