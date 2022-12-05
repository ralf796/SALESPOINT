﻿let fechaI;
let fechaF;
$(document).ready(function () {

    fechaI = new AirDatepicker('#txtAnioI', {
        autoClose: true,
        autoClose: true,
        view: 'years',
        minView: 'years',
        dateFormat: 'yyyy',
        selectedDates: [new Date()],
        //onSelect: GetDataTable
    });
    fechaF = new AirDatepicker('#txtAnioF', {
        autoClose: true,
        autoClose: true,
        view: 'years',
        minView: 'years',
        dateFormat: 'yyyy',
        selectedDates: [new Date()],
        //onSelect: GetDataTable
    });

    function GuardarProducto(NOMBRE, DESCRIPCION, CODIGO, CODIGO2, STOCK, PRECIO_COSTO, PRECIO_VENTA, ANIO_INICIAL, ANIO_FINAL, PATH, NOMBRE_MARCA_REPUESTO, NOMBRE_MARCA_VEHICULO, NOMBRE_SERIE_VEHICULO, NOMBRE_DISTRIBUIDOR, ID_PRODUCTO, tipo) {
        $.ajax({
            type: 'GET',
            url: "/INVMantenimiento/OperacionesProducto",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: {
                NOMBRE, DESCRIPCION, CODIGO, CODIGO2, STOCK, PRECIO_COSTO, PRECIO_VENTA, ANIO_INICIAL, ANIO_FINAL, PATH, NOMBRE_MARCA_REPUESTO, NOMBRE_MARCA_VEHICULO, NOMBRE_SERIE_VEHICULO, NOMBRE_DISTRIBUIDOR, tipo
            },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    $('#txtNombre').val('');
                    $('#txtDescripcion').val('');
                    $('#txtPrecioCosto').val('');
                    $('#txtPrecioVenta').val('');
                    $('#txtStock').val('');
                    $('#txtCodigo').val('');
                    $('#txtCodigo2').val('');
                    $('#txtNombreMarcaRepuesto').val('');
                    $('#txtNombreDistribuidor').val('');
                    $('#txtNombreMarcaVehiculo').val('');
                    $('#txtNombreSerieVehiculo').val('');
                    ShowAlertMessage('success', '¡Producto creado correctamente!');
                }
                else if (state == -1) {
                    ShowAlertMessage('warning', data['Message'])
                }
            }
        });
    }

    $('#formGuardarProducto').submit(function (e) {
        e.preventDefault();
        var NOMBRE = $('#txtNombre').val();
        var DESCRIPCION = $('#txtDescripcion').val();
        var CODIGO = $('#txtCodigo').val();
        var CODIGO2 = $('#txtCodigo2').val();
        var STOCK = $('#txtStock').val();
        var PRECIO_COSTO = $('#txtPrecioCosto').val();
        var PRECIO_VENTA = $('#txtPrecioVenta').val();
        var ANIO_INICIAL = $('#txtAnioI').val();
        var ANIO_FINAL = $('#txtAnioF').val();
        var PATH = $('#txtUploadExcel').val();
        var NOMBRE_MARCA_REPUESTO = $('#txtNombreMarcaRepuesto').val();
        var NOMBRE_MARCA_VEHICULO = $('#txtNombreMarcaVehiculo').val();
        var NOMBRE_SERIE_VEHICULO = $('#txtNombreSerieVehiculo').val();
        var NOMBRE_DISTRIBUIDOR = $('#txtNombreDistribuidor').val();
        var ID_PRODUCTO = 0;
        var tipo = 1;

        //
        GuardarProducto(NOMBRE, DESCRIPCION, CODIGO, CODIGO2, STOCK, PRECIO_COSTO, PRECIO_VENTA, ANIO_INICIAL, ANIO_FINAL, PATH, NOMBRE_MARCA_REPUESTO, NOMBRE_MARCA_VEHICULO, NOMBRE_SERIE_VEHICULO, NOMBRE_DISTRIBUIDOR, ID_PRODUCTO, tipo);
    });

    $("#txtUploadExcel").change(function () {
        Swal.fire({
            title: 'Carga masiva de productos',
            text: "Se cargaran todos los productos adjuntos en el archivo. ¿Quiere continuar con la carga?",
            type: 'info',
            icon: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {

                var file = $("#txtUploadExcel").val();
                var formData = new FormData();
                var totalFiles = document.getElementById("txtUploadExcel").files.length;
                for (var i = 0; i < totalFiles; i++) {
                    var file = document.getElementById("txtUploadExcel").files[i];
                    formData.append("FileUpload", file);
                }
                if (file != null && file != "") {
                    CallLoadingFire('Cargando subida de datos, por favor espere.')
                    $.ajax({
                        type: "POST",
                        url: "/INVMantenimiento/CargarExcel",
                        data: formData,
                        dataType: 'json',
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            var state = data['State'];
                            var contRows = data['dataGroup'];
                            var contRowsDetails = data['dataGroupDetail'];
                            if (state == 1) {
                                $("#txtUploadExcel").val('');
                                Swal.fire({
                                    icon: 'success',
                                    type: 'success',
                                    html: '¡Se crearon ' + contRows + ' productos correctamente.!<br/>Se cargaron ' + contRowsDetails + ' filas del archivo excel seleccionado.',
                                    showCancelButton: true,
                                    cancelButtonText: 'Cerrar',
                                    showConfirmButton: false,
                                })
                            }
                            else if (state == -1) {
                                ShowAlertMessage('warning', data['Message']);
                            }
                        },
                        error: function (jqXHR, ex) {
                            console.log(jqXHR);
                            console.log(ex);
                        }
                    });
                }
            }
        })
    });
});