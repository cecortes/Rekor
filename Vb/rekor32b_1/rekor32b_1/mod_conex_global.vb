'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Module mod_conex_global
    Public _cadena As String
    Public _conexion As New MySqlConnection

    'Función para abrir la conexión
    Public Function conexion_Global() As Boolean
        'Función para guardar el estado de la conexión
        Dim estado As Boolean = True
        'Conversión de variables globales a locales
        Dim ip As String = _varglobal.ip
        Dim user As String = _varglobal.user
        Dim pass As String = _varglobal.pass

        Try
            _cadena = ("server= " & ip.Trim() & ";user id=" & user.Trim() & ";password=" & pass.Trim() & ";database=rekor")
            _conexion = New MySqlConnection(_cadena)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        End Try
        Return estado
    End Function

    'Función para cerrar la conexión
    Public Sub cerrar()
        _conexion.Close()
    End Sub
End Module
