using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    private string currentInput = "";

    private double result = 0.0;

    /// <summary>
    /// The `OnButtonClick` function in C# handles different button clicks by either calculating the result,
    /// clearing the input, backspacing, or appending the button value to the current input.
    /// </summary>
    /// <param name="buttonValue">The `buttonValue` parameter is a string that represents the value of the
    /// button that was clicked in a user interface. The method `OnButtonClick` is used to handle different
    /// actions based on the value of the button clicked. If the button value is "=", it calculates the
    /// result, if it is "</param>

    public void OnButtonClick(string buttonValue)
    {
        if (buttonValue == "=")
        {
            // Calculate the result
            CalculateResult();
        }
        else if (buttonValue == "AC")
        {
            // Clear current input
            ClearInput();
        }
        else if (buttonValue == "Del")
        {
            // Remove the last character (backspace)
            Backspace();
        }
        else
        {
            // Append button value to the current input
            currentInput += buttonValue;
            UpdateDisplay();
        }
    }

    /// <summary>
    /// The CalculateResult function in C# handles mathematical calculations, including modulo operations
    /// and percentage calculations.
    /// </summary>

    public void CalculateResult()
    {
        try
        {
            // Check and handle modulo (%) operation
            if (currentInput.Contains("mod"))
            {
                HandleModulo();
            }
            else
            {
                // Replace "%" with "/100" for percentage calculations
                string expression = currentInput.Replace("%", "/100");

                // Evaluate the expression
                result = System.Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
                currentInput = result.ToString();
                UpdateDisplay();
            }
        }
        catch (System.Exception)
        {
            currentInput = "Error";
            UpdateDisplay();
        }
    }

    /// <summary>
    /// The HandleModulo function in C# splits an input string by "mod" to calculate the modulo operation
    /// between two operands and updates the display with the result or an error message if the input is
    /// invalid.
    /// </summary>
    private void HandleModulo()
    {
        try
        {
            // Split the input by "mod" to get the two operands
            string[] parts = currentInput.Split(new string[] { "mod" }, System.StringSplitOptions.None);

            if (parts.Length == 2)
            {
                double leftOperand = double.Parse(parts[0]);
                double rightOperand = double.Parse(parts[1]);

                // Calculate modulo for decimals
                result = leftOperand % rightOperand;
                currentInput = result.ToString();
                UpdateDisplay();
            }
            else
            {
                throw new System.Exception("Invalid mod expression");
            }
        }
        catch (System.Exception)
        {
            currentInput = "Error";
            UpdateDisplay();
        }
    }

    /// <summary>
    /// The code snippet contains C# methods for clearing input, backspacing, and updating display text
    /// in a program.
    /// </summary>
    private void ClearInput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }

    private void Backspace()
    {
        if (currentInput.Length > 0)
        {
            // Remove the last character
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        if (displayText != null)
        {
            displayText.text = currentInput;
        }
        else
        {
            Debug.LogError("Display Text is not assigned in the Inspector.");
        }
    }
}
