using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/OffScreenIndicatorType", order = 1)]
public class OffScreenIndicatorType : ScriptableObject
{
    [SerializeField] Sprite targetGraphic;
    [SerializeField] Sprite OffScreenGraphics;
    [SerializeField] bool requiresOrientation=true;
    [SerializeField] Color indicatorColor = Color.red;
}
