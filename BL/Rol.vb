Public Class Rol
    Public Shared Function GetAll() As ML.Result
        Dim result As New ML.Result()
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.RolGetAll().ToList()
                result.Objetos = New List(Of Object)

                If query IsNot Nothing Then
                    For Each obj In query
                        Dim rol As ML.Rol = New ML.Rol()
                        rol.IdRol = obj.IdRol
                        rol.Nombre = obj.Nombre

                        result.Objetos.Add(rol)
                    Next obj

                    result.Correct = True
                Else
                    result.Correct = False
                End If
            End Using

        Catch ex As Exception
            result.Correct = False
            result.Message = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function
End Class
