Imports System.Web.Mvc

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller
        ' GET: Usuario
        Function GetAll() As ActionResult
            Dim usuario As ML.Usuario = New ML.Usuario
            Dim result As ML.Result = BL.Usuario.GetAll()
            usuario.Usuarios = result.Objetos
            Return View(usuario)
        End Function

        Function Form(IdUsuario As Integer?) As ActionResult
            Dim usuario As ML.Usuario = New ML.Usuario
            usuario.Rol = New ML.Rol
            Dim resultRol As ML.Result = BL.Rol.GetAll()
            If resultRol.Correct Then
                If IdUsuario Is Nothing Then
                    usuario.Rol.Roles = resultRol.Objetos
                    Return View(usuario)
                Else
                    Dim result As ML.Result = BL.Usuario.GetById(IdUsuario)
                    If result.Correct Then
                        usuario = DirectCast(result.Objeto, ML.Usuario)
                        usuario.Rol.Roles = resultRol.Objetos
                        Return View(usuario)
                    Else
                        Return View("Modal")
                    End If
                End If
            End If
            usuario.IdUsuario = IdUsuario
        End Function


        Function Form1(usuario As ML.Usuario) As ActionResult
            If usuario.IdUsuario = 0 Then
                Dim result As ML.Result = BL.Usuario.Add(usuario)
                If result.Correct Then
                    ViewBag.Message = "Registro exitoso."
                Else
                    ViewBag.Message = "Ocurrio un problema en el registro " + result.Message
                End If
            Else
                Dim result As ML.Result = BL.Usuario.Update(usuario)
                If result.Correct Then
                    ViewBag.Message = "Registro exitoso."
                Else
                    ViewBag.Message = "Ocurrio un problema en el registro " + result.Message

                End If
            End If
            Return View("Modal")
        End Function

        Function Delete(IdUsuario As Integer?) As ActionResult
            Dim usuario As ML.Usuario = New ML.Usuario()
            usuario.IdUsuario = IdUsuario
            If IdUsuario > 0 Then
                Dim result As ML.Result = BL.Usuario.Delete(IdUsuario)
                If result.Correct Then
                    ViewBag.Message = "Se elimino el registro exitosamente."
                Else
                    ViewBag.Message = "Ocurrido un error"
                End If
            End If
            Return View("Modal")
        End Function
    End Class
End Namespace