using UnityEngine;
using System.Collections;

public class ScaleObject : MonoBehaviour {
    [SerializeField] Vector3 normalScale;
    [SerializeField] Vector3 largerScale;

    /// <summary>
    /// Scales the object to the larger scale over time seconds
    /// </summary>
    /// <param name="time">Time in seconds</param>
    public void ScaleUp (float time) {
        StartCoroutine(ScaleTransform(largerScale, time));
    }

    /// <summary>
    /// Scales the object to the normal scale over time seconds
    /// </summary>
    /// <param name="time">Time in seconds</param>
    public void ScaleDown (float time) {
        StartCoroutine(ScaleTransform(normalScale, time));
    }

    /// <summary>
    /// Scales the object to the target scale over time seconds
    /// </summary>
    /// <param name="targetScale">Scale to lerp to</param>
    /// <param name="time">Time in seconds</param>
    /// <returns></returns>
    private IEnumerator ScaleTransform (Vector3 targetScale, float time) {
        // Set up scaling
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        // Lerp localScale to targetScale over time seconds
        while (elapsedTime < time)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final scale is set accurately
        transform.localScale = targetScale;
    }
}
