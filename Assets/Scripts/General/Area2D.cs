using EditorExtend.PointEditor;
using UnityEngine;

[RequireComponent(typeof(RectEditor))]
public class Area2D : MonoBehaviour
{
    private RectEditor rectEditor;

    private void Awake()
    {
        rectEditor = GetComponent<RectEditor>();
    }

    public bool Contains(Vector3 v)
    {
        return rectEditor.WorldRect.Contains(v);
    }

    public void ShrinkToInt(out int xMin,out int xMax,out int yMin,out int yMax)
    {
        xMin = Mathf.CeilToInt(rectEditor.WorldRect.xMin);
        xMax = Mathf.FloorToInt(rectEditor.WorldRect.xMax);
        yMin = Mathf.CeilToInt(rectEditor.WorldRect.yMin);
        yMax = Mathf.FloorToInt(rectEditor.WorldRect.yMax);
    }
}