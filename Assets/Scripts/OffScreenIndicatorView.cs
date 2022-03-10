using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class OffScreenIndicatorView : MonoBehaviour
{

    [SerializeField] OffScreenIndicatorType type;
    [SerializeField] public Image image;
    [SerializeField] public Text distanceText;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSprite(Sprite s)
    {
        image.sprite = s;
    }
}
