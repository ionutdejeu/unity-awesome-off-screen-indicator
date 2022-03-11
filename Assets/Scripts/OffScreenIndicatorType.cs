using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/OffScreenIndicatorType", order = 1)]
public class OffScreenIndicatorType : ScriptableObject
{
    [SerializeField] public Sprite targetGraphic;
    [SerializeField] public Sprite OffScreenGraphics;
    [SerializeField] bool requiresOrientation=true;
    [SerializeField] public Color indicatorColor = Color.red;
}
