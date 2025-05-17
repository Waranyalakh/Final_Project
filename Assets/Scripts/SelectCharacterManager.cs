using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCharacterManager : MonoBehaviour
{
    public GameObject[] characters; // Prefab หรือ GameObject ของตัวละคร
    public GameObject[] NameDescribe; // UI สำหรับแสดงรายละเอียดตัวละคร (1 ตัวละคร = 1 Image)
    public GameObject playButton; // ปุ่ม Play

    private int selectedIndex = -1;

    void Start()
    {
        HideAllCharacters();
        HideAllNameDescribe();
        if (playButton != null) playButton.SetActive(false);
    }

    public void SelectCharacter(int index)
    {
        HideAllCharacters();
        HideAllNameDescribe();

        selectedIndex = index;
        characters[selectedIndex].SetActive(true); // แสดงตัวละครที่ถูกเลือก
        NameDescribe[selectedIndex].SetActive(true); // แสดง Image ของตัวละครที่ถูกเลือก

        if (playButton != null) playButton.SetActive(true);

        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        PlayerPrefs.Save();
    }

    public void LoadSelectMap()
    {
        if (selectedIndex >= 0)
        {
            PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
            PlayerPrefs.Save();
            Debug.Log("Selected Character Index SAVED: " + selectedIndex);

            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }

    void HideAllCharacters()
    {
        foreach (var character in characters)
        {
            character.SetActive(false);
        }
    }

    void HideAllNameDescribe()
    {
        foreach (var describe in NameDescribe)
        {
            describe.SetActive(false);
        }
    }
}