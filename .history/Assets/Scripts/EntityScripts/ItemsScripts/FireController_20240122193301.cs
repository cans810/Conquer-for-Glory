using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject onEntity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void burn()
    {
        onEntity = transform.parent.gameObject;

        float damageTaken = 5f;
        float duration = 2.0f;
        float initialHP = onEntity.GetComponent<Entity>().HP;
        float targetHP = initialHP - damageTaken;

        StartCoroutine(BurnCoroutine(initialHP, targetHP, duration));
    }

    private IEnumerator BurnCoroutine(float startHP, float targetHP, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            float currentHP = Mathf.Lerp(startHP, targetHP, timer / duration);
            onEntity.GetComponent<Entity>().HP = currentHP;

            timer += Time.deltaTime;
            yield return null;
        }

        onEntity.GetComponent<Entity>().HP = targetHP;
    }
}
