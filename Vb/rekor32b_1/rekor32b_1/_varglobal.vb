
Public Class _varglobal
    '**************************************************************************************
    'Creamos una clase dentro del proyecto: Agregar -> Clase.
    'En esta clase crearemos todas las globales que se compartiran entre los formularios
    'del proyecto.
    '**************************************************************************************
    Public Shared ip As String
    Public Shared user As String
    Public Shared pass As String
    'Variable para la llave primaria de la tabla usuarios de mysql
    Public Shared usuario_index As Integer
End Class
