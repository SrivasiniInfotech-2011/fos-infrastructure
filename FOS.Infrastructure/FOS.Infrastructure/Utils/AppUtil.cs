using FOS.Models.Constants;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace FOS.Infrastructure.Services.Utils;

/// <summary>Common helper methods</summary>
public static class AppUtil
{
    /// <summary>Returns the name of the caller</summary>
    /// <param name="methodName">Caller method name</param>
    /// <returns><see cref="string"/></returns>
    public static string GetCurrentMethodName([CallerMemberName] string methodName = "") => methodName;

    /// <summary>
    /// Decrypts a String
    /// </summary>
    /// <param name="strText">Text to Decrypt.</param>
    /// <returns>Returns Decrypted String.</returns>
    public static string DecryptString(string strText) => Decrypt(strText, Constants.Passphrase);

    /// <summary>
    /// Decrypts a String
    /// </summary>
    /// <param name="strText">Text to Decrypt.</param>
    /// <returns>Returns Decrypted String.</returns>
    private static string Decrypt(string strText, string sDecrKey)
    {
        byte[] byKey;
        byte[] IV = { 65, 6, 12, 34, 28, 232, 34, 158, 185, 192, 51, 74, 236, 28, 55, 9 };
        byte[] inputByteArray = new byte[strText.Length];
        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Trim());
            var des = new TripleDESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.Unicode;

            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}