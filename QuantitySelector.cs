using UnityEngine;
using TMPro;
using System.Collections;

public class QuantityController : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    private int quantity = 1;

    void OnEnable()
    {
        // 텍스트 준비될 때까지 기다림
        StartCoroutine(InitQuantity());
    }

    IEnumerator InitQuantity()
    {
        yield return null; // 1프레임 기다림 (TMP 텍스트 초기화 완료되게)

        if (quantityText != null)
        {
            string raw = quantityText.text.Trim();

            if (int.TryParse(raw, out int parsed))
            {
                quantity = parsed;
                Debug.Log("시작 수량 설정됨: " + quantity);
            }
            else
            {
                quantity = 1;
                Debug.LogWarning("텍스트 숫자 파싱 실패: " + raw + " → 기본값 1로 시작");
            }
        }
        else
        {
            Debug.LogWarning("quantityText 연결 안 됨");
        }

        UpdateText();
    }

    public void Increase()
    {
        quantity++;
        UpdateText();
        Debug.Log("수량 증가됨: " + quantity);
    }

    public void Decrease()
    {
        if (quantity > 1)
        {
            quantity--;
            UpdateText();
            Debug.Log("수량 감소됨: " + quantity);
        }
        else
        {
            Debug.Log("수량은 1보다 작아질 수 없음");
        }
    }

    void UpdateText()
    {
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString();
        }
    }
}
