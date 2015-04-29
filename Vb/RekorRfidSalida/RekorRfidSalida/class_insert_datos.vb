'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Public Class class_insert_datos
    Private _adaptador As New MySqlDataAdapter

    Public Function eliminarDatos(ByVal datos As class_datos) As Boolean
        'Esta función elimina los datos de la tabla MySql
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.DeleteCommand = New MySqlCommand("delete from visitas2 where snrfid = @snrfid", _conexion)
            _adaptador.DeleteCommand.Parameters.Add("@snrfid", MySqlDbType.VarChar, 100).Value = datos.snrfid
            _conexion.Open()
            _adaptador.DeleteCommand.Connection = _conexion
            _adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function

    Public Function insertarVisitas(ByVal datos As class_datos) As Boolean
        'Esta función inserta los datos en la tabla MySql "visitas3"
        Dim estado As Boolean = True
        Try
            conexion_Global()
            _adaptador.InsertCommand = New MySqlCommand("insert into visitas3 (nombrevisita, tipoid, fechaingreso, horaingreso, horasalida, ncasas, snrfid, PicRostro, PicId) values (@nombrevisita, @tipoid, @fechaingreso, @horaingreso, @horasalida, @ncasas, @snrfid, @PicRostro, @PicId)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@nombrevisita", MySqlDbType.VarChar, 200).Value = datos.nombrevisita
            _adaptador.InsertCommand.Parameters.Add("@tipoid", MySqlDbType.VarChar, 10).Value = datos.tipoid
            _adaptador.InsertCommand.Parameters.Add("@fechaingreso", MySqlDbType.Date).Value = datos.fechaingreso
            _adaptador.InsertCommand.Parameters.Add("@horaingreso", MySqlDbType.VarChar, 9).Value = datos.horaingreso
            _adaptador.InsertCommand.Parameters.Add("@horasalida", MySqlDbType.VarChar, 9).Value = datos.horasalida
            _adaptador.InsertCommand.Parameters.Add("@ncasas", MySqlDbType.VarChar, 6).Value = datos.ncasas
            _adaptador.InsertCommand.Parameters.Add("@snrfid", MySqlDbType.VarChar, 100).Value = datos.snrfid
            _adaptador.InsertCommand.Parameters.Add("@PicRostro", MySqlDbType.VarChar, 200).Value = datos.PicRostro
            _adaptador.InsertCommand.Parameters.Add("@PicId", MySqlDbType.VarChar, 200).Value = datos.PicId
            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekor 32bits Módulo de Salida", MessageBoxButtons.OK, MessageBoxIcon.Error)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function
End Class
