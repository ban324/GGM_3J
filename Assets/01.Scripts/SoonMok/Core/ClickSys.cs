using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSys : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);
            if (hit)
            {
                hit.collider.GetComponent<IsCard>().Use(0);

            }
        }
    }
}
