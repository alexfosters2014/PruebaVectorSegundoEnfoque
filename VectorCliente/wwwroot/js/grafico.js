window.ChartResult = {
    starts: function (data) {
        var options = {
            series: [
                {
                    data: GanttModel(data)
                }
            ],
            chart: {
                height: '80%',
                type: 'rangeBar',
                defaultLocale: 'es',
                locales: [{
                    name: 'es',
                    options: {
                        months: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        shortMonths: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        days: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
                        shortDays: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sab'],
                        toolbar: {
                            download: 'Descargar SVG',
                            selection: 'Selección',
                            selectionZoom: 'Selección Zoom',
                            zoomIn: 'Acercar',
                            zoomOut: 'Alejar',
                            pan: 'Panorama',
                            reset: 'Centrar',
                        }
                    }
                }]
            },
            plotOptions: {
                bar: {
                    horizontal: true,
                }
            },
            dataLabels: {
                enabled: true,
                formatter: function (val, opts) {
                    var etiqueta = opts.w.globals.labels[opts.dataPointIndex]
                    //var a = moment(val[0])
                    //var b = moment(val[1])
                    return etiqueta
                },
                style: {
                    colors: ['#f3f4f5', '#fff']
                }
            },
            xaxis: {
                type: 'datetime'
            },
            grid: {
                row: {
                    colors: ['#f3f4f5', '#fff'],
                    opacity: 1
                }
            }
        };
        document.querySelector("#chart").innerHTML = "";
        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();
    }
}

function GanttModel(data) {
    let resultado = [];

    resultado = data.map((dat) => {
        return {
            x: dat.x,
            y: [new Date(dat.fechaInicio).getTime(),
                new Date(dat.fechaFin).getTime()],
            fillColor: dat.fillColor
        }
    });
    return resultado;
}
