using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
    // Desired aspect ratio
    private float targetAspect = 4.0f / 3.0f;

    void Start()
    {
        // Set a fixed resolution (can adjust based on your preferred 4:3 resolution)
        Screen.SetResolution(1920, 1440, true);

        // Get the current screen aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Calculate scale height based on aspect ratio difference
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;

        // If scaleHeight is less than 1, it means the screen is wider than 4:3, so we add black bars at the top and bottom
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // If scaleHeight is greater than or equal to 1, we add black bars on the sides
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}

