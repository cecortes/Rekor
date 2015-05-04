'*********************************************************************************************
'Esta módulo se encarga de buscar los datos en la base de datos
'*********************************************************************************************
'Importamos las referencias necesarias para trabajar con mysql
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Module modulo_consulta
    Private _adaptador As New MySqlDataAdapter
    Public _dtsdatos, _dtscbx As New DataSet     'Se guarda en la memoria interna
    Public _dtvdatos As New DataView    'Sirve para mostrar los datos de la memoria interna

    Public Sub consulta_datos()
        'Creamos una consulta para acceder a la tabla MySql usuarios
        Try
            'Llamamos a la conexión global
            conexion_Global()
            _adaptador.SelectCommand = New MySqlCommand("select * from usuarios", _conexion)
            _adaptador.Fill(_dtsdatos)
            'Llenamos los datos en el combobox
            _adaptador.Fill(_dtscbx, "usuarios")
            _dtvdatos.Table = _dtsdatos.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            cerrar()
        End Try
    End Sub

    Public Sub consulta_visitas()
        'Creamos una consulta para acceder a la tabla MySql visitas3
        Try
            'Llamamos a la conexión global
            conexion_Global()
            _adaptador.SelectCommand = New MySqlCommand("select idvisita, nombrevisita, tipoid, fechaingreso, horaingreso, horasalida from visitas3 where ncasas = @ncasas AND fechaingreso >= @fechaingreso AND fechaingreso <= @fechafinal ORDER BY fechaingreso DESC", _conexion)
            _adaptador.SelectCommand.Parameters.Add("@ncasas", MySqlDbType.VarChar, 6).Value = _varglobal.ncasas
            _adaptador.SelectCommand.Parameters.Add("@fechaingreso", MySqlDbType.Date).Value = _varglobal.FechaInicio
            _adaptador.SelectCommand.Parameters.Add("@fechafinal", MySqlDbType.Date).Value = _varglobal.FechaFinal
            _adaptador.Fill(_dtsdatos)
            _dtvdatos.Table = _dtsdatos.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "Rekór RFID & WebCam", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            cerrar()
        End Try
    End Sub
End Module