using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button[] characterButtons;  // �������͡����Ф�

    void Start()
    {
        // ������§�������Ѻ�ѧ��ѹ���͡����Ф�
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i + 1; // ����Ţ����Ф� (������鹨ҡ 1)
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    // �ѧ��ѹ�����㹡�����͡����Ф�
    public void SelectCharacter(int characterNumber)
    {
        // �ѹ�֡����Ф÷�����͡� DataHandlerSingleton
        DataHandlerSingleton.Instance.selectedCharacter = characterNumber;

        // ����ͧ�ʴ���ͤ�������� Console
    }
}