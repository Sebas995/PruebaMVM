namespace Prueba.BLL.Helper
{
    public class MensajeUtil
    {
        public static string ObtenerMensaje(string codigoMensaje)
        {
            return PruebaMVM.BLL.Properties.Mensajes.ResourceManager.GetString(codigoMensaje);
        }
    }
}
