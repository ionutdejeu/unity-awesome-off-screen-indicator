using UnityEngine;
using System.Collections;

public class OffScreenIndicatorTarget : MonoBehaviour
{

    /// <summary>
    /// Please do not assign its value yourself without understanding its use.
    /// A reference to the target's indicator, 
    /// its value is assigned at runtime by the offscreen indicator script.
    /// </summary>
    [HideInInspector] public OffScreenIndicatorView view;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
