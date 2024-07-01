using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableVertex : MonoBehaviour, IDragHandler
{
    public bool draggable;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!draggable) 
            return;
        float z = transform.position.z;
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        temp.ResetZ(z);
    }
}
