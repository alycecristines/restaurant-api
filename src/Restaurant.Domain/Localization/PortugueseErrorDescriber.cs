namespace Restaurant.Domain.Localization
{
    public static class PortugueseErrorDescriber
    {
        public const string Required = "Obrigatório.";
        public const string MaxStringLength = "Deve ter um comprimento máximo de {1} caracteres.";
        public const string MinMaxStringLength = "Deve ter um comprimento entre {2} e {1} caracteres.";
        public const string FixedStringLength = "Deve ter um comprimento de {1} caracteres.";
        public const string MinCollectionLength = "Deve ter no mínimo {1} item(ns).";
        public const string Numeric = "Deve ter apenas caracteres numéricos.";
        public const string Email = "Deve ser um e-mail válido.";
    }
}
