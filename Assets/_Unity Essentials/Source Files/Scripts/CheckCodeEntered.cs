using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckCodeEntered : MonoBehaviour
{
    public InputField codeInputField;
    public ParticleSystem correctEffect;
    public AudioSource correctSound;
    public AudioSource incorrectSound;

    private bool isDoorOpen = false;

    void Start()
    {
        codeInputField.onValueChanged.AddListener(OnInputFieldChanged);
    }

    private void OnInputFieldChanged(string text)
    {
        if (text.Length == 4)
        {
            ValidateCode();
            StartCoroutine(ClearInputFieldAfterDelay(0.5f));
        }
        else if (text.Length > 4)
        {
            codeInputField.text = text.Substring(0, 4);
        }
    }

    private IEnumerator ClearInputFieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        codeInputField.text = "";
        codeInputField.ActivateInputField();
    }

    public void ValidateCode()
    {
        if (codeInputField.text == "4095")
        {
            correctEffect.Play();
            correctSound.Play();

            if (!isDoorOpen)
            {
                // Set the static variable to indicate the correct code was entered
                DoorOpener.doorShouldBeOpen = true;
                isDoorOpen = true;
            }
        }
        else
        {
            incorrectSound.Play();
            StartCoroutine(ShakeInputField(0.5f, 0.1f));
        }
    }

    private IEnumerator ShakeInputField(float duration, float magnitude)
    {
        Vector3 originalPosition = codeInputField.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = originalPosition.x + Random.Range(-50f, 50f) * magnitude;
            codeInputField.transform.localPosition = new Vector3(x, originalPosition.y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        codeInputField.transform.localPosition = originalPosition;
    }
}
