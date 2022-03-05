using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffScreenIndicatorSystem : MonoBehaviour
{
    [Range(0.5f, 0.9f)]
    [Tooltip("Distance offset of the indicators from the centre of the screen")]
    [SerializeField] private float screenBoundOffset = 0.9f;

    private Camera mainCamera;
    private Vector3 screenCentre;
    private Vector3 screenBounds;
    private Rect screenBoundsDebug;

    [SerializeField] List<GameObject> targets = new List<GameObject>();
    [SerializeField] GameObject directionIndicator;

    void Awake()
    {
        mainCamera = Camera.main;
        screenCentre = new Vector3(Screen.width, Screen.height, 0) / 2;
        screenBounds = screenCentre * screenBoundOffset;
        screenBoundsDebug = new Rect(-screenBounds.x, -screenBounds.y, screenBounds.x, screenBounds.y);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Draw the indicators on the screen and set thier position and rotation and other properties.
    /// </summary>
    void DrawIndicators()
    {
        foreach (GameObject target in targets)
        {
            Vector3 screenPosition = OffScreenIndicatorMath.GetPositionOnScreen(mainCamera, target.transform.position);
            bool isTargetVisible = OffScreenIndicatorMath.IsTargetVisibleOnScreen(screenPosition);
            float angle = 0f;
            Vector3 indicatorPos = screenPosition;

            if (!isTargetVisible)
            {
                // convert the coordinates of the screen around the origin 
                Vector3 dir = screenPosition - screenCentre;
                angle = OffScreenIndicatorMath.AngleOfRotationTorwardsScreenPos(dir);

                indicatorPos = OffScreenIndicatorMath.GetIndicatorPositionOnScreen(dir, angle, screenBounds);
                // move back the reference based on central point of the screen 
                indicatorPos += screenCentre;
                //directionIndicator.transform.position = indicatorPositionOnScreen;
                angle *= Mathf.Rad2Deg;

            }

            directionIndicator.transform.position = indicatorPos;
            directionIndicator.transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }

    void LateUpdate()
    {
        DrawIndicators();
    }
}
