'*********************************************************************************************
'Esta clase se encarga de introducir los datos a la base de datos
'*********************************************************************************************

Public Class class_datos
    '************************ Datos para la tabla usuarios **********************************
    Private _idusuario As Integer
    Private _nombrecontacto As String
    Private _idcasas As String
    Private _telcasa As String
    Private _telcel As String
    '************************* Datos para la tabla visitas **********************************
    Private _idvisita As Integer
    Private _nombrevisita As String
    Private _tipoid As String
    Private _fechaingreso As Date
    Private _horaingreso As String
    Private _horasalida As String
    Private _ncasas As String
    Private _snrfid As String
    'Private _fotorostro As Byte
    'Private _fotoid As Byte

    Public Property idusuario() As Integer
        Get
            Return _idusuario
        End Get
        Set(ByVal value As Integer)
            _idusuario = value
        End Set
    End Property

    Public Property nombrecontacto() As String
        Get
            Return _nombrecontacto
        End Get
        Set(ByVal value As String)
            _nombrecontacto = value
        End Set
    End Property

    Public Property idcasas() As String
        Get
            Return _idcasas
        End Get
        Set(ByVal value As String)
            _idcasas = value
        End Set
    End Property

    Public Property telcasa() As String
        Get
            Return _telcasa
        End Get
        Set(ByVal value As String)
            _telcasa = value
        End Set
    End Property

    Public Property telcel() As String
        Get
            Return _telcel
        End Get
        Set(ByVal value As String)
            _telcel = value
        End Set
    End Property

    Public Property idvisita() As Integer
        Get
            Return _idvisita
        End Get
        Set(ByVal value As Integer)
            _idvisita = value
        End Set
    End Property

    Public Property nombrevisita() As String
        Get
            Return _nombrevisita
        End Get
        Set(ByVal value As String)
            _nombrevisita = value
        End Set
    End Property

    Public Property tipoid() As String
        Get
            Return _tipoid
        End Get
        Set(ByVal value As String)
            _tipoid = value
        End Set
    End Property

    Public Property fechaingreso() As Date
        Get
            Return _fechaingreso
        End Get
        Set(ByVal value As Date)
            _fechaingreso = value
        End Set
    End Property

    Public Property horaingreso() As String
        Get
            Return _horaingreso
        End Get
        Set(ByVal value As String)
            _horaingreso = value
        End Set
    End Property

    Public Property horasalida() As String
        Get
            Return _horasalida
        End Get
        Set(ByVal value As String)
            _horasalida = value
        End Set
    End Property

    Public Property ncasas() As String
        Get
            Return _ncasas
        End Get
        Set(ByVal value As String)
            _ncasas = value
        End Set
    End Property

    Public Property snrfid() As String
        Get
            Return _snrfid
        End Get
        Set(ByVal value As String)
            _snrfid = value
        End Set
    End Property
End Class
