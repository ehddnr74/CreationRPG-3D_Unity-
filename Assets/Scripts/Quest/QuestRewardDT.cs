using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestRewardDT : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public int itemAmount;
    public int goldAmount;
    public int experienceAmount;
    

    //private ItemToolTip itemToolTip;

    private void Start()
    {
        //itemToolTip = GameObject.Find("InventoryUI").GetComponent<ItemToolTip>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //itemToolTip.Deactivate();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // _globalSortingOrderCounter를 static으로 접근
        MovableUI._globalSortingOrderCounter++;
        transform.GetComponentInParent<Canvas>().sortingOrder = MovableUI._globalSortingOrderCounter;
        //itemToolTip.Activate(item, amount);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //itemToolTip.Deactivate();
    }
}
