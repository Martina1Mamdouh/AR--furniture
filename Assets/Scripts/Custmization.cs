using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custmization : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public void setcolorBlue()
    {
        mat1.CopyPropertiesFromMaterial(mat3);
    }
    public void setcolorBrown()
    {
        mat1.SetColor("_Color", new Color(0.69f, 0.19f, 0.07f));
        mat2.SetColor("_Color", new Color(0.69f, 0.19f, 0.07f));
    }
}
