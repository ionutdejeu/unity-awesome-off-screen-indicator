using UnityEngine;
using System.Collections;

public class RotateTowardsTarget : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = OffScreenIndicatorMath.GetPositionOnScreen(mainCam, target.transform.position);
        Vector3 thisPos = OffScreenIndicatorMath.GetPositionOnScreen(mainCam, this.transform.position);
        float angle = OffScreenIndicatorMath.AngleOfRotationTorwardsScreenPos(thisPos- targetPos);
        Debug.Log(angle);
        Quaternion anglesAxis = Quaternion.AngleAxis(angle, this.transform.forward);
        transform.eulerAngles = Vector3.forward * angle;
        //transform.rotation = Quaternion.Slerp(transform.rotation, anglesAxis, Time.deltaTime*50);
    }
}
