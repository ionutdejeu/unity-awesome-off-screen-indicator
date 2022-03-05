using UnityEngine;
using System.Collections;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        Vector3 thisPos = OffScreenIndicatorMath.GetPositionOnScreen(mainCam, this.transform.position);
        float angle = OffScreenIndicatorMath.AngleOfRotationTorwardsScreenPos(thisPos - targetPos);
        Debug.Log(angle);
        Quaternion anglesAxis = Quaternion.AngleAxis(angle, this.transform.forward);
        transform.eulerAngles = mainCam.transform.forward * angle;
    }
}
