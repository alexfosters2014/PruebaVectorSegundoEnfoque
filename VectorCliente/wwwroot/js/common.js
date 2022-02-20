function DeshabilitarComponente(stringId, disabledBool) {
    document.getElementById(stringId).disabled = disabledBool;
}

function MsgSuccess(mensaje) {
    return new Promise(resolve => {
        Swal.fire({
            title: "Exitoso",
            text: mensaje,
            icon: 'success',
            confirmButtonColor: '#00b347',
            confirmButtonText: 'OK',
        }).then((result) => {
            resolve(result.isConfirmed);
        })

    });
}

function MsgError(mensaje) {
    return new Promise(resolve => {
    Swal.fire({
        title: "Error",
        text: mensaje,
        icon: 'error',
        confirmButtonColor: '#00b347',
        confirmButtonText: 'OK',
    }).then((result) => {
        resolve(result.isConfirmed);
    })

    });
}

function MsgWarning(mensaje) {
    return new Promise(resolve => {
    Swal.fire({
        title: "Advertencia",
        text: mensaje,
        icon: 'warning',
        confirmButtonColor: '#00b347',
        confirmButtonText: 'OK',
    }).then((result) => {
        resolve(result.isConfirmed);
    })

    });
    }

function ConfirmarOperacion (pregunta) {
    return new Promise(resolve => {
        Swal.fire({
            title: "Confirmar",
            text: pregunta,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#00b347',
            cancelButtonColor: '#d33',
            confirmButtonText: 'SI',
            cancelButtonText: "NO"
        }).then((result) => {
                resolve(result.isConfirmed);
        })

    })
}

function OpenWindow(url,width) {
    window.open(url, "", "width="+ width + ",height=560,scrollbars=no,menubar=no,toolbar=no,location=no,resizable=no");
}

function OnInputText(titulo, mensaje) {
    return new Promise(resolve => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            input: 'text',
            showCancelButton: true,
            confirmButtonColor: '#00b347',
            cancelButtonColor: '#d33',
            confirmButtonText: 'OK',
            cancelButtonColor: '#d33',
            cancelButtonText: "CANCELAR"
        }).then((result) => {
            if (!result.isConfirmed) {
                resolve("NOTCONFIRMED");
            }else if (result.value) {
                resolve(result.value);
            } else {
                resolve("");
            }
        })
    })
}

function OnSelectComputoSegundoNivel(titulo, mensaje) {
    return new Promise(resolve => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: 'NORMAL',
            denyButtonText: 'LIBRE TRABAJADO',
            denyButtonColor:'#00b346',
            confirmButtonColor: '#00b347',
            cancelButtonColor: '#d33',
            cancelButtonText: "CANCELAR"
        }).then((result) => {
            if (result.isConfirmed) {
                resolve("NORMAL");
            } else if (result.isDenied) {
                resolve("LIBRE TRABAJADO");
            } else {
                resolve("");
            }
        })
    })
}

function OnInputTextPass() {
    return new Promise(resolve => {
        Swal.fire({
            title: titulo,
            html: '<input type="text" class="form-control" id="passuno" placeholder="Password">' +
                  '<input type="text" class="form-control" id="passdos" placeholder="Confirmación de Password">',
            showCancelButton: true,
            confirmButtonColor: '#00b347',
            cancelButtonColor: '#d33',
            confirmButtonText: 'OK',
            cancelButtonColor: '#d33',
            cancelButtonText: "CANCELAR"
        }).then((result) => {
            if (result.isConfirmed) {
                resolve([
                    document.getElementById('passuno').value,
                    document.getElementById('passdos').value
                ]);
            }
        })
    })
}

//function Gantt() {
//        var options = {
//            series: [
//                {
//                    data: [
//                        {
//                            x: 'Code',
//                            y: [
//                                new Date('2019-03-02').getTime(),
//                                new Date('2019-03-04').getTime()
//                            ]
//                        },
//                        {
//                            x: 'Test',
//                            y: [
//                                new Date('2019-03-04').getTime(),
//                                new Date('2019-03-08').getTime()
//                            ]
//                        },
//                        {
//                            x: 'Validation',
//                            y: [
//                                new Date('2019-03-08').getTime(),
//                                new Date('2019-03-12').getTime()
//                            ]
//                        },
//                        {
//                            x: 'Deployment',
//                            y: [
//                                new Date('2019-03-12').getTime(),
//                                new Date('2019-03-18').getTime()
//                            ]
//                        }
//                    ]
//                }
//            ],
//            chart: {
//                height: 350,
//                type: 'rangeBar'
//            },
//            plotOptions: {
//                bar: {
//                    horizontal: true
//                }
//            },
//            xaxis: {
//                type: 'datetime'
//            }
//        };

//        var chart = new ApexCharts(document.querySelector("#chart"), options);
//        chart.render();
//}


function OnInputDate(titulo) {
    return new Promise(resolve => {
        Swal.fire({
            title: titulo,
            html: '<input type="date" class="form-control" id="expiry-date" value="2021-01-01">',
            showCancelButton: true,
            confirmButtonColor: '#00b347',
            cancelButtonColor: '#d33',
            confirmButtonText: 'OK',
            cancelButtonColor: '#d33',
            cancelButtonText: "CANCELAR"
        }).then((result) => {
            if (result.isConfirmed) {
                    resolve(document.getElementById('expiry-date').value);
            }  else {
                resolve(null);
            }
        })
    })
}

window.saveAsFile = function (fileName, byteBase64) {
    var link = this.document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    this.document.body.appendChild(link);
    link.click();
    this.document.body.removeChild(link);
}