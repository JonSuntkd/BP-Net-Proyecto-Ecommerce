﻿namespace Curso.ComercioElectronico.Aplicacion.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entidad \"{name}\"  :  ({key}) no se encontró.")
        {
        }
    }
}