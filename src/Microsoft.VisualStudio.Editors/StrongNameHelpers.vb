﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Security
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace Microsoft.Runtime.Hosting
    Friend Class StrongNameHelpers
        ' Methods
        <SecurityCritical()> _
        Public Shared Function StrongNameErrorInfo() As Integer
            Return s_lastStrongNameHR
        End Function

        <SecurityCritical()>
        Public Shared Sub StrongNameFreeBuffer(pbMemory As IntPtr)
            StrongNameUsingIntPtr.StrongNameFreeBuffer(pbMemory)
        End Sub

        <SecurityCritical()>
        Public Shared Function StrongNameGetPublicKey(pwzKeyContainer As String, pbKeyBlob As IntPtr, cbKeyBlob As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out()> ByRef pcbPublicKeyBlob As Integer) As Boolean
            Dim hr As Integer = StrongNameUsingIntPtr.StrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbPublicKeyBlob, pcbPublicKeyBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                ppbPublicKeyBlob = IntPtr.Zero
                pcbPublicKeyBlob = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameGetPublicKey(pwzKeyContainer As String, bKeyBlob As Byte(), cbKeyBlob As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out()> ByRef pcbPublicKeyBlob As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameGetPublicKey(pwzKeyContainer, bKeyBlob, cbKeyBlob, ppbPublicKeyBlob, pcbPublicKeyBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                ppbPublicKeyBlob = IntPtr.Zero
                pcbPublicKeyBlob = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameKeyDelete(pwzKeyContainer As String) As Boolean
            Dim hr As Integer = StrongName.StrongNameKeyDelete(pwzKeyContainer)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameKeyGen(pwzKeyContainer As String, dwFlags As Integer, <Out()> ByRef ppbKeyBlob As IntPtr, <Out()> ByRef pcbKeyBlob As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameKeyGen(pwzKeyContainer, dwFlags, ppbKeyBlob, pcbKeyBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                ppbKeyBlob = IntPtr.Zero
                pcbKeyBlob = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameKeyInstall(pwzKeyContainer As String, pbKeyBlob As IntPtr, cbKeyBlob As Integer) As Boolean
            Dim hr As Integer = StrongNameUsingIntPtr.StrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameKeyInstall(pwzKeyContainer As String, bKeyBlob As Byte(), cbKeyBlob As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameKeyInstall(pwzKeyContainer, bKeyBlob, cbKeyBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureGeneration(pwzFilePath As String, pwzKeyContainer As String, pbKeyBlob As IntPtr, cbKeyBlob As Integer) As Boolean
            Dim ppbSignatureBlob As IntPtr = IntPtr.Zero
            Dim cbSignatureBlob As Integer = 0
            Return StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, (ppbSignatureBlob), cbSignatureBlob)
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureGeneration(pwzFilePath As String, pwzKeyContainer As String, bKeyBlob As Byte(), cbKeyBlob As Integer) As Boolean
            Dim ppbSignatureBlob As IntPtr = IntPtr.Zero
            Dim cbSignatureBlob As Integer = 0
            Return StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, bKeyBlob, cbKeyBlob, (ppbSignatureBlob), cbSignatureBlob)
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureGeneration(pwzFilePath As String, pwzKeyContainer As String, pbKeyBlob As IntPtr, cbKeyBlob As Integer, ByRef ppbSignatureBlob As IntPtr, <Out()> ByRef pcbSignatureBlob As Integer) As Boolean
            Dim hr As Integer = StrongNameUsingIntPtr.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, pcbSignatureBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pcbSignatureBlob = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureGeneration(pwzFilePath As String, pwzKeyContainer As String, bKeyBlob As Byte(), cbKeyBlob As Integer, ByRef ppbSignatureBlob As IntPtr, <Out()> ByRef pcbSignatureBlob As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, bKeyBlob, cbKeyBlob, ppbSignatureBlob, pcbSignatureBlob)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pcbSignatureBlob = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureSize(pbPublicKeyBlob As IntPtr, cbPublicKeyBlob As Integer, <Out()> ByRef pcbSize As Integer) As Boolean
            Dim hr As Integer = StrongNameUsingIntPtr.StrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, pcbSize)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pcbSize = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureSize(bPublicKeyBlob As Byte(), cbPublicKeyBlob As Integer, <Out()> ByRef pcbSize As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameSignatureSize(bPublicKeyBlob, cbPublicKeyBlob, pcbSize)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pcbSize = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureVerification(pwzFilePath As String, dwInFlags As Integer, <Out()> ByRef pdwOutFlags As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameSignatureVerification(pwzFilePath, dwInFlags, pdwOutFlags)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pdwOutFlags = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameSignatureVerificationEx(pwzFilePath As String, fForceVerification As Boolean, <Out()> ByRef pfWasVerified As Boolean) As Boolean
            Dim hr As Integer = StrongName.StrongNameSignatureVerificationEx(pwzFilePath, fForceVerification, pfWasVerified)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                pfWasVerified = False
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameTokenFromPublicKey(bPublicKeyBlob As Byte(), cbPublicKeyBlob As Integer, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out()> ByRef pcbStrongNameToken As Integer) As Boolean
            Dim hr As Integer = StrongName.StrongNameTokenFromPublicKey(bPublicKeyBlob, cbPublicKeyBlob, ppbStrongNameToken, pcbStrongNameToken)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                ppbStrongNameToken = IntPtr.Zero
                pcbStrongNameToken = 0
                Return False
            End If
            Return True
        End Function

        <SecurityCritical()>
        Public Shared Function StrongNameTokenFromPublicKey(pbPublicKeyBlob As IntPtr, cbPublicKeyBlob As Integer, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out()> ByRef pcbStrongNameToken As Integer) As Boolean
            Dim hr As Integer = StrongNameUsingIntPtr.StrongNameTokenFromPublicKey(pbPublicKeyBlob, cbPublicKeyBlob, ppbStrongNameToken, pcbStrongNameToken)
            If (hr < 0) Then
                s_lastStrongNameHR = hr
                ppbStrongNameToken = IntPtr.Zero
                pcbStrongNameToken = 0
                Return False
            End If
            Return True
        End Function


        ' Properties
        Private Shared ReadOnly Property StrongName As IClrStrongName
            Get
                If (s_strongName Is Nothing) Then
                    s_strongName = DirectCast(RuntimeEnvironment.GetRuntimeInterfaceAsObject(New Guid("B79B0ACD-F5CD-409b-B5A5-A16244610B92"), New Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")), IClrStrongName)
                End If
                Return s_strongName
            End Get
        End Property

        Private Shared ReadOnly Property StrongNameUsingIntPtr As IClrStrongNameUsingIntPtr
            Get
                Return DirectCast(StrongName, IClrStrongNameUsingIntPtr)
            End Get
        End Property


        ' Fields
        Private Const S_OK As Integer = 0
        <SecurityCritical()>
        <ThreadStatic()>
        Private Shared s_strongName As IClrStrongName
        <ThreadStatic()>
        Private Shared s_lastStrongNameHR As Integer = 0
    End Class

    <ComImport(), SecurityCritical(), ComConversionLoss(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")> _
    Friend Interface IClrStrongNameUsingIntPtr
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromAssemblyFile(<[In](), MarshalAs(UnmanagedType.LPStr)> pszFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromAssemblyFileW(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromBlob(<[In]()> pbBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cchBlob As Integer, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=4)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromFile(<[In](), MarshalAs(UnmanagedType.LPStr)> pszFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromFileW(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromHandle(<[In]()> hFile As IntPtr, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameCompareAssemblies(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzAssembly1 As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> pwzAssembly2 As String, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwResult As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameFreeBuffer(<[In]()> pbMemory As IntPtr) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetBlob(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=2)> pbBlob As Byte(), <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetBlobFromImage(<[In]()> pbBase As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> dwLength As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbBlob As Byte(), <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetPublicKey(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In]()> pbKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbPublicKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameHashSize(<[In](), MarshalAs(UnmanagedType.U4)> ulHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef cbSize As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyDelete(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyGen(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer, <Out()> ByRef ppbKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyGenEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwKeySize As Integer, <Out()> ByRef ppbKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyInstall(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In]()> pbKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureGeneration(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In]()> pbKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <[In](), Out()> ppbSignatureBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSignatureBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureGenerationEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> wszFilePath As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> wszKeyContainer As String, <[In]()> pbKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <[In](), Out()> ppbSignatureBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSignatureBlob As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureSize(<[In]()> pbPublicKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbPublicKeyBlob As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSize As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerification(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.U4)> dwInFlags As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwOutFlags As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerificationEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.I1)> fForceVerification As Boolean, <Out(), MarshalAs(UnmanagedType.I1)> ByRef fWasVerified As Boolean) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerificationFromImage(<[In]()> pbBase As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> dwLength As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwInFlags As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwOutFlags As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromAssembly(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromAssemblyEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbPublicKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromPublicKey(<[In]()> pbPublicKeyBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cbPublicKeyBlob As Integer, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer) As Integer
    End Interface
    <ComImport(), SecurityCritical(), ComConversionLoss(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")> _
    Friend Interface IClrStrongName
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromAssemblyFile(<[In](), MarshalAs(UnmanagedType.LPStr)> pszFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromAssemblyFileW(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromBlob(<[In]()> pbBlob As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> cchBlob As Integer, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=4)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromFile(<[In](), MarshalAs(UnmanagedType.LPStr)> pszFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromFileW(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function GetHashFromHandle(<[In]()> hFile As IntPtr, <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef piHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbHash As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cchHash As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pchHash As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameCompareAssemblies(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzAssembly1 As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> pwzAssembly2 As String, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwResult As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameFreeBuffer(<[In]()> pbMemory As IntPtr) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetBlob(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=2)> pbBlob As Byte(), <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetBlobFromImage(<[In]()> pbBase As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> dwLength As Integer, <Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbBlob As Byte(), <[In](), Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameGetPublicKey(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=2)> pbKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbPublicKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameHashSize(<[In](), MarshalAs(UnmanagedType.U4)> ulHashAlg As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef cbSize As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyDelete(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyGen(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer, <Out()> ByRef ppbKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyGenEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwKeySize As Integer, <Out()> ByRef ppbKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameKeyInstall(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=2)> pbKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureGeneration(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> pwzKeyContainer As String, <[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <[In](), Out()> ppbSignatureBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSignatureBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureGenerationEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> wszFilePath As String, <[In](), MarshalAs(UnmanagedType.LPWStr)> wszKeyContainer As String, <[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=3)> pbKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbKeyBlob As Integer, <[In](), Out()> ppbSignatureBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSignatureBlob As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwFlags As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureSize(<[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> pbPublicKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbPublicKeyBlob As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbSize As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerification(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.U4)> dwInFlags As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwOutFlags As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerificationEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <[In](), MarshalAs(UnmanagedType.I1)> fForceVerification As Boolean, <Out(), MarshalAs(UnmanagedType.I1)> ByRef fWasVerified As Boolean) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameSignatureVerificationFromImage(<[In]()> pbBase As IntPtr, <[In](), MarshalAs(UnmanagedType.U4)> dwLength As Integer, <[In](), MarshalAs(UnmanagedType.U4)> dwInFlags As Integer, <Out(), MarshalAs(UnmanagedType.U4)> ByRef dwOutFlags As Integer) As <MarshalAs(UnmanagedType.U4)> Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromAssembly(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromAssemblyEx(<[In](), MarshalAs(UnmanagedType.LPWStr)> pwzFilePath As String, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer, <Out()> ByRef ppbPublicKeyBlob As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbPublicKeyBlob As Integer) As Integer
        <PreserveSig(), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)> _
        Function StrongNameTokenFromPublicKey(<[In](), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> pbPublicKeyBlob As Byte(), <[In](), MarshalAs(UnmanagedType.U4)> cbPublicKeyBlob As Integer, <Out()> ByRef ppbStrongNameToken As IntPtr, <Out(), MarshalAs(UnmanagedType.U4)> ByRef pcbStrongNameToken As Integer) As Integer
    End Interface

End Namespace

