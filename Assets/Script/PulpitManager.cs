

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private List<GameObject> pulpits = new List<GameObject>();

   
    public float minPulpitDestroyTime = 4f;
    public float maxPulpitDestroyTime = 5f;
    public float pulpitSpawnTime = 2.5f;
    public float spawnAnimationDuration = 1f; 
    public float destroyAnimationDuration = 1f; 

    private float pulpitSize = 9f; 

    void Start()
    {
        
        SpawnInitialPulpit(Vector3.zero);
    }

    void SpawnInitialPulpit(Vector3 position)
    {
        
        if (pulpits.Count == 0)
        {
            SpawnPulpit(position);
        }
    }

    void SpawnPulpit(Vector3 position)
    {
        
        GameObject newPulpit = Instantiate(pulpitPrefab, position, Quaternion.identity);
        pulpits.Add(newPulpit);

        newPulpit.transform.localScale = Vector3.zero;

        TextMeshProUGUI pulpitTimerText = newPulpit.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>();

        if (pulpitTimerText != null)
        {
            
            float destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);

            
            StartCoroutine(StartCountdown(pulpitTimerText, destroyTime));

            
            StartCoroutine(AnimatePulpitAppearance(newPulpit, spawnAnimationDuration));

            
            StartCoroutine(DestroyPulpitWithEffect(newPulpit, destroyTime, destroyAnimationDuration));
        }
        

       
        Invoke("SpawnNextPulpit", pulpitSpawnTime);
    }

    IEnumerator AnimatePulpitAppearance(GameObject pulpit, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = new Vector3(pulpitSize, 0.3f, pulpitSize); 

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            pulpit.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pulpit.transform.localScale = targetScale; 
    }

    IEnumerator DestroyPulpitWithEffect(GameObject pulpit, float destroyTime, float animationDuration)
    {
        
        yield return new WaitForSeconds(destroyTime - animationDuration);

        float elapsedTime = 0f;
        Vector3 initialScale = pulpit.transform.localScale;
        Vector3 targetScale = Vector3.zero;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            pulpit.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pulpit.transform.localScale = targetScale;
        Destroy(pulpit);
        pulpits.Remove(pulpit); 
    }

    void SpawnNextPulpit()
    {
        Vector3 lastPulpitPosition = pulpits[pulpits.Count - 1].transform.position;
        Vector3 newPosition = GetEdgePosition(lastPulpitPosition);
        SpawnPulpit(newPosition);
    }

    Vector3 GetEdgePosition(Vector3 currentPosition)
    {
        Vector3[] edgePositions = new Vector3[]
        {
            currentPosition + new Vector3(-pulpitSize, 0, 0),  
            currentPosition + new Vector3(pulpitSize, 0, 0),   
            currentPosition + new Vector3(0, 0, -pulpitSize),  
            currentPosition + new Vector3(0, 0, pulpitSize)    
        };

        int randomIndex = Random.Range(0, edgePositions.Length);
        return edgePositions[randomIndex];
    }

    IEnumerator StartCountdown(TextMeshProUGUI timerText, float duration)
    {
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            
            timerText.text = remainingTime.ToString("F1");
            remainingTime -= Time.deltaTime;
            yield return null; 
        }

        
        timerText.text = "";
    }
}


