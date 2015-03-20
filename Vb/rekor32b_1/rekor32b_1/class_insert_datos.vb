'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Public Class class_insert_datos
    Private _adaptador As New MySqlDataAdapter

    Public Function insertarDatos(ByVal datos As class_datos) As Boolean
        'Esta función inserta los datos en la tabla MySql "usuarios"
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

    Public Function insertarVisitas(ByVal datos As class_datos) As Boolean
        'Esta función inserta los datos en la tabla MySql "visitas"
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.InsertCommand = New MySqlCommand("insert into visitas2 (nombrevisita, tipoid, fechaingreso, horaingreso, horasalida, ncasas, snrfid) values (@nombrevisita, @tipoid, @fechaingreso, @horaingreso, @horasalida, @ncasas, @snrfid)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@nombrevisita", MySqlDbType.VarChar, 200).Value = datos.nombrevisita
            _adaptador.InsertCommand.Parameters.Add("@tipoid", MySqlDbType.VarChar, 10).Value = datos.tipoid
            _adaptador.InsertCommand.Parameters.Add("@fechaingreso", MySqlDbType.Date).Value = datos.fechaingreso
            _adaptador.InsertCommand.Parameters.Add("@horaingreso", MySqlDbType.VarChar, 9).Value = datos.horaingreso
            _adaptador.InsertCommand.Parameters.Add("@horasalida", MySqlDbType.VarChar, 9).Value = datos.horasalida
            _adaptador.InsertCommand.Parameters.Add("@ncasas", MySqlDbType.VarChar, 6).Value = datos.ncasas
            _adaptador.InsertCommand.Parameters.Add("@snrfid", MySqlDbType.VarChar, 100).Value = datos.snrfid
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

    Public Function eliminarDatos(ByVal datos As class_datos) As Boolean
        'Esta función elimina los datos de la tabla MySql
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.DeleteCommand = New MySqlCommand("delete from usuarios where idcasas = @idcasas", _conexion)
            _adaptador.DeleteCommand.Parameters.Add("@idcasas", MySqlDbType.VarChar, 6).Value = datos.idcasas
            _conexion.Open()
            _adaptador.DeleteCommand.Connection = _conexion
            _adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function

    Public Function actualizarUsuario(ByVal datos As class_datos) As Boolean
        'Esta función actualiza los datos señalados de la tabla MySql
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.UpdateCommand = New MySqlCommand("update usuarios set nombrecontacto=@nombrecontacto,idcasas=@idcasas,telcasa=@telcasa,telcel=@telcel where idusuario=@idusuario", _conexion)
            _adaptador.UpdateCommand.Parameters.Add("@idusuario", MySqlDbType.Int32, 6).Value = datos.idusuario
            _adaptador.UpdateCommand.Parameters.Add("@nombrecontacto", MySqlDbType.VarChar, 200).Value = datos.nombrecontacto
            _adaptador.UpdateCommand.Parameters.Add("@idcasas", MySqlDbType.VarChar, 6).Value = datos.idcasas
            _adaptador.UpdateCommand.Parameters.Add("@telcasa", MySqlDbType.VarChar, 10).Value = datos.telcasa
            _adaptador.UpdateCommand.Parameters.Add("@telcel", MySqlDbType.VarChar, 10).Value = datos.telcel
            _conexion.Open()
            _adaptador.UpdateCommand.Connection = _conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function

    Public Function buscarIdCasas(ByVal datos As class_datos) As String
        'Esta función selecciona los registros de la tabla por el idcasas
        Dim estado As String = "COLA"
        Try
            conexion_Global()
            _adaptador.SelectCommand = New MySqlCommand("select nombrecontacto from usuarios where idcasas=@idcasas", _conexion)
            _adaptador.SelectCommand.Parameters.Add("@idcasas", MySqlDbType.VarChar, 6).Value = datos.idcasas
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = ""
        Finally
            cerrar()
        End Try
        Return estado
    End Function
End Class
