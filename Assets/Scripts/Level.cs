using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public List<Cart> carts;

    public int index;

    public Transform pos;

    public bool isCartOnPos;

    private void Awake()
    {
        index = 0;

        isCartOnPos = false;
    }

    private void Start()
    {
        CartGo();
    }

    public void CartGo()
    {
        carts[index].gameObject.transform.DOLocalMove(pos.position, 1f, false).OnComplete(() => {
            isCartOnPos = true;
        });
    }

    public void NextCart()
    {
        if (index < carts.Count - 1)
        {
            index += 1;

            isCartOnPos = false; 

            CartGo();
        }
        else
        {
            GameManager.Instance.CheckLevelUp();
        }
    }

    public Cart GetCurrentCart()
    {
        return carts[index];
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
