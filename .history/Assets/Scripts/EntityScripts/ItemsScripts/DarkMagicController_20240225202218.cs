using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicController : MonoBehaviour
{
    public GameObject onEntity;

    public void Start(){
        onEntity = transform.parent.gameObject;
        if (onEntity.GetComponent<Entity>().canBurn){
            darkMagicEffect();
        }
    }

    public void darkMagicEffect()
    {
        float damageTaken = 6f;
        float duration = 2.6f;
        float initialHP = onEntity.GetComponent<Entity>().HP;
        float targetHP = initialHP - damageTaken;

        StartCoroutine(DarkMagicCoroutine(initialHP, targetHP, duration));
    }

    private IEnumerator DarkMagicCoroutine(float startHP, float targetHP, float duration)
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

    public void stopFire(){
        onEntity.GetComponent<Entity>().burning = false;
        Destroy(gameObject);
    }
}
