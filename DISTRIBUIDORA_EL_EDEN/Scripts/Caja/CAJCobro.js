﻿let fechaPago;
$(document).ready(function () {
    fechaPago = new AirDatepicker('#txtFechaPago', {
        autoClose: true,
        autoClose: true,
        view: 'days',
        minView: 'days',
        //minDate: f.setDate(f.getDate() - 7),
        minDate: new Date(),
        dateFormat: 'dd/MM/yyyy',
        selectedDates: [new Date()]

        /* //onSelect: GetDataTable*/
    });

    function ENCABEZADO(SERIE, CORRELATIVO, NOMBRE, NIT, DIRECCION, SUBTOTAL, TOTAL) {
        this.SERIE = SERIE;
        this.CORRELATIVO = CORRELATIVO;
        this.NOMBRE = NOMBRE;
        this.NIT = NIT;
        this.DIRECCION = DIRECCION;
        this.SUBTOTAL = SUBTOTAL;
        this.TOTAL = TOTAL;
    }
    function DETALLE(NOMBRE, CANTIDAD, PRECIO_UNITARIO, DESCUENTO, SUBTOTAL, TOTAL) {
        this.NOMBRE = NOMBRE;
        this.CANTIDAD = CANTIDAD;
        this.PRECIO_UNITARIO = PRECIO_UNITARIO;
        this.DESCUENTO = DESCUENTO;
        this.SUBTOTAL = SUBTOTAL;
        this.TOTAL = TOTAL;
    }
    var jsonEncabezado;
    var jsonDetalles = [];
    DevExpress.localization.locale(navigator.language);
    GetDatos();
    var cont = 0;
    function GetDatos() {
        var customStore = new DevExpress.data.CustomStore({
            load: function (loadOptions) {
                var d = $.Deferred();
                $.ajax({
                    type: 'GET',
                    url: '/CAJCobro/GetCobro',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    data: {},
                    cache: false,
                    success: function (data) {
                        var state = data["State"];
                        if (state == 1) {
                            var lista = data["CREDITOS"];

                            if (lista.length == 0)
                                $('#divCreditos').addClass('d-none')

                            $('#tbodyListado').empty();
                            var cont = 1;
                            $.each(lista, function (i, l) {
                                $('#tbodyListado').append('<tr>' +
                                    '<td class="text-center">' + l.ID_ESTADO_CUENTA + '</td>' +
                                    '<td class="text-center">' + l.ID_VENTA + '</td>' +
                                    '<td>' + l.NOMBRE_CLIENTE + '</td>' +
                                    '<td class="text-center">' + l.FECHA_CREACION_STRING + '</td>' +
                                    '</tr>'
                                );
                                cont++;
                            });


                            data = JSON && JSON.parse(JSON.stringify(data)) || $.parseJSON(data);
                            d.resolve(data);
                        }
                        else if (state == -1)
                            alert(data["Message"])
                    },
                    error: function (jqXHR, exception) {
                        getErrorMessage(jqXHR, exception);
                    }
                });
                return d.promise();
            }
        });
        var salesPivotGrid = $("#gridContainer").dxDataGrid({
            dataSource: new DevExpress.data.DataSource(customStore),
            showBorders: true,
            loadPanel: {
                text: "Cargando..."
            },
            scrolling: {
                useNative: false,
                scrollByContent: true,
                scrollByThumb: true,
                showScrollbar: "always" // or "onScroll" | "always" | "never"
            },
            searchPanel: {
                visible: true,
                width: 200,
                placeholder: "Buscar..."
            },
            headerFilter: {
                visible: true
            },
            columnAutoWidth: true,
            export: {
                enabled: false
            },
            columns: [
                {
                    dataField: "ESTADO",
                    caption: "FORMA DE PAGO",
                    alignment: "center",
                    visible:false
                },
                {
                    dataField: "ID_VENTA",
                    caption: "ORDEN DE COMPRA",
                    alignment: "center"
                },
                {
                    dataField: "FEL",
                    caption: "FEL",
                    visible: false
                },
                {
                    dataField: "FECHA_CREACION_STRING",
                    caption: "FECHA"
                },
                {
                    dataField: "NOMBRE",
                    caption: "CLIENTE"
                },
                {
                    dataField: "CREADO_POR",
                    caption: "VENDEDOR",
                    alignment: "center"
                },
                {
                    dataField: "TOTAL",
                    caption: "TOTAL SIN DESCUENTO",
                    alignment: "center",
                    dataType: "number",
                    format: { type: 'fixedPoint', precision: 2 }
                },
                {
                    dataField: "SUBTOTAL",
                    caption: "TOTAL CON DESCUENTO",
                    alignment: "center",
                    dataType: "number",
                    format: { type: 'fixedPoint', precision: 2 }
                },

                {
                    caption: "DETALLE VENTA",
                    alignment: "center",
                    cellTemplate: function (container, options) {
                        var fieldData = options.data;
                        var classTmp = 'detalle' + cont;
                        var classBTN = 'hvr-grow text-dark far fa-eye btn btn-info ' + classTmp;

                        $("<span>").addClass(classBTN).prop('title', 'Ver detalle').appendTo(container);
                        $('.detalle' + cont).click(function (e) {

                            mostrarDetalle(fieldData.ID_VENTA);
                        })
                        cont++;
                    }
                },
                {
                    caption: "IMPRIMIR COMPROBANTE",
                    alignment: "center",
                    cellTemplate: function (container, options) {
                        var fieldData = options.data;
                        var classTmp = 'imprimir' + cont;
                        var classBTN = 'hvr-grow text-dark fal fa-print btn btn-warning ' + classTmp;

                        $("<span>").addClass(classBTN).prop('title', 'IMPRESION CONSTANCIA').appendTo(container);
                        $('.imprimir' + cont).click(function (e) {
                            var id_venta = parseInt(fieldData.ID_VENTA);
                            GenerarComprobante(id_venta)
                            //console.log(id_venta);
                            //var serie = fieldData.SERIE;
                            //var correlativo = parseFloat(fieldData.CORRELATIVO);
                            //var nombreCliente = fieldData.NOMBRE;
                            //var nit2 = fieldData.NIT
                            //var direccion = fieldData.DIRECCION;
                            //var subtotal = parseFloat(fieldData.SUBTOTAL);
                            //var total = parseFloat(fieldData.TOTAL);
                            //jsonEncabezado = new ENCABEZADO(serie, correlativo, nombreCliente, nit2, direccion, subtotal, total);
                            //mostrarDetalleVenta(id_venta);
                        })
                        cont++;
                    }
                },
                {
                    caption: "COBRAR VENTA",
                    alignment: "center",
                    cellTemplate: function (container, options) {
                        var fieldData = options.data;
                        var classTmp = 'cobrar' + cont;
                        var classBTN = 'hvr-grow text-dark far fa-money-bill-alt btn btn-success ' + classTmp;

                        $("<span>").addClass(classBTN).prop('title', 'cobrar').appendTo(container);
                        $('.cobrar' + cont).click(function (e) {
                            var total = parseFloat(fieldData.TOTAL);
                            var id = parseInt(fieldData.ID_VENTA);
                            var fel = parseInt(fieldData.FEL);
                            var creadoPor = fieldData.CREADO_POR;
                            document.querySelector('#totalCobro').textContent = formatNumber(parseFloat(total).toFixed(2));
                            $('#hfID').val(id);
                            $('#hfOpcion').val(creadoPor);
                            $('#hfMonto').val(total);
                            $('#hfFel').val(fel);
                            $('#modalCobro').modal('show');
                        })
                        cont++;
                    }
                },
                {
                    caption: "ANULAR VENTA",
                    alignment: "center",
                    cellTemplate: function (container, options) {
                        var fieldData = options.data;
                        var classTmp = 'anular' + cont;
                        var classBTN = 'hvr-grow text-dark far fa-trash-alt btn btn-danger ' + classTmp;
                        $("<span>").addClass(classBTN).prop('title', 'cobrar').appendTo(container);
                        $('.anular' + cont).click(function (e) {
                            var id = parseInt(fieldData.ID_VENTA);
                            var fel = parseInt(fieldData.FEL);
                            $('#hfID').val(id);
                            $('#hfFel').val(fel);
                            $('#modalAnulado').modal('show');
                        })
                        cont++;
                    }
                }
            ],
            onRowPrepared(e) {
                if (e.rowType == 'data' && e.data.ESTADO == 1) {
                    e.rowElement.css("background-color", "#DC143C");
                    e.rowElement.css("color", "#FFFFFF");
                }
            },
        }).dxDataGrid('instance');
    }

    function mostrarDetalleVenta(id_venta) {
        $.ajax({
            type: 'GET',
            url: "/CAJCobro/GetDetalle2",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: {
                id_venta
            },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    data = JSON && JSON.parse(JSON.stringify(data)) || $.parseJSON(data);
                    for (var i = 0; i < data.data.length; i++) {
                        var nombre = data.data[i].NOMBRE;
                        var cantidad = data.data[i].CANTIDAD;
                        var precio_unitario = data.data[i].PRECIO_UNITARIO;
                        var descuento = data.data[i].DESCUENTO;
                        var subtotal = data.data[i].SUBTOTAL;
                        var total = data.data[i].TOTAL;
                        var listado = new DETALLE(nombre, cantidad, precio_unitario, descuento, subtotal, total);
                        jsonDetalles.push(listado);
                    }
                    envioController();
                    jsonDetalles = [];
                }
                else if (state == -1) {
                    ShowAlertMessage('warning', data['Message'])
                }
            }
        });
    }

    function envioController() {
        CallLoadingFire('Generando comprobante, por favor espere.');
        $.post("/CAJCobro/GetComprobante", {
            encabezado: JSON.stringify(jsonEncabezado),
            detalles: JSON.stringify(jsonDetalles)
        }, function (result) {
            var pom = document.createElement('a');
            pom.setAttribute('href', 'data:' + result.MimeType + ';base64,' + result.File);
            pom.setAttribute('download', result.FileName);
            if (document.createEvent) {
                var event = document.createEvent('MouseEvents');
                event.initEvent('click', true, true);
                pom.dispatchEvent(event);
            }
            else {
                pom.click();
            }
            CallToast('Descarga realizada con éxito.', true, 2300, '#9EC600')
        });
    }

    function mostrarDetalle(id) {
        var id_venta = parseInt(id);
        var customStore = new DevExpress.data.CustomStore({
            load: function (loadOptions) {
                var d = $.Deferred();
                $.ajax({
                    type: 'GET',
                    url: '/CAJCobro/GetDetalle',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    data: { id_venta },
                    cache: false,
                    success: function (data) {
                        var state = data["State"];
                        if (state == 1) {
                            data = JSON && JSON.parse(JSON.stringify(data)) || $.parseJSON(data);
                            d.resolve(data);
                        }
                        else if (state == -1)
                            alert(data["Message"])
                    },
                    error: function (jqXHR, exception) {
                        getErrorMessage(jqXHR, exception);
                    }
                });
                return d.promise();
            }
        });
        var salesPivotGrid = $("#gridContainer2").dxDataGrid({
            dataSource: new DevExpress.data.DataSource(customStore),
            showBorders: true,
            loadPanel: {
                text: "Cargando..."
            },
            scrolling: {
                useNative: false,
                scrollByContent: true,
                scrollByThumb: true,
                showScrollbar: "always" // or "onScroll" | "always" | "never"
            },
            searchPanel: {
                visible: true,
                width: 200,
                placeholder: "Buscar..."
            },
            headerFilter: {
                visible: true
            },
            columnAutoWidth: true,
            export: {
                enabled: false
            },
            columns: [
                {
                    dataField: "NOMBRE",
                    caption: "PRODUCTO"
                },
                {
                    dataField: "CANTIDAD",
                    caption: "CANTIDAD",
                    alignment: "center"
                },
                {
                    dataField: "PRECIO_UNITARIO",
                    caption: "P/U",
                    alignment: "center"
                },
                {
                    dataField: "DESCUENTO",
                    caption: "D/U",
                    alignment: "center",
                    dataType: "number",
                    format: { type: 'fixedPoint', precision: 2 }
                },
                {
                    dataField: "TOTAL",
                    caption: "TOTAL SIN DESCUENTO",
                    alignment: "center",
                    dataType: "number",
                    format: { type: 'fixedPoint', precision: 2 }
                },
                {
                    dataField: "SUBTOTAL",
                    caption: "TOTAL CON DESCUENTO",
                    alignment: "center",
                    dataType: "number",
                    format: { type: 'fixedPoint', precision: 2 }
                }
            ],
        }).dxDataGrid('instance');
        $('#modalDetalle').modal('show');
    }

    function getCobro(id, cobro, formaPago, fel, fechaPago) {
        if (fel == 1)
            CallLoadingFire('Emitiendo Factura FEL...');
        else
            CallLoadingFire('Realizando Cobro...');

        $.ajax({
            type: 'GET',
            url: "/CAJCobro/getCobroEfectuado",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { id, cobro, formaPago, fel, fechaPago },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    if (fel == 1) {
                        var url = "https://report.feel.com.gt/ingfacereport/ingfacereport_documento?uuid=" + data['UUID'];
                        window.open(url, '_blank');
                    }

                    ShowAlertMessage('success', 'El Cobro se ha realizado exitosamente');
                    $('#modalCobro').modal('hide');
                    GetDatos()
                }
                else if (state == -1) {
                    ShowAlertMessage('warning', data['Message'])
                }
                else if (state == -2) {
                    ShowAlertMessage('warning', data['Message'])
                }
            }
        });
    }

    function anularVenta(id, fel) {
        let id_venta = parseInt(id);
        $.ajax({
            type: 'GET',
            url: "/CAJCobro/getAularVenta",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: { id_venta, fel },
            cache: false,
            success: function (data) {
                var state = data["State"];
                if (state == 1) {
                    ShowAlertMessage('success', 'Venta anulado correctamente')
                    $('#modalAnulado').modal('hide');
                    GetDatos()
                }
                else if (state == -1)
                    ShowAlertMessage('warning', data['Message'])
                else if (state == 3)
                    ShowAlertMessage('warning', 'No se pudo anular la venta en FEL, consulta con el Administrador, Mensaje: ' + data['Message'])
            }
        });
    }

    $('#btnCobrar').on('click', function (e) {
        e.preventDefault();
        var cobro = parseFloat($('#hfMonto').val());
        var formaPago = $('#selTipoPago').val();
        var id = parseInt($('#hfID').val());
        var fel = parseInt($('#hfFel').val());


        if (formaPago != null) {
            Swal.fire({
                title: 'CREAR COBRO',
                html: 'Selecciona una opción',
                icon: 'info',
                showCloseButton: true,
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'COBRO',
                cancelButtonText: 'COBRO CON FACTURA'
            }).then((result) => {
                if (result.isConfirmed) {
                    getCobro(id, cobro, formaPago, 0, DateFormat(fechaPago.lastSelectedDate));
                }
                else if (result.dismiss === Swal.DismissReason.cancel) {
                    getCobro(id, cobro, formaPago, 1, DateFormat(fechaPago.lastSelectedDate));
                }
            })
        }
        else {
            ShowAlertMessage('warning', 'Debe de Elegir una forma de Pago correcto')
        }
    });

    $('#btnAnular').on('click', function (e) {
        e.preventDefault();
        let id = $('#hfID').val();
        var fel = $('#hfFel').val();
        anularVenta(id, fel)
    })

    $('#selTipoPago').on('change', function (e) {
        e.preventDefault();
        var valor = $(this).val();

        if (valor == 3) {
            $('#divFechaPago').removeClass('d-none');
        }
        else {
            $('#divFechaPago').addClass('d-none');
        }
    })

    function GenerarComprobante(id_venta) {
        CallLoadingFire('Generando comprobante, por favor espera...');
        $.post("/VENReimpresiones/GetComprobante", { id_venta }, function (result) {
            var pom = document.createElement('a');
            pom.setAttribute('href', 'data:' + result.MimeType + ';base64,' + result.File);
            pom.setAttribute('download', result.FileName);
            if (document.createEvent) {
                var event = document.createEvent('MouseEvents');
                event.initEvent('click', true, true);
                pom.dispatchEvent(event);
            }
            else {
                pom.click();
            }
            CallToast('Descarga realizada con éxito.', true, 2300, '#9EC600')
        });
    }
});