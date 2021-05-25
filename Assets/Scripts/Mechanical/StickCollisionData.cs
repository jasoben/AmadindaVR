using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;

public class StickCollisionData : MonoBehaviour
{
    public float StickVelocityAtTip { get; set; }
    public GameObject stickTip, velocityDebugger;
    public bool IsActive { get; set; } = true;

    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Input_Sources thisHand;

    Vector3 currentPosition, previousPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void HapticPulse(float duration, float frequency, float amplitude)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, thisHand);
    }


    public float GetStickSpeed()
    {

        float stickSpeedAtContactPoint = Vector3.Distance(currentPosition, previousPosition);
        velocityDebugger.GetComponent<TextMeshPro>().text = stickSpeedAtContactPoint.ToString();
        HapticPulse(.2f, 150, 75);
        return stickSpeedAtContactPoint;
    }

    private void FixedUpdate()
    {
        previousPosition = currentPosition;
        currentPosition = stickTip.transform.position;
    }
}
