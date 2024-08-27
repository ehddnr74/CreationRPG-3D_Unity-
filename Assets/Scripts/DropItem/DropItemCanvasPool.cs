using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCanvasPool : MonoBehaviour
{
    public GameObject canvasPrefab;
    public int poolSize = 10;

    private Queue<GameObject> canvasPool;

    public static DropItemCanvasPool instance;

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

        InitializePool();
    }
    private void InitializePool()
    {
        canvasPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject canvas = Instantiate(canvasPrefab);
            canvas.SetActive(false);
            canvasPool.Enqueue(canvas);
        }
    }

    public GameObject GetCanvas()
    {
        if (canvasPool.Count > 0)
        {
            GameObject canvas = canvasPool.Dequeue();
            canvas.SetActive(true);
            return canvas;
        }
        else
        {
            GameObject canvas = Instantiate(canvasPrefab);
            return canvas;
        }
    }

    public void ReturnCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
        canvasPool.Enqueue(canvas);
    }
}
