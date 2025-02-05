
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentDataManager : MonoBehaviour
{
    public InputField nameInput;
    public InputField ageInput;
    public InputField studentNumberInput;
    public InputField studentSection;

    public InputField searchInput;

    public Text resultText;

    public void SaveStudentData()
    {
        string studentName = nameInput.text;
        int age, studentNumber;
        string Section = studentSection.text;
        if (!string.IsNullOrEmpty(studentName) &&
        int.TryParse(ageInput.text, out age) &&
        int.TryParse(studentNumberInput.text, out studentNumber) &&
        !string.IsNullOrEmpty(Section))
        {
            PlayerPrefs.SetInt(studentName + "Age", age);
            PlayerPrefs.SetInt(studentName + "Student Number", studentNumber);
            PlayerPrefs.SetString(studentName + "Student Section", Section);
            PlayerPrefs.Save();
            Debug.Log("Student Data Saved: " + studentName);
        }
        else
        {
            Debug.Log("Invalid Input");
        }
    }
    public void LoadStudentData()
    {
        string studentName = searchInput.text;
        if (PlayerPrefs.HasKey(studentName + "Age"))
        {
            int age = PlayerPrefs.GetInt(studentName + "Age");
            int studentNumber = PlayerPrefs.GetInt(studentName + "Student Number");
            string Section = PlayerPrefs.GetString(studentName + "Student Number");

            resultText.text = $"Name: {studentName}\nAge: {age}\nSN: {studentNumber}\nSection: {Section}m";
        }
        else
        {
            resultText.text = "Student Not Found";
        }
    }
}
