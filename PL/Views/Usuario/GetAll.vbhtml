@ModelType ML.Usuario
@Code
    ViewData("Title") = "GetAll"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Usuarios</h2>

<div Class="container navbar-right">

    <div class="row">
        <div class=" col-md-12 col-sm-3">
            @Html.ActionLink("+", "Form", "Usuario", htmlAttributes:=New With {.class = "btn btn-primary"})
        </div>
    </div>
</div>
<br />

<table class="table table-bordered table-responsive">
    <thead>
        <tr>
            <td>Editar</td>
            <td class="hidden">IdUsuario</td>
            <td>Nombre</td>
            <td>Apellido Paterno</td>
            <td>Apellido Materno</td>
            <td>Rol</td>
            <td>Delete</td>
        </tr>
    </thead>
    <tbody>
        @For Each usuario As ML.Usuario In Model.Usuarios
            @<tr>
                <td><a class="btn btn-warning glyphicon glyphicon-edit" href="@Url.Action("Form", "Usuario", New With {usuario.IdUsuario})"></a></td>
                <td class="hidden">@usuario.IdUsuario</td>
                <td>@usuario.Nombre</td>
                <td>@usuario.ApellidoPaterno</td>
                <td>@usuario.ApellidoMaterno</td>
                <td>@usuario.Rol.Nombre</td>
                <td><a class="btn btn-danger glyphicon glyphicon-trash" href="@Url.Action("Delete", "Usuario", New With {usuario.IdUsuario})" onclick="return confirm('Estas seguro que deseas eliminar este registro?');"></a></td>
            </tr>
        Next usuario
    </tbody>
</table>