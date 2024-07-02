using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableVertex : MonoBehaviour, IDragHandler
{
    public static Vector3 MouseToWorld(float z)
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return temp.ResetZ(z);
    }

    public bool draggable;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!draggable)
            return;
        transform.position = MouseToWorld(transform.position.z);
    }

    public void Align()
    {
        Vector3 v = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), v.z);
    }
}
