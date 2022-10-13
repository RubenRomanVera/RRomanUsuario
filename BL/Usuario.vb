Public Class Usuario
    Public Shared Function Add(ByVal usuario As ML.Usuario)
        Dim result As New ML.Result
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.UsuarioAdd(nombre:=usuario.Nombre, apellidoPaterno:=usuario.ApellidoPaterno, apellidoMaterno:=usuario.ApellidoMaterno, idRol:=usuario.Rol.IdRol)

                If query > 0 Then
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

    Public Shared Function Update(ByVal usuario As ML.Usuario)
        Dim result As New ML.Result
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.UsuarioUpdate(idUsuario:=usuario.IdUsuario, nombre:=usuario.Nombre, apellidoPaterno:=usuario.ApellidoPaterno, apellidoMaterno:=usuario.ApellidoMaterno, idRol:=usuario.Rol.IdRol)

                If query > 0 Then
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

    Public Shared Function Delete(IdUsuario As Integer?)
        Dim result As New ML.Result
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.UsuarioDelete(IdUsuario)

                If query > 0 Then
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

    Public Shared Function GetAll() As ML.Result
        Dim result As New ML.Result()
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.UsuarioGetAll().ToList()
                result.Objetos = New List(Of Object)

                If query IsNot Nothing Then
                    For Each obj In query
                        Dim usuario As ML.Usuario = New ML.Usuario()
                        usuario.IdUsuario = obj.IdUsuario
                        usuario.Nombre = obj.NombreUsuario
                        usuario.ApellidoPaterno = obj.ApellidoPaterno
                        usuario.ApellidoMaterno = obj.ApellidoMaterno

                        usuario.Rol = New ML.Rol()
                        usuario.Rol.IdRol = obj.IdRol
                        usuario.Rol.Nombre = obj.NombreRol

                        result.Objetos.Add(usuario)
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

    Public Shared Function GetById(IdUsuario As Integer?) As ML.Result
        Dim result As New ML.Result()
        Try
            Using context As DL.UsuarioEntities1 = New DL.UsuarioEntities1()
                Dim query = context.UsuarioGetById(IdUsuario).FirstOrDefault()
                If query IsNot Nothing Then

                    Dim usuario As ML.Usuario = New ML.Usuario()
                    usuario.IdUsuario = query.IdUsuario
                    usuario.Nombre = query.NombreUsuario
                    usuario.ApellidoPaterno = query.ApellidoPaterno
                    usuario.ApellidoMaterno = query.ApellidoMaterno

                    usuario.Rol = New ML.Rol
                    usuario.Rol.IdRol = query.IdRol
                    usuario.Rol.Nombre = query.NombreRol

                    result.Objeto = usuario

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
