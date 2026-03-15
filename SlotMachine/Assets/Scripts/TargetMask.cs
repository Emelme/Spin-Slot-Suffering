using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class TargetMask : MonoBehaviour
{
	public Graphic maskGraphic;       // graphic that defines mask shape
	public Graphic[] targets;         // UI objects to be masked

	Material maskMaterial;

	void OnEnable()
	{
		if (maskGraphic == null)
			maskGraphic = GetComponent<Graphic>();

		ApplyMask();
	}

	void ApplyMask()
	{
		if (maskGraphic == null)
			return;

		Material baseMat = maskGraphic.materialForRendering;

		maskMaterial = StencilMaterial.Add(
			baseMat,
			1,
			StencilOp.Replace,
			CompareFunction.Always,
			ColorWriteMask.All
		);

		maskGraphic.material = maskMaterial;

		foreach (var g in targets)
		{
			if (g == null) continue;

			Material maskedMat = StencilMaterial.Add(
				g.materialForRendering,
				1,
				StencilOp.Keep,
				CompareFunction.Equal,
				ColorWriteMask.All
			);

			g.material = maskedMat;
		}
	}

	void OnDisable()
	{
		if (maskMaterial != null)
			StencilMaterial.Remove(maskMaterial);
	}
}
