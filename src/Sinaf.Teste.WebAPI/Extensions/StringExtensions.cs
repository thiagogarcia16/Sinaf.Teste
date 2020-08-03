namespace Sinaf.Teste.WebAPI.Extensions
{
    public static class StringExtensions
    {
        public static string RemoverMascara(this string palavra) => palavra.Replace("(", "").Replace(")", "")
                                                                           .Replace("-", "").Replace(".", "");

    }
}
