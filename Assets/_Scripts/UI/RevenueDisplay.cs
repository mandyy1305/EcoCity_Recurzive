using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class RevenueDisplay : MonoBehaviour
{
    public TextMeshProUGUI revenueText;
    public float animationDuration = 1.0f;
    public Vector3 endPositionOffset = new Vector3(0, 5, 0);
    public float startScale = 0.0f;
    public float endScale = 1.0f;

    void Start()
    {

        revenueText = GetComponentInChildren<TextMeshProUGUI>();
        revenueText.gameObject.SetActive(false);
        //revenueText.gameObject.SetActive(false); // Initially disable the text object
    }

    public void ShowRevenue(float amount)
    {
        // Set the initial state
        revenueText.text = $"+{amount}";
        revenueText.transform.localScale = Vector3.one * startScale;
        //revenueText.transform.localPosition = transform.position; // Position it above the building
        revenueText.gameObject.SetActive(true);

        // Animate the scale and position using DOTween
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(revenueText.transform.DOScale(endScale, animationDuration).SetEase(Ease.OutBack));
        //mySequence.Join(revenueText.transform.DOMove(transform.localPosition + endPositionOffset, animationDuration).SetEase(Ease.OutQuad));
        mySequence.OnComplete(() =>
        {
            // Disable the text object after the animation
            revenueText.gameObject.SetActive(false);
        });
    }
}
