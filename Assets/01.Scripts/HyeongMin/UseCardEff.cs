using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardEff : MonoBehaviour
{
    [SerializeField] private GameObject cardTest;//나중에지우던가하셈
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(UseCard(cardTest.transform.GetChild(0).GetComponent<IsCard>()));
    }
    public IEnumerator UseCard(IsCard isCard, float time = 2f)
    {
        GameObject card = isCard.gameObject;
        card.transform.position = Vector3.MoveTowards(card.transform.position, new Vector3(0, 0, 0), speed * Time.deltaTime);
        yield return new WaitForSeconds(time);
        StartCoroutine(SizeUpCard(card));
    }
    IEnumerator SizeUpCard(GameObject card, float upScale = 0.01f, float time = 1f)
    {
        Vector3 cardScale = card.transform.localScale;
        while (card.transform.localScale.x <= (cardScale.x * 1.5f) && card.transform.localScale.y <= (cardScale.y * 1.5f))
        {
            card.transform.localScale += new Vector3(cardScale.x * upScale, cardScale.y * upScale, 0);
            yield return new WaitForSeconds(upScale);
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeInCard(card));
    }
    IEnumerator FadeInCard(GameObject card, float fadeCount = 1, float timeAndScale = 0.01f)
    {
        while (fadeCount > 0)
        {
            card.GetComponent<SpriteRenderer>().color = new Color(card.GetComponent<SpriteRenderer>().color.r,
                card.GetComponent<SpriteRenderer>().color.g,
                card.GetComponent<SpriteRenderer>().color.b
                , fadeCount);
            fadeCount -= timeAndScale;
            yield return new WaitForSeconds(timeAndScale);
        }
        Destroy(card);
    }
}
