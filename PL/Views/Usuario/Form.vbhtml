@ModelType ML.Usuario
@Code
    ViewData("Title") = "Form"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Añadir</h2>

<div class="row">
    <div class="container">
        <div class="col-md-12">
            <h2>Usuario</h2>
            <h5>Ingrese los datos del Usuario :</h5>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            @Using (Html.BeginForm("Form1", "Usuario"))
                @<div class="form-horizontal">
                    <h4>Usuario</h4>
                    <hr />
                    
                    <div hidden class="form-group">
                        @Html.LabelFor(Function(model) model.IdUsuario, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.IdUsuario, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.IdUsuario, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Nombre, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.ApellidoPaterno, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.ApellidoPaterno, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.ApellidoPaterno, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.ApellidoMaterno, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.ApellidoMaterno, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.ApellidoMaterno, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Rol.IdRol, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.DropDownListFor(Function(model) model.Rol.IdRol, New SelectList(Model.Rol.Roles, "IdRol", "Nombre"), "Selecciona un Rol", New With {.htmlAttributes = New With {.Class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Rol.IdRol, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                </div>
                @<div Class="col-md-3">
                    <input type="submit" value="Guardar" Class="btn btn-success" />
                    @Html.ActionLink("Regresar", "GetAll", "Usuario", htmlAttributes:=New With {.class = "btn btn-danger"})
                </div>
            End Using
        </div>
    </div>
</div>
