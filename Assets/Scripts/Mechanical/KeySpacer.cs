using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
// This class spaces out the keys at the proper width
public class KeySpacer : MonoBehaviour
{
    public GlobalFloat keySpace;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.parent.position + new Vector3(0, 0, number * keySpace.floatValue);
    }
}
