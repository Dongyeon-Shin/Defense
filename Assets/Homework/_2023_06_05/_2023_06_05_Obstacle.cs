using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class _2023_06_05_Obstacle : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Color normal;
    [SerializeField]
    private Color onMouse;
    private MeshRenderer renderer;
    private bool isSelected = false;
    private Vector3 mosuePosition;
    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(!isSelected)
            {
                isSelected = true;
            }
            else
            {
                isSelected = false;
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material.color = onMouse;       
    }

    public void OnPointerExit(PointerEventData eventData)
    {       
      
        renderer.material.color = normal;
    }
    RaycastHit hit;
    private void Update()
    {
        if (isSelected)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
    }
}
