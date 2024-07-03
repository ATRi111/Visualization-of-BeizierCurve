using Services;
using Services.Event;
using Tools;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableVertex : Vertex, IDragHandler
{
    protected IEventSystem eventSystem;

    public bool draggable;

    protected override void Awake()
    {
        base.Awake();
        eventSystem = ServiceLocator.Get<IEventSystem>();
        draggable = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!draggable)
            return;
        transform.position = MouseToWorld(transform.position.z);
        eventSystem.Invoke(EEvent.AfterDraggableVertexChange);
    }
}
