//Metodo que sirve para establecer funciones adicionales a jquery validator incluye regla y default message
// GRAMATICA para patrones (Mascaras)
// Solo letras Mayusculas o Minusculas
// /^[a-zA-Z]*$/
// Solo numeros
// /^[0-9]*$/
// Para restringir la cantidad de cierto patron
// /^[0-9]{2}$/     ---- /^[0-9]{2}[A-Z]{1}$/
// Para tener restringir de almenos un valor a mas se usa el operador +
// /^[0-9]+[A-Z]{1}$/ --> la cadena acepta almenos un numero o mas seguido de una letra mayuscula

// Para validar que el dato de un input sea igual al otro (Contraseñas)
//rules: {
//        password: "required",
//        password_again: {
//        equalTo: "#password"
//        }
//}
// Diferencia entre number y digit, number permite decimales y digit no
// Agregar a rules number:true ----- digit:true

// Fechas
// date: true

//URL
//url: true

//EMAIL
//email:true

//RANGE para numeros
//range: [13, 23]

//MAX para numeros
//max: 23

//MIN para numeros
//min: 23

//LENGHT rango
//rangelength: [2, 6]


jQuery.validator.addMethod("licencia", function (value, element) {
    return this.optional(element) || /^[A-Z]{1}[0-9]+$/.test(value);
}, "La Licencia de Conducir no tiene el formato correcto");

jQuery.validator.addMethod("hora", function (value, element) {
    return this.optional(element) || /^[0-9]{1,2}:[0-9]{1,2}(:[0-9]{1,2}){0,1}$/.test(value);
}, "El campo no tiene un formato de hora correcta");