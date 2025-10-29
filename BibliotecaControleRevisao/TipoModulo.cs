namespace BibliotecaControleRevisao
{
    public static class TipoModulo
    {
        private static TipoForm _tipo;

        public static TipoForm Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}