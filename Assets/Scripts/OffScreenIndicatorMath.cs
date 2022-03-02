using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicatorMath
{
    public static Vector3 GetPositionOnScreen(Camera main,Vector3 targetPos)
    {
        return main.WorldToScreenPoint(targetPos);
    }

    public void drawDebugRect(Rect rect)
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

    
    public float AngleOfRotationTorwardsScreenPos(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.y) * Mathf.Deg2Rad - 90;
    }

    
}
