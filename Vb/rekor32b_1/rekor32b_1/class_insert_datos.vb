'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class class_insert_datos
    Private _adaptador As New MySqlDataAdapter

    Public Function insertarDatos(ByVal datos As class_datos) As Boolean
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.InsertCommand = New MySqlCommand("insert into usuarios (nombrecontacto,idcasas,telcasa,telcel) values (@nombrecontacto,@idcasas,@telcasa,@telcel)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@nombrecontacto", MySqlDbType.VarChar, 200).Value = datos.nombrecontacto
            _adaptador.InsertCommand.Parameters.Add("@idcasas", MySqlDbType.VarChar, 6).Value = datos.idcasas
            _adaptador.InsertCommand.Parameters.Add("@telcasa", MySqlDbType.VarChar, 10).Value = datos.telcasa
            _adaptador.InsertCommand.Parameters.Add("@telcel", MySqlDbType.VarChar, 10).Value = datos.telcel
            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function
End Class
