using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CutOutMaskUI : Image
{
    public override Material materialForRendering
    {
        get
        {
            Material newMaterial = new Material(base.materialForRendering);
            newMaterial.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);
            return newMaterial;
        }
    }
}
