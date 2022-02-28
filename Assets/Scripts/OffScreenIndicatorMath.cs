using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicatorMath
{
    public static Vector3 GetPositionOnScreen(Camera main,Vector3 targetPos)
    {
        return main.WorldToScreenPoint(targetPos);
    }
    public static bool IsTargetVisibleOnScreen(Screen s, Vector3 screenPos)
    {
        return screenPos.z > 0 && screenPos.x > 0;
    }
}
