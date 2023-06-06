$(document).ready(function () {
    //ValidarSesion();

    function getURLParams(url) {
        let params = {};
        new URLSearchParams(url.replace(/^.*?\?/, '?')).forEach(function (value, key) {
            params[key] = value
        });
        return params;
    }
    function ValidarSesion() {
        var url = window.location.href;
        var params = getURLParams(url);
        if (params["expirado"] != null) {
            if (params["expirado"].toLowerCase() == "true") {
                showNotification('top', 'right', "error", 'Primero debe iniciar sesion o bien la sesion ha expirado', 'danger');
            }
        }
    }
    function ShowAlertMessage(icon, descripcion) {
        Swal.fire({
            icon: icon,
            html: descripcion,
            showCancelButton: true,
            cancelButtonText: 'Cerrar',
            showConfirmButton: false,
        })
    }
    ValidarLogin('ADMIN', '1234')
    function ValidarLogin(usuario, password) {
        $.ajax({
            type: 'GET',
            url: '/Home/ValidarLogin',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { usuario, password },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    var datoUsuario = data["data"];
                    if (datoUsuario != null) {
                        var menus = data['menuHtml'];
                        console.log(menus)
                        //$('#divMenus').append(menus)
                        window.location.href = datoUsuario.URL_PANTALLA;

                        //$('#divMenus').append('                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>USUARIOS<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                                                            <ul class="nav nav-treeview">                                        <li class="nav-item">                                        </li>                                        <li class="nav-item">                                            <a href="~/Usuarios/Listar" class="nav-link">                                                <i class="far fa-stop-circle" style="color:white"></i>                                                <p>LISTAR</p>                                            </a>                                        </li>                                    </ul>                            </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>CLIENTES<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>INVENTARIO<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>VENTAS<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>CAJA<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>REPORTES<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>ANULACIONES<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>DEVOLUCIONES<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>                            <li class="nav-item">                                <a href="#" class="nav-link">                                    <i class="far fa-inventory"></i>                                    <p>LISTAR<i class="fas fa-angle-left right"></i>                                    </p>                                </a>                        </li>')
                    }
                    else {
                        $('#txtUsuarioChange').val('');
                        $('#txtUsuario').val('');
                        $('#txtPassword').val('');
                        ShowAlertMessage('warning', '¡CREDENCIALES INCORRECTAS!')
                    }
                }
                else if (state == -1) {
                    alert(data['Message'])
                }
            }
        });
    }
    function ChangePassword(correo, usuario, password) {
        $.ajax({
            type: 'GET',
            url: '/Home/ChangePassword',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { correo, usuario, password },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    var datoUsuario = data["data"];
                    if (datoUsuario != null) {
                        ShowAlertMessage('success', 'Se han cambiado las credenciales correctamente.')
                        $('#modalRecuperarPass').modal('hide');
                    }
                    else {
                        ShowAlertMessage('info', 'El correo ingresado no es válido en el sistema SALESMENT.')

                        $('#txtUsuarioChange').val('');
                        $('#txtCorreo').val('');
                        $('#txtpass1').val('');
                        $('#txtpass2').val('');
                    }
                }
                else if (state == -1) {
                    alert(data['Message'])
                }
            }
        });
    }

    $('#btnValidarLogin').on('click', function (e) {
        e.preventDefault();
        var usuario = $('#txtUsuario').val();
        var pass = $('#txtPassword').val();

        ValidarLogin(usuario, pass);
    });
    $('#btnAbrirModalPass').on('click', function (e) {
        e.preventDefault();
        $('#txtUsuarioChange').val('');
        $('#txtCorreo').val('');
        $('#txtpass1').val('');
        $('#txtpass2').val('');
        $('#modalRecuperarPass').modal('show');
    });
    $('#btnCambiarPass').on('click', function (e) {
        e.preventDefault();
        var usuario = $('#txtUsuarioChange').val();
        var correo = $('#txtCorreo').val();
        var pass1 = $('#txtpass1').val();
        var pass2 = $('#txtpass2').val();

        if (pass1 != pass2) {
            ShowAlertMessage('warning', 'Las contraseñas no coinciden.')
            return;
        }

        ChangePassword(correo, usuario, pass1);
    });

});