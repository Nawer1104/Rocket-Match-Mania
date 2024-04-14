using DG.Tweening;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Type type;

    public GameObject vfxCollect;

    private void OnMouseDown()
    {
        if (type != GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetCurrentCart().type)
            return;

        if (!GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].isCartOnPos)
            return;

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetCurrentCart().AddRocket(this);

        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void PlayVfx()
    {
        GameObject vfx = Instantiate(vfxCollect, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
    }
}
