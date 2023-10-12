namespace VasaCSharp.Random.Interface;

public interface IPasswordGenerator
{
    void GetValidUserInput(out int userInput);
    string GenerateRandomPassword(int passwordLength);
}