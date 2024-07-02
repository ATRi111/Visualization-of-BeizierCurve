using Services;
using Services.Event;
using Services.ObjectPools;
using System.Collections.Generic;
using UnityEngine;

public class VertexManager : MonoBehaviour ,ILine
{
    private IObjectManager objectManager;
    private IEventSystem eventSystem;

    private readonly List<DraggableVertex> vertices = new List<DraggableVertex>();

    [SerializeField]
    private float selectedDistance;
    private int selectedIndex;

    [SerializeField]
    private Color color_selected;
    [SerializeField]
    private Color color_notSelected;

    private bool dirty;
    private Vector3[] vs;

    private void Awake()
    {
        objectManager = ServiceLocator.Get<IObjectManager>();
        eventSystem = ServiceLocator.Get<IEventSystem>();
        DraggableVertex[] temp = GetComponentsInChildren<DraggableVertex>();
        vertices.AddRange(temp);
        selectedIndex = -1;
        dirty = false;
        UpdatePositions();
    }

    private void OnEnable()
    {
        eventSystem.AddListener(EEvent.AfterVertexChange, AfterVertexChange);
    }
    private void OnDisable()
    {
        eventSystem.RemoveListener(EEvent.AfterVertexChange, AfterVertexChange);
    }
    private void AfterVertexChange()
    {
        dirty = true;
    }

    public void GenerateVertex()
    {
        objectManager.Activate("Vertex", DraggableVertex.MouseToWorld(0f), Vector3.zero, transform);
        dirty = true;
    }
    public void DeleteVertex()
    {
        if(selectedIndex >= 0 && selectedIndex < vertices.Count)
        {
            vertices.RemoveAt(selectedIndex);
            dirty = true;
        }
    }
    public void AlignVertex()
    {
        if (selectedIndex >= 0 && selectedIndex < vertices.Count)
        {
            vertices[selectedIndex].Align();
            dirty = true;
        }
    }

    private void UpdatePositions()
    {
        if (dirty)
        {
            vs = new Vector3[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                vs[i] = vertices[i].transform.position;
            }
            dirty = false;
        }
    }
    public Vector3[] GetPositions()
    {
        UpdatePositions();
        return vs;
    }
}
