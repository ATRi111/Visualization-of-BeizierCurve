using Services.ObjectPools;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public static HashSet<Vertex> allVertices = new();

    public static Vector3 MouseToWorld(float z)
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return temp.ResetZ(z);
    }

    public MyObject MyObject { get; protected set; }
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        allVertices.Add(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
        MyObject = GetComponent<MyObject>();
    }

    protected virtual void OnDestroy()
    {
        allVertices.Remove(this);
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void Align()
    {
        Vector3 v = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), v.z);
    }

    public float SqrDistanceToMouse()
    {
        return (transform.position - MouseToWorld(0f)).RemoveZ().sqrMagnitude;
    }
}