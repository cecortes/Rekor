'******************************************************************************************************************
'DataVision: Segunda prueba para integrar la captura de imágenes por medio de la webcam al software rekor.
'               - Se inicia la cámara web por medio de una función que se llama al hacer click en Iniciar
'               - Se detiene la cámara por medio de una función que la llama el click en Detener
'               - Se guarda la imágen por medio de otra función que se llama con el click en Guardar
'               - La imágen se guarda en un directorio predefinido y en formato .jpg
'
'Autor: César López (Abril 2015)
'Licencia: Copyright (C) César López Cortés.
'******************************************************************************************************************

'Importamos las librerías necesarias
Imports System.Runtime.InteropServices

Public Class Form1

    'Los nombres y valores de estas constantes están definidas directamente por la API en este caso por user32.dll y por avicap32.dll
    'Se recomienda mantener los nombres y los valores no pueden ser modificados.
    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0      'Variable para el manejo del dispositivo
    Dim hHwnd As Integer            'Variable para el manejo del Preview Capture

    '*************************************************************************************
    'Declaración de funciones que se encuentran dentro de la API user32.dll y avicap32.dll
    '*************************************************************************************
    'Función para obtener la lista de los dispositivos USB de video dentro del API avicap32.dll
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean
    'Función para la captura de video dentro del API avicap32.dll
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    'Función para mandar comandos a la cámara Usb
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer      'Funciona en Windows 7 pero es necesario importar System.Runtime.InteropServices
    'Función para el tamaño de la ventana dentro del API user32.dll
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    'Función para destruir la ventana dentro del API user32.dll
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Función que se llama cuando el programa es iniciado

        'Función para obtener la lista de cámaras usb conectadas al sistema
        obtnerUsbCam()
    End Sub

    Public Sub obtnerUsbCam()
        'Función para obtener la lista de cámaras usb conectadas al sistema
        listUsbCam()

        'Verificamos si existen dispositivos encontrados
        If lbUsbCam.Items.Count > 0 Then
            'Mostramos mensaje al usuario
            MessageBox.Show("Existen " & lbUsbCam.Items.Count.ToString & " WebCams encontradas")
            'Seleccionamos la primer cámara encontrada
            lbUsbCam.SelectedIndex = 0
        Else
            'Mostramos mensaje al usuario que no se encontró ningún dispositivo
            MessageBox.Show("WebCam no encontradas")
            'Añadimos el mensaje en el listbox
            lbUsbCam.Items.Add("Ninguna WebCam encontrada")
        End If

        'Hacemos que la imágen se ajuste al tamaño del picture box
        pbxImagen.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Public Sub listUsbCam()
        'Función para obtener en forma de lista las cámaras Usb conectadas al sistema
        Dim strName As String = Space(100)      'Variable para guardar el nombre del dispositivo
        Dim strVer As String = Space(100)       'Variable para guardar la versión del dispositivo
        Dim bReturn As Boolean                  'Variable para guardar el resultado de la función

        Dim x As Integer = 0                    'Contador de dispositivos encontrados
        'Ciclo para cargar la lista de dispositivos
        Do
            'Obtiene el nombre del driver y la versión
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)

            If bReturn Then
                'Si encuentra un dispositivo lo agrega a la lista del lbUsbCam
                lbUsbCam.Items.Add(strName.Trim)
                'Incrementamos el contador de dispositivos
                x += 1
            End If
            'Finaliza el ciclo cuando no encuentra más dispositivos
        Loop Until bReturn = False
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'Función para iniciar la cámara Usb
        iniciarWebCam()
    End Sub

    Public Sub iniciarWebCam()
        'Función que inicia la cámara Web que este seleccionada

        'Obtenemos el indice del dispositivo seleccionado en la lista de lbUsbCam
        iDevice = lbUsbCam.SelectedIndex

        'Iniciamos la captura y la mostramos en el picture box pbxImagen
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, pbxImagen.Handle.ToInt32, 0)

        'Dentro de un If intentamos conectarnos al dispòsitivo Usb
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            'Configura la escala del Preview
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            'Configura el Preview Rate en milisegundos
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
            'Inicia el Preview de la cámara Usb
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
            'Re dimensiona la ventana al tamaño del picture box pbxImagen
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pbxImagen.Width, pbxImagen.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            'Si existe algún error destruimos el Handler de la ventana
            DestroyWindow(hHwnd)
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        'Llamamos a la función para detener la cámara Usb seleccionada
        detenerWebCam()
    End Sub

    Public Sub detenerWebCam()
        'Función para detener la cámara USB y su Preview

        'Detenemos la cámara Usb enviando el comando necesario
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

        'Destruimos el Handler de la ventana Preview
        DestroyWindow(hHwnd)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Llamamos a la función para guardar la captura de la cámar USB seleccionada
        guardarWebCam()
    End Sub

    Public Sub guardarWebCam()
        'Función para guardar la captura de la cámara Usb Seleccionada en formato .jpg y dentro de un directorio predefinido
        Dim dataClipBoard As IDataObject    'Variable para manejar los datos del Porta Papeles o ClipBoard
        Dim bmpData As Image                'Variable para guardar los datos como Imágen Bmp
        Dim path As String = "C:\Users\N30\Documents\test\"                  'Variable para guardar la dirección del directorio donde se guarda la imágen

        'Copiamos la imágen de la cámara al ClipBoard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        'Obtenemos la imágen del ClipBoard y la guardamos como Imágen BMP
        dataClipBoard = Clipboard.GetDataObject()

        'Dentro de un If verificamos que se guardo la variable como Imágen BMP
        If dataClipBoard.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            'Realizamos la copia del ClipBoard y cambiamos de tipo a BMP dentro de la variable bmpData que es un Image
            bmpData = CType(dataClipBoard.GetData(GetType(System.Drawing.Bitmap)), Image)
            'Mostramos la imágen BMP dentro del picture box
            pbxImagen.Image = bmpData
            'Cerramos la vista previa de la cámara
            detenerWebCam()
            'Guardamos el archivo como .jpg dentro del directorio pre establecido
            bmpData.Save(path & "tst" & ".jpeg", Imaging.ImageFormat.Jpeg)
        End If
    End Sub
End Class
