function fechaParse(fecha) {
    var fixedResponse = fecha.replace("/", "");
    fixedResponse = fixedResponse.replace("/", "");
    return "new " + fixedResponse;
}

function getfechaFormat(fecha) {

    return fecha.getDate() + "/" + (fecha.getMonth() + 1).toString() + "/" + fecha.getFullYear()
}

function getfechaHoraFormat(fecha) {

    return fecha.getDate() + "/" + (fecha.getMonth() + 1).toString() + "/" + fecha.getFullYear() + "  "+ fecha.getHours() + ":" + fecha.getMinutes() + ":" + fecha.getSeconds()
}

$(function () {

    $('.pickadate-fecha').pickadate({
        monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Setiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthsShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        weekdaysFull: ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado'],
        weekdaysShort: ['Dom', 'Lun', 'Mar', 'Mier', 'Jue', 'Vie', 'Sab'],
        labelMonthNext: 'Mes Siguente',
        labelMonthPrev: 'Mes Anterior',
        labelYearSelect: 'Seleccione un Año',
        labelMonthSelect: 'Seleccione un Mes',
        format: 'dd/mm/yyyy',
        selectYears: true,
        selectMonths: true,
        today: 'Hoy',
        clear: 'Reset',
        close: 'Cerrar'

    });
});