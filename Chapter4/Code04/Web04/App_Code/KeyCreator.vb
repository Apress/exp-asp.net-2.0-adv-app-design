Imports System
Imports System.Text
Imports System.Security.Cryptography


Public Class KeyCreator

    Public Shared function CreateMachineKey() as string
        Dim commandLineArgs As String()
        commandLineArgs = System.Environment.GetCommandLineArgs()

        Dim decryptionKey As String
        decryptionKey = CreateKey(23)
        Dim validationKey As String
        validationKey = CreateKey(99)

        Return String.Format("<machineKey validationKey=""{0}"" decryptionKey=""{1}"" validation=""SHA1""/>", _
        validationKey, decryptionKey)
    End Function

    Public Shared Function CreateKey(ByVal numBytes As Integer) As String
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim buff(numBytes - 1) As Byte

        rng.GetBytes(buff)

        Return BytesToHexString(buff)
    End Function

    Public Shared Function BytesToHexString(ByVal bytes As Byte()) As String
        Dim hexString As StringBuilder = New StringBuilder(64)
        Dim counter As Integer

        For counter = 0 To bytes.Length - 1
            hexString.Append(String.Format("{0:X2}", bytes(counter)))
        Next

        Return hexString.ToString()
    End Function

End Class
