using UnityEngine;
using TMPro;
using System.Collections;

public class QuantityController : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    private int quantity = 1;

    void OnEnable()
    {
        // �ؽ�Ʈ �غ�� ������ ��ٸ�
        StartCoroutine(InitQuantity());
    }

    IEnumerator InitQuantity()
    {
        yield return null; // 1������ ��ٸ� (TMP �ؽ�Ʈ �ʱ�ȭ �Ϸ�ǰ�)

        if (quantityText != null)
        {
            string raw = quantityText.text.Trim();

            if (int.TryParse(raw, out int parsed))
            {
                quantity = parsed;
                Debug.Log("���� ���� ������: " + quantity);
            }
            else
            {
                quantity = 1;
                Debug.LogWarning("�ؽ�Ʈ ���� �Ľ� ����: " + raw + " �� �⺻�� 1�� ����");
            }
        }
        else
        {
            Debug.LogWarning("quantityText ���� �� ��");
        }

        UpdateText();
    }

    public void Increase()
    {
        quantity++;
        UpdateText();
        Debug.Log("���� ������: " + quantity);
    }

    public void Decrease()
    {
        if (quantity > 1)
        {
            quantity--;
            UpdateText();
            Debug.Log("���� ���ҵ�: " + quantity);
        }
        else
        {
            Debug.Log("������ 1���� �۾��� �� ����");
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
