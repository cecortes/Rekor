Public Class _varglobal
    '**************************************************************************************
    'Creamos una clase dentro del proyecto: Agregar -> Clase.
    'En esta clase crearemos todas las globales que se compartiran entre los formularios
    'del proyecto.
    '**************************************************************************************
    Public Shared ip As String
    Public Shared user As String
    Public Shared pass As String
    'Variable para la llave primaria de la tabla visitas de mysql
    Public Shared visitas_index As Integer
    'Variable para guardar el nombre del puerto serial
    Public Shared puertoSerial As String
    'Variable para abrir el puerto serial
    Public Shared edoConexion As Boolean
End Class
