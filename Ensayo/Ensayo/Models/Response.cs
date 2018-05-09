namespace Ensayo.Models
{
    public class Response //RESPUESTA QUE DAN LOS SERVICIOS
    {
        public bool IsSuccess//Para traer la lista, si la trae devuelve true y va a Result, si es false va a Message
        {
            get;
            set;
        }
        public string Message//Muestra el error que proviene de IsSuccess
        {
            get;
            set;
        }
        public object Result //Devuelve la lista de paises
        {
            get;
            set;
        }
    }
}
