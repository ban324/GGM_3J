using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardEff : MonoBehaviour, Instances
{

    [SerializeField] private float speed;
    public static UseCardEff instance;
    private void Awake()
    {
        SetInstance();
    }
    public void UseEffect(IsCard card)
    {
        StartCoroutine(UseCard(card));

    }
    public IEnumerator UseCard(IsCard isCard, float time = 2f)
    {
        GameObject card = isCard.gameObject;
        while(Vector3.Distance(card.transform.position, Vector3.zero) > 0.2f)
        {
            card.transform.position = Vector3.MoveTowards(card.transform.position, new Vector3(0, 0, 0), speed * Time.deltaTime);
            yield return new WaitForSeconds(time * Time.deltaTime);

        }
        StartCoroutine(SizeUpCard(card));
    }
    IEnumerator SizeUpCard(GameObject card, float upScale = 0.03f, float time = 1f)
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
    IEnumerator FadeInCard(GameObject card, float fadeCount = 1, float timeAndScale = 0.1f)
    {
        while (fadeCount > 0)
        {
            card.GetComponent<SpriteRenderer>().color = new Color(card.GetComponent<SpriteRenderer>().color.r,
                card.GetComponent<SpriteRenderer>().color.g,
                card.GetComponent<SpriteRenderer>().color.b
                , fadeCount);
            fadeCount -= timeAndScale ;
            yield return new WaitForSeconds(timeAndScale);
        }

        Destroy(card);
        Effect.instance.EffectEnd = true;
    }

    public void SetInstance()
    {
        if (instance != null) Debug.LogError("asdf");
        instance = this;
    }
}
