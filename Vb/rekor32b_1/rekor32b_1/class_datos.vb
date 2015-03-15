'*********************************************************************************************
'Esta clase se encarga de introducir los datos a la base de datos
'*********************************************************************************************

Public Class class_datos
    Private _idusuario As Integer
    Private _nombrecontacto As String
    Private _idcasas As String
    Private _telcasa As String
    Private _telcel As String

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
End Class
