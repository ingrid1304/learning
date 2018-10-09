namespace Banco
{
    public class Persona
    {
        private string segundoNombre;

        public Persona(string primerNombre, string apellidoPaterno,
            string apellidoMaterno) : this(primerNombre, null,
                apellidoPaterno, apellidoMaterno)
        { }

        public Persona(string primerNombre, string segundoNombre,
            string apellidoPaterno, string apellidoMaterno)
        {
            PrimerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
        }

        public string PrimerNombre { get; private set; }
        public string SegundoNombre => segundoNombre ?? string.Empty;
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }

        public string NombreCompleto
        {
            get
            {
                if (segundoNombre == null)
                    return ApellidoPaterno + " " + ApellidoMaterno + " " + PrimerNombre;

                else
                    return ApellidoPaterno + " " + ApellidoMaterno + " " + PrimerNombre + " " + segundoNombre;
            }

        }
    }
}
