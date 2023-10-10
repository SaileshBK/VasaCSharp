namespace VasaCSharp.Random.Interface;

public interface IRandomPasswordGenerator
{
    void GetValidUserInput(out int userInput);
    void GenerateRandomPassword(int passwordLength);
}