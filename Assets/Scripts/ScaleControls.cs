using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControls : MonoBehaviour
{
    public GameObject ARSession;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScaleUp()
    {
        Vector3 Oscale = ARSession.transform.localScale;
        Vector3 Nscale = Oscale * 0.9f;
        ARSession.transform.localScale = Nscale;
    }
    public void ScaleDown()
    {
        Vector3 Oscale = ARSession.transform.localScale;
        Vector3 Nscale = Oscale * 1.1f;
        ARSession.transform.localScale = Nscale;
    }
}
