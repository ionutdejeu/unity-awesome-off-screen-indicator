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

    List<OffScreenIndicatorTarget> targets = new List<OffScreenIndicatorTarget>();

    [SerializeField] OffScreenIndicatorView indicatorView;

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
        GameObject[] objs = GameObject.FindGameObjectsWithTag("target");
        foreach(GameObject ob in objs)
        {
            OffScreenIndicatorTarget t = ob.GetComponent<OffScreenIndicatorTarget>();
            targets.Add(t);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Get the indicator for the target.
    /// 1. If its not null and of the same required <paramref name="type"/> 
    ///     then return the same indicator;
    /// 2. If its not null but is of different type from <paramref name="type"/> 
    ///     then deactivate the old reference so that it returns to the pool 
    ///     and request one of another type from pool.
    /// 3. If its null then request one from the pool of <paramref name="type"/>.
    /// </summary>
    /// <param name="indicator"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    private OffScreenIndicatorView GetIndicator(ref OffScreenIndicatorView indicator)
    {
        if (indicator == null)
        {
            indicator = OffScreenIndicatorPoolableObject.current.GetPooledObject();
            indicator.gameObject.SetActive(true);

        }
        return indicator;
    }

    /// <summary>
    /// Draw the indicators on the screen and set thier position and rotation and other properties.
    /// </summary>
    void DrawIndicators()
    {
        foreach (OffScreenIndicatorTarget target in targets)
        {
           
            Vector3 screenPosition = OffScreenIndicatorMath.GetPositionOnScreen(mainCamera, target.transform.position);
            bool isTargetVisible = OffScreenIndicatorMath.IsTargetVisibleOnScreen(screenPosition);
            float angle = 0f;
            Vector3 indicatorPos = screenPosition;
            target.view = GetIndicator(ref target.view);
            
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

            target.view.transform.position = indicatorPos;
            target.view.image.transform.rotation = Quaternion.Euler(0, 0, angle);
            //target.view.transform.rotation = Quaternion.Euler(0, 0, angle);


        }
    }

    void LateUpdate()
    {
        DrawIndicators();
    }
}
