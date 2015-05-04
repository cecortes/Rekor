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
    'Variable para guardar el nombre del puerto serial
    Public Shared puertoSerial As String
    'Variable para abrir el puerto serial
    Public Shared edoConexion As Boolean
    'Variable para guardar el número de casa seleccionado
    Public Shared ncasas As String
    'Variable para guardar el inicio del periodo
    Public Shared FechaInicio As Date
    'Variable para guardar el final del periodo
    Public Shared FechaFinal As Date
End Class
