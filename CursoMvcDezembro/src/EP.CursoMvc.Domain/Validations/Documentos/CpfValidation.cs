namespace EP.CursoMvc.Domain.Validations.Documentos
{
    public class CpfValidation
    {
        public static bool Validar(string cpf)
        {
            return cpf.Length >= 11;
        }
    }
}