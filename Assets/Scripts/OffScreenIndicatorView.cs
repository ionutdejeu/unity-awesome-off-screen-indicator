using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class OffScreenIndicatorView : MonoBehaviour
{

    [SerializeField] OffScreenIndicatorType type;
    [SerializeField] public Image image;
    [SerializeField] public Text distanceText;

    private void Start()
    {
        image.sprite = type.OffScreenGraphics;
    }
    public void OnTargetIsOutOfView()
    {
        image.sprite = type.targetGraphic;
    }
    public void OnTargetIsInView()
    {
        image.sprite = type.OffScreenGraphics;

    }
}
