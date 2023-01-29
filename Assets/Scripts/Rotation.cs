using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    
    public Slider rotateslider;
    public float rotmax;
    public float rotmin;

    // Start is called before the first frame update
    void Start()
    {
        rotateslider = GameObject.Find("rotation").GetComponent<Slider>();
        rotateslider.minValue = rotmin;
        rotateslider.maxValue = rotmax;
        rotateslider.onValueChanged.AddListener(RotationSliderUpdate);
    }
    void RotationSliderUpdate(float value)
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }

}
