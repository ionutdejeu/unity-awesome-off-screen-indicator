using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicatorMath
{
    public static Vector3 GetPositionOnScreen(Camera main,Vector3 targetPos)
    {
        return main.WorldToScreenPoint(targetPos);
    }

    public static Vector3 GetWorldPostionForScreenPos(Camera main, Vector3 screenPos)
    {
        return main.ScreenToWorldPoint(screenPos);
    }

    public static void DrawDebugRect(Rect rect)
    {
        Debug.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x + rect.width, rect.y), Color.green);
        Debug.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x, rect.y + rect.height), Color.red);
        Debug.DrawLine(new Vector3(rect.x + rect.width, rect.y + rect.height), new Vector3(rect.x + rect.width, rect.y), Color.green);
        Debug.DrawLine(new Vector3(rect.x + rect.width, rect.y + rect.height), new Vector3(rect.x, rect.y + rect.height), Color.red);
    }

    /// <summary>
    /// Determine if the specified screen position is visible in screen coordintates
    /// </summary>
    /// <param name="s"></param>
    /// <param name="screenPos"></param>
    /// <returns></returns>
    public static bool IsTargetVisibleOnScreen(Vector3 screenPos)
    {
        return screenPos.z > 0 && screenPos.x > 0 &&  screenPos.x <Screen.width && screenPos.y > 0 && screenPos.y < Screen.height;
    }


    
    public static float AngleOfRotationTorwardsScreenPos(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x);
    }

    public static Vector3 GetIndicatorPositionOnScreen(Vector3 directionFromScreenCenter,float angle,Vector3 screenBounds)
    {

        // When the targets are behind the camera their projections on the screen (WorldToScreenPoint) are inverted,
        // so just invert them.
        if (directionFromScreenCenter.z < 0)
        {
            directionFromScreenCenter *= -1;
        }

        float slope = Mathf.Tan(angle);
        // Two point's line's form is (y2 - y1) = m (x2 - x1) + c, 
        // starting point (x1, y1) is screen botton-left (0, 0),
        // ending point (x2, y2) is one of the screenBounds,
        // m is the slope
        // c is y intercept which will be 0, as line is passing through origin.
        // Final equation will be y = mx.
        if (directionFromScreenCenter.x > 0)
        {
            // Keep the x screen position to the maximum x bounds and
            // find the y screen position using y = mx.
            directionFromScreenCenter = new Vector3(screenBounds.x, screenBounds.x * slope, 0);
        }
        else
        {
            directionFromScreenCenter = new Vector3(-screenBounds.x, -screenBounds.x * slope, 0);
        }
        // Incase the y ScreenPosition exceeds the y screenBounds 
        if (directionFromScreenCenter.y > screenBounds.y)
        {
            // Keep the y screen position to the maximum y bounds and
            // find the x screen position using x = y/m.
            directionFromScreenCenter = new Vector3(screenBounds.y / slope, screenBounds.y, 0);
        }
        else if (directionFromScreenCenter.y < -screenBounds.y)
        {
            directionFromScreenCenter = new Vector3(-screenBounds.y / slope, -screenBounds.y, 0);
        }
        return directionFromScreenCenter;
    }
    
      
    
}
