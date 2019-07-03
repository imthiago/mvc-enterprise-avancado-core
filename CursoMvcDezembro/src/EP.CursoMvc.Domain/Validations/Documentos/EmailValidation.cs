namespace EP.CursoMvc.Domain.Validations.Documentos
{
    public class EmailValidation
    {
        public static bool Validar(string email)
        {
            return email.Contains("@");
        }
    }
}