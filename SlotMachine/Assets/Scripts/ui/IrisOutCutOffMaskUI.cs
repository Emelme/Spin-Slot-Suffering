using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class IrisOutCutOffMaskUI : MaskableGraphic
{
    public Sprite sprite;
    
    private Material _overrideMaterial;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        if (sprite != null)
        {
            base.OnPopulateMesh(vh);
        }
        else
        {
            vh.Clear();
        }
    }

    public override Material materialForRendering
    {
        get
        {
            if (_overrideMaterial == null)
        {
            _overrideMaterial = new Material(base.materialForRendering);
            _overrideMaterial.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
        }
        return _overrideMaterial;
        }
    }
}
