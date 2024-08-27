using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropItemCanvas : MonoBehaviour
{
    public static DropItemCanvas instance;

    public GameObject canvasPrefab;
    public GameObject canvasParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowItemDropCanvas(Sprite itemSprite, string itemName)
    {
        GameObject canvasInstance = DropItemCanvasPool.instance.GetCanvas();
        canvasInstance.transform.SetParent(canvasParent.transform, false);

        Image itemImage = canvasInstance.transform.Find("DropItemImage").GetComponent<Image>();
        TextMeshProUGUI itemText = canvasInstance.transform.Find("DropItemText").GetComponent<TextMeshProUGUI>();

        itemImage.sprite = itemSprite;
        itemText.text = itemName;

        canvasInstance.SetActive(true);
        StartCoroutine(HideCanvasAfterDelay(canvasInstance, 2f)); // 2ÃÊ ÈÄ¿¡ Äµ¹ö½º ¼û±è
    }

    private IEnumerator HideCanvasAfterDelay(GameObject canvas, float delay)
    {
        yield return new WaitForSeconds(delay);
        DropItemCanvasPool.instance.ReturnCanvas(canvas);
    }
}
