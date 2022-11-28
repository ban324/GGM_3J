using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSys : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image image;
    private void Update()
    {
        if(Turn.instance.state == Turn.State.Active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
                if (hit)
                {
                    if (!hit.collider.GetComponent<IsCard>().forEnemy)
                    {
                        hit.collider.GetComponent<IsCard>().Use(0);
                    }

                }
            }

        }
        if (Input.GetMouseButton(1))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
            if (hit)
            {
                if (!hit.collider.GetComponent<IsCard>().forEnemy)
                {
                    image.sprite = sprites[hit.collider.GetComponent<IsCard>().cardId];
                    image.gameObject.SetActive(true);
                }
            }
        }
        else image.gameObject.SetActive(false);
    }
}
