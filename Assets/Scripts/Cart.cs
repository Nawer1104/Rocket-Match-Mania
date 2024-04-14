using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Cart : MonoBehaviour
{
    public Type type;

    public List<Transform> rocketsPos;

    public List<Rocket> rockets;

    private bool isCompleted;

    private void Start()
    {
        isCompleted = false;
    }

    public void AddRocket(Rocket rocket)
    {
        if (rockets.Count < 3)
        {
            if (rockets.Contains(rocket)) return;

            rockets.Add(rocket);

            rocket.transform.DOMove(rocketsPos[rockets.IndexOf(rocket)].position, 1f).OnComplete(() => {
                rocket.PlayVfx();

            });


            CheckRocket();
        }
    }

    private void CheckRocket()
    {
        if (rockets.Count == 3 || isCompleted)
        {
            foreach (Rocket rocket in rockets)
            {
                rocket.gameObject.transform.DOScale(0, 1).OnComplete(() => {
                    rocket.gameObject.SetActive(false);
                });
            }

            gameObject.SetActive(false);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].NextCart();

            isCompleted = true;
        }
    }
}
