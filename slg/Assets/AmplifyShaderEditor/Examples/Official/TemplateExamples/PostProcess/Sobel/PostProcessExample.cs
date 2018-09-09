using UnityEngine;

[ExecuteInEditMode]
public class PostProcessExample : MonoBehaviour
{
	public Material PostProcessMat;
	private void Awake()
	{
		if( PostProcessMat == null )
			enabled = false;
	}

	void OnRenderImage( RenderTexture src, RenderTexture dest )
	{
		Graphics.Blit( src, dest, PostProcessMat );
	}
}
