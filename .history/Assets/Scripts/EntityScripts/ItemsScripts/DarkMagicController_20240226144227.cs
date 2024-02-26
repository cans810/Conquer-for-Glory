using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicController : MonoBehaviour
{
    public GameObject onEntity;

    public void Start(){
        onEntity = transform.parent.gameObject;
        Vector3 newPosition = onEntity.transform.position; // Get the position of 'onEntity'
float yOffset = 1.0f;

newPosition.y += yOffset;

transform.position = newPosition;
        transform.position = onEntity.transform.position;

        if (onEntity.GetComponent<Entity>().canDarkMagicEffect){
            darkMagicEffect();
            onEntity.GetComponent<Animator>().SetBool("DarkMagicEffect",true);
        }
    }

    public void darkMagicEffect()
    {
        float damageTaken = 9f;
        float duration = 3f;
        float initialHP = onEntity.GetComponent<Entity>().HP;
        float targetHP = initialHP - damageTaken;

        onEntity.GetComponent<Entity>().gettingDarkMagicEffect = true;

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

    public void stopDarkMagicEffect(){
        onEntity.GetComponent<Entity>().gettingDarkMagicEffect = false;
        onEntity.GetComponent<Animator>().SetBool("DarkMagicEffect",false);
        Destroy(gameObject);
    }
}
